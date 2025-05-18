using MazeGame.Enums;

namespace MazeGame.Models
{
    public class Maze
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        public Cell[,] Grid { get; set; }

        public Maze(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            Grid = new Cell[Rows, Columns];
            for (int r = 0; r < Rows; r++)
                for (int c = 0; c < Columns; c++)
                    Grid[r, c] = new Cell();
        }

        public bool HasWall(int x, int y, Direction direction)
        {
            // Harita dışı kontrolü — sınırdaysa duvar varmış gibi davran
            if (x < 0 || y < 0 || x >= Columns || y >= Rows)
                return true;

            var cell = Grid[y, x]; // dikkat: [satır, sütun] → [y, x]

            return direction switch
            {
                Direction.Up => cell.TopWall,
                Direction.Right => cell.RightWall,
                Direction.Down => cell.BottomWall,
                Direction.Left => cell.LeftWall,
                _ => true
            };
        }
    }
}
