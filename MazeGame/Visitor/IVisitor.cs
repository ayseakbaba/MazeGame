using MazeGame.Models.GameObjects;

namespace MazeGame.Visitor
{
    public interface IVisitor
    {
        void VisitMonster(Monster monster);
        void VisitKey(Key key);
        void VisitDoor(Door door);


    }
}
