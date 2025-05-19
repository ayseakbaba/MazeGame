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
            var maze = _mazeService.GetCurrentMaze();
            ViewBag.Rows = rows;
            ViewBag.Cols = cols;
            ViewBag.Maze = maze;
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
                player.CurrentCell = maze.Grid[player.Y, player.X];
                _mazeService.SetPlayer(player);
            }
            dto.Blocks.ForEach(x=> x.ToLower());
            var expressions = BlockParser.Parse(dto.Blocks);
            var steps = new List<object>();

            foreach (var expr in expressions)
            {
                int oldX = player.X;
                int oldY = player.Y;

                expr.Interpret(player, maze);

                bool moved = (player.X != oldX || player.Y != oldY);
                bool killedMonster = expr is AttackExpression;
                bool takeKey = expr is TakeKeyExpression;
                bool openedDoor = expr is OpenDoorExpression;

                // 💡 Artık sadece hareket değil, tüm bloklar adım üretir
                steps.Add(new
                {
                    x = player.X,
                    y = player.Y,
                    direction = player.Facing.ToString(),
                    killedMonster,
                    takeKey,
                    openedDoor
                });

                // Oyuncunun bulunduğu hücreyi güncelle
                player.CurrentCell = maze.Grid[player.Y, player.X];
            }

            _mazeService.SetPlayer(player);
            return Json(steps);
        }

    }
}
