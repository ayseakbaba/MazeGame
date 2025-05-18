using MazeGame.Visitor;

namespace MazeGame.Models.GameObjects
{
    public class Monster : IGameObject
    {
        public bool IsAlive { get; set; } = true;

        public void Accept(IVisitor visitor)
        {
            visitor.VisitMonster(this);
        }
    }
}
