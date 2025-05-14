using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace MazeGame.Generator
{
    public class MazeGenerator
    {
        private readonly int _rows, _cols;
        private readonly bool[,] _hWalls, _vWalls;
        private readonly Random _rnd = new Random();

        public MazeGenerator(int rows, int cols)
        {
            _rows = rows;
            _cols = cols;
            // Dikey ve yatay duvar dizileri; true = duvar var
            _hWalls = new bool[rows + 1, cols];
            _vWalls = new bool[rows, cols + 1];
            for (int r = 0; r <= rows; r++)
                for (int c = 0; c < cols; c++)
                    _hWalls[r, c] = true;
            for (int r = 0; r < rows; r++)
                for (int c = 0; c <= cols; c++)
                    _vWalls[r, c] = true;
        }

        public void Generate()
        {
            Carve(0, 0, new bool[_rows, _cols]);
            // BAŞLANGIÇ (0,0) hücresinin sol duvarını aç
            _vWalls[0, 0] = false;
            // BİTİŞ (en sağ alt) hücresinin sağ duvarını aç
            _vWalls[_rows - 1, _cols] = false;
        }

        private void Carve(int r, int c, bool[,] visited)
        {
            visited[r, c] = true;
            var dirs = new (int dr, int dc, Action removeWall)[]
            {
                (-1,  0, () => _hWalls[r, c] = false),    // yukarı
                ( 1,  0, () => _hWalls[r+1, c] = false),  // aşağı
                ( 0, -1, () => _vWalls[r, c] = false),    // sol
                ( 0,  1, () => _vWalls[r, c+1] = false),  // sağ
            };
            // Rastgele sırala
            for (int i = dirs.Length - 1; i > 0; i--)
            {
                int j = _rnd.Next(i + 1);
                (dirs[i], dirs[j]) = (dirs[j], dirs[i]);
            }

            foreach (var (dr, dc, removeWall) in dirs)
            {
                int nr = r + dr, nc = c + dc;
                if (nr < 0 || nr >= _rows || nc < 0 || nc >= _cols) continue;
                if (visited[nr, nc]) continue;
                removeWall();
                Carve(nr, nc, visited);
            }
        }

        /// <summary>
        /// Labirenti bir PNG resmini olarak döner.
        /// </summary>
        public byte[] ToPng(int cellSize = 20, int wallThickness = 2)
        {
            int w = _cols * cellSize + wallThickness;
            int h = _rows * cellSize + wallThickness;
            using var bmp = new Bitmap(w, h);
            using var g = Graphics.FromImage(bmp);
            g.Clear(Color.White);
            using var pen = new Pen(Color.Black, wallThickness);

            // Yatay duvarlar
            for (int r = 0; r <= _rows; r++)
                for (int c = 0; c < _cols; c++)
                    if (_hWalls[r, c])
                        g.DrawLine(pen,
                            c * cellSize,
                            r * cellSize,
                            (c + 1) * cellSize,
                            r * cellSize);

            // Dikey duvarlar
            for (int r = 0; r < _rows; r++)
                for (int c = 0; c <= _cols; c++)
                    if (_vWalls[r, c])
                        g.DrawLine(pen,
                            c * cellSize,
                            r * cellSize,
                            c * cellSize,
                            (r + 1) * cellSize);

            using var ms = new MemoryStream();
            bmp.Save(ms, ImageFormat.Png);
            return ms.ToArray();
        }
    }

}
