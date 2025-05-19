using MazeGame.Models.GameObjects;
using MazeGame.Models;

namespace MazeGame.Visitor
{
    public class PlayerVisitor : IVisitor
    {
        private readonly Player _player;

        public PlayerVisitor(Player player)
        {
            _player = player;
        }

        public void VisitKey(Key key)
        {
            if (!key.IsTaken)
            {
                key.IsTaken = true;
                _player.HasKey = true;
                _player.CurrentCell.GameObject = null;

                Console.WriteLine("🗝️ Anahtar alındı!");
            }
        }

        public void VisitMonster(Monster monster)
        {
            if (monster.IsAlive)
            {
                monster.IsAlive = false;

                // Hücredeki canavarı sil
                _player.CurrentCell.GameObject = null;

                Console.WriteLine("💥 Canavar yok edildi!");
            }
        }

        // Diğer Visit metodları sonra gelecek (key, door vs.)
    }
}
