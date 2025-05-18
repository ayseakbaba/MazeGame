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
            AddMonsterToMaze(); // ← bu satır buraya!
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
            int rows = _currentMaze.Rows;
            int cols = _currentMaze.Columns;

            int mx, my;
            do
            {
                mx = rnd.Next(rows);
                my = rnd.Next(cols);
            }
            while ((mx == 0 && my == 0) || (mx == rows - 1 && my == cols - 1));

            _currentMaze.Grid[mx, my].GameObject = new Monster();
        }
    }
}
