using MazeGame.Enums;
using MazeGame.Generator;
using MazeGame.Models;
using MazeGame.Models.GameObjects;
using System.Reflection.Emit;

namespace MazeGame.Services
{
    public class MazeService
    {
        private Maze _currentMaze;
        private MazeGenerator _generator;

        private Player _player;

        public Player GetPlayer()
        {
            return _player;
        }

        public void SetPlayer(Player player)
        {
            _player = player;
        }

        public void ResetPlayer() // ilk defa oluşturma için
        {
            _player = new Player
            {
                X = 0,
                Y = 0,
                Facing = Direction.Right
            };
        }



        public void GenerateMaze(int rows, int cols)
        {
            _generator = new MazeGenerator(rows, cols);
            _generator.Generate();
            _currentMaze = _generator.ToMazeModel();

            ResetPlayer(); // yeni maze → yeni oyuncu
            AddMonsterToMaze(); // randonm monster atıyor labirente
            AddKeyToMaze(); // randonm key atıyor labirente
        }

        public Maze GetCurrentMaze()
        {
            return _currentMaze;
        }

        public MazeGenerator GetGenerator()
        {
            return _generator;
        }

        private void AddMonsterToMaze()
        {
            var rnd = new Random();
            int row = _currentMaze.Rows;
            int col = _currentMaze.Columns;

            int y, x;
            do
            {
                y = rnd.Next(row);
                x = rnd.Next(col);
            }
            while ((y == 0 && x == 0) || (y == row - 1 && x == col - 1));

            _currentMaze.Grid[y, x].GameObject = new Monster(); // 🔥 doğru yön

        }

        private void AddKeyToMaze()
        {
            var rnd = new Random();
            int y, x;
            do
            {
                y = rnd.Next(_currentMaze.Rows);
                x = rnd.Next(_currentMaze.Columns);
            }
            while (
                (y == 0 && x == 0) ||
                (y == _currentMaze.Rows - 1 && x == _currentMaze.Columns - 1) ||
                _currentMaze.Grid[y, x].GameObject != null // aynı yere monster yerleşmiş olmasın
            );

            _currentMaze.Grid[y, x].GameObject = new Key();
        }

    }
}
