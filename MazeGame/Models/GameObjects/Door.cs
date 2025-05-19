using MazeGame.Visitor;

namespace MazeGame.Models.GameObjects
{
    public class Door : IGameObject
    {
        public bool IsOpen { get; set; } = false;

        public void Accept(IVisitor visitor)
        {
            visitor.VisitDoor(this);
        }
    }
}
