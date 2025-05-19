using MazeGame.Visitor;

namespace MazeGame.Models.GameObjects
{
    public class Key : IGameObject
    {
        public bool IsTaken { get; set; } = false;

        public void Accept(IVisitor visitor)
        {
            visitor.VisitKey(this);
        }
    }
}
