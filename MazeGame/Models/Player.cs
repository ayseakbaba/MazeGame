using MazeGame.Enums;

namespace MazeGame.Models
{
    public class Player
    {
        public int X { get; set; } // sütun
        public int Y { get; set; } // satır
        public Direction Facing { get; set; } = Direction.Right; // başlangıç yönü
        public Cell CurrentCell { get; set; }
        public bool HasKey { get; set; } = false;
        public bool KilledMonster { get; set; } = false;


        public bool MoveForward(Maze maze, Direction direction)
        {
            if (maze.HasWall(X, Y, direction))
            {
                Console.WriteLine("❌ Hareket engellendi! Duvar var.");
                return false;
            }

            switch (direction)
            {
                case Direction.Up: Y--; break;
                case Direction.Down: Y++; break;
                case Direction.Left: X--; break;
                case Direction.Right: X++; break;
            }

            //Facing = direction;

            Console.WriteLine($"✅ Hareket edildi! Yeni pozisyon: ({X}, {Y})");
            return true;
        }


    }

}
