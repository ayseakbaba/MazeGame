using MazeGame.Enums;
using MazeGame.Models;

namespace MazeGame.Interpreter.Expressions
{
    public class MoveUpExpression : IExpression
    {
        public Direction _direction;

        public MoveUpExpression(Direction direction)
        {
            _direction = direction;
        }

        public void Interpret(Player player, Maze maze)
        {
            player.MoveForward(maze, _direction);
        }
    }
}
