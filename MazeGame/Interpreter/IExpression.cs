using MazeGame.Models;

namespace MazeGame.Interpreter
{
    public interface IExpression
    {
        void Interpret(Player player, Maze maze);
    }
}
