using MazeGame.Enums;
using MazeGame.Models;

namespace MazeGame.Interpreter.Expressions
{
    public class MoveDownExpression : IExpression
    {
        public Direction _direction;

        public MoveDownExpression(Direction direction)
        {
            _direction = direction;
        }

        public void Interpret(Player player, Maze maze)
        {
            player.MoveForward(maze, _direction);
        }
    }
}
