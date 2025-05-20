using MazeGame.Models;
using MazeGame.Visitor;

namespace MazeGame.Interpreter.Expressions
{
    //visitorda object structure' a karşılık gelir. (acceptin yapıldığı)
    public class AttackExpression : IExpression
    {
        public void Interpret(Player player, Maze maze)
        {
            var cell = maze.Grid[player.Y, player.X];
            var gameObject = cell.GameObject;

            if (gameObject != null)
            {
                var visitor = new PlayerVisitor(player);
                gameObject.Accept(visitor);
            }
        }
    }
}
