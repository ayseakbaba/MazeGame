using Microsoft.AspNetCore.Mvc;
using MazeGame.Models;
using System;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MazeGame.Generator;

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
        public IActionResult MazeImage(int rows = 20, int cols = 20)
        {
            var mg = new MazeGenerator(rows, cols);
            mg.Generate();
            var png = mg.ToPng(cellSize: 20, wallThickness: 2);
            return File(png, "image/png");
        }
    }
}
