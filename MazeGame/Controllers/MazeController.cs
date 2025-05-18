using Microsoft.AspNetCore.Mvc;
using MazeGame.Models;
using MazeGame.Generator;
using MazeGame.Dtos;
using MazeGame.Interpreter;
using MazeGame.Enums;
using MazeGame.Services;
using MazeGame.Interpreter.Expressions;

namespace MazeGame.Controllers
{
    public class MazeController : Controller
    {
        private readonly MazeService _mazeService;

        public MazeController(MazeService mazeService)
        {
            _mazeService = mazeService;
        }

        public IActionResult Index(int rows = 5, int cols = 5)
        {
            _mazeService.GenerateMaze(rows, cols);
            ViewBag.Rows = rows;
            ViewBag.Cols = cols;
            return View();
        }

        [HttpGet(nameof(MazeImage))]
        public IActionResult MazeImage()
        {
            var generator = _mazeService.GetGenerator();
            if (generator == null)
                return NotFound("Maze not generated");

            var png = generator.ToPng(cellSize: generator.GetGeneratorsCellSize(generator), wallThickness: 2);
            return File(png, "image/png");
        }



        [HttpPost]
        public IActionResult RunBlocks([FromBody] BlocksDto dto)
        {
            var maze = _mazeService.GetCurrentMaze();
            if (maze == null)
                return BadRequest("Maze not initialized");

            var player = _mazeService.GetPlayer();
            if (player == null)
            {
                player = new Player
                {
                    X = 0,
                    Y = 0,
                    Facing = Direction.Right
                };
                _mazeService.SetPlayer(player); // ✅ ilk oluştuğunda da kaydet
            }

            var expressions = BlockParser.Parse(dto.Blocks);
            var steps = new List<object>();

            foreach (var expr in expressions)
            {
                bool moved = false;

                if (expr is MoveExpression moveExpr)
                {
                    // MoveForward dönerken hareket etti mi etmedi mi diye bilgi veriyor
                    moved = player.MoveForward(maze, moveExpr._direction);
                }
                else
                {
                    expr.Interpret(player, maze);
                    moved = true; // diğer blok türleri için (turn vs.)
                }

                if (moved)
                {
                    steps.Add(new
                    {
                        x = player.X,
                        y = player.Y,
                        direction = player.Facing.ToString()
                    });
                }
            }

            // 🔥 Oyuncunun son halini kaydet
            _mazeService.SetPlayer(player);
            return Json(steps);
        }
    }
}
