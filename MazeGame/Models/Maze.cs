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
    }
}
