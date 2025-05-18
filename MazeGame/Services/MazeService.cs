using MazeGame.Enums;
using MazeGame.Generator;
using MazeGame.Models;
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
        }

        public Maze GetCurrentMaze()
        {
            return _currentMaze;
        }

        public MazeGenerator GetGenerator()
        {
            return _generator;
        }
    }
}
