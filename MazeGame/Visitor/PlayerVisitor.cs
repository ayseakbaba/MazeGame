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

        public void VisitDoor(Door door)
        {
            if (_player.HasKey && _player.KilledMonster) // Canavar öldürüldü mü? → true yapmayı unutma!
            {
                door.IsOpen = true;
                Console.WriteLine("🚪 Kapı açıldı! 🎉 Oyunu bitirdin!");
            }
            else
            {
                Console.WriteLine("🚫 Kapı kapalı. Anahtar ve canavarı yok etmeden geçemezsin!");
            }
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
                _player.KilledMonster = true;
                // Hücredeki canavarı sil
                _player.CurrentCell.GameObject = null;

                Console.WriteLine("💥 Canavar yok edildi!");
            }
        }

        // Diğer Visit metodları sonra gelecek (key, door vs.)
    }
}
