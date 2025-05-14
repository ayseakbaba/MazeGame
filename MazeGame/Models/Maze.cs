namespace MazeGame.Models
{
    public class Maze
    {
        public int[,] Grid { get; private set; }
        public int Rows { get; private set; }
        public int Columns { get; private set; }

        public Maze(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            Grid = new int[rows, columns];
            GenerateMaze();
        }

        private void GenerateMaze()
        {
            // Fill all cells with walls (1)
            for (int r = 0; r < Rows; r++)
                for (int c = 0; c < Columns; c++)
                    Grid[r, c] = 1;

            // Start the recursive generation from top-left corner
            CarvePassages(0, 0);
        }

        private void CarvePassages(int row, int col)
        {
            // Define movement directions: Up, Down, Left, Right
            int[][] directions = new int[][]
            {
                new[] {-1, 0},  // Up
                new[] {1, 0},   // Down
                new[] {0, -1},  // Left
                new[] {0, 1}    // Right
            };

            // Shuffle directions for randomness
            directions = directions.OrderBy(d => Guid.NewGuid()).ToArray();

            foreach (var direction in directions)
            {
                int newRow = row + direction[0];
                int newCol = col + direction[1];

                // Check if new position is within bounds and surrounded by walls
                if (newRow >= 0 && newRow < Rows &&
                    newCol >= 0 && newCol < Columns &&
                    Grid[newRow, newCol] == 1)
                {
                    // Check for 2 cells away to ensure it's carving a valid passage
                    int betweenRow = row + direction[0] / 2;
                    int betweenCol = col + direction[1] / 2;

                    if (Grid[betweenRow, betweenCol] == 1)
                    {
                        // Carve passages
                        Grid[row, col] = 0;
                        Grid[betweenRow, betweenCol] = 0;
                        Grid[newRow, newCol] = 0;

                        // Recurse
                        CarvePassages(newRow, newCol);
                    }
                }
            }
        }

    }
}
