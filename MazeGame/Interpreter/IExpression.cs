using MazeGame.Models;

namespace MazeGame.Interpreter
{
    //interpreter için abstract expressiona karşılık gelen değerdir
    public interface IExpression
    {
        void Interpret(Player player, Maze maze);
    }
}
