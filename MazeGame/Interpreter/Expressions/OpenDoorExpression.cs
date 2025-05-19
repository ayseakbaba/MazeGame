using MazeGame.Models;
using MazeGame.Visitor;

namespace MazeGame.Interpreter.Expressions
{
    public class OpenDoorExpression : IExpression
    {
        public void Interpret(Player player, Maze maze)
        {
            var cell = maze.Grid[player.Y, player.X];
            var gameObject = cell.GameObject;

            if (gameObject is not null)
            {
                var visitor = new PlayerVisitor(player);
                gameObject.Accept(visitor);
            }
        }
    }
}
