using MazeGame.Visitor;

namespace MazeGame.Models.GameObjects
{
    //visitorda elemente karşılık gelir.
    public interface IGameObject
    {
        void Accept(IVisitor visitor);
    }
}
