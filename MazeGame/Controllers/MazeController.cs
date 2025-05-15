using Microsoft.AspNetCore.Mvc;
using MazeGame.Models;
using System;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MazeGame.Generator;
using MazeGame.Dtos;

namespace MazeGame.Controllers
{
    public class MazeController : Controller
    {
        // Labirent boyutlarını sorgu parametresiyle alabiliriz
        public IActionResult Index(int rows = 20, int cols = 20)
        {
            ViewBag.Rows = rows;
            ViewBag.Cols = cols;
            return View();
        }

        // PNG olarak labirenti üretir
        [HttpGet(nameof(MazeImage))]
        public IActionResult MazeImage(int rows = 20, int cols = 20)
        {
            var mg = new MazeGenerator(rows, cols);
            mg.Generate();
            var png = mg.ToPng(cellSize: 20, wallThickness: 2);
            return File(png, "image/png");
        }


        [HttpPost]
        public IActionResult RunBlocks([FromBody] BlocksDto dto)
        {
            if (dto == null || dto.Blocks == null)
                return Json(new { error = "Bloklar gelmedi!" });

            foreach (var block in dto.Blocks)
            {
                Console.WriteLine("Blok çalıştı: " + block);
            }
            return Json(new { ok = true });
        }
    }
}
