using MazeGame.Visitor;

namespace MazeGame.Models.GameObjects
{
    //visitorda ConcreteElemente karşılık gelir.
    public class Monster : IGameObject
    {
        public bool IsAlive { get; set; } = true;

        public void Accept(IVisitor visitor)
        {
            visitor.VisitMonster(this);
        }
    }
}
