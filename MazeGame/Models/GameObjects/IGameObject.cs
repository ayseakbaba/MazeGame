using MazeGame.Visitor;

namespace MazeGame.Models.GameObjects
{
    public interface IGameObject
    {
        void Accept(IVisitor visitor);
    }
}
