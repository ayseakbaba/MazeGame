using MazeGame.Enums;
using MazeGame.Models;

namespace MazeGame.Interpreter.Expressions
{
    //interpreter için terminal expressiona karşılık gelen değerdir
    public class MoveRightExpression : IExpression
    {
        public Direction _direction;

        public MoveRightExpression(Direction direction)
        {
            _direction = direction;
        }

        public void Interpret(Player player, Maze maze)
        {
            player.MoveForward(maze, _direction);
        }
    }
}
