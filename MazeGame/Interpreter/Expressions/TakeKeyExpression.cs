using MazeGame.Models;
using MazeGame.Visitor;

namespace MazeGame.Interpreter.Expressions
{
    public class TakeKeyExpression : IExpression
    {
        public void Interpret(Player player, Maze maze)
        {
            var cell = maze.Grid[player.Y, player.X];
            var obj = cell.GameObject;

            if (obj != null)
            {
                var visitor = new PlayerVisitor(player);
                obj.Accept(visitor);
            }
        }
    }
}
