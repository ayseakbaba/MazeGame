using MazeGame.Enums;
using MazeGame.Models;

namespace MazeGame.Interpreter.Expressions
{
    public class MoveExpression : IExpression
    {
        public Direction _direction;

        public MoveExpression(Direction direction)
        {
            _direction = direction;
        }

        public void Interpret(Player player, Maze maze)
        {
            player.MoveForward(maze, _direction);
        }
    }
}
