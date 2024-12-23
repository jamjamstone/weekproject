using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weekproject
{
    internal class Player
    {
        string _playerName;
        Inventory _inventory;
        Status _playerStatus;
        int _playerX;
        int _playerY;
        Projectile _playerProjectile;
        public Player()
        {
            _playerStatus = new Status();
            _playerProjectile = new Projectile();
            _inventory = new Inventory();

        }
        public Player(string name):this()
        {
            _playerName = name;
        }
        public string playerName
        {
            get { return _playerName; }
            set { _playerName = value; }
        }
        public int playerX
        {
            get { return _playerX; }
            set { _playerX = value; }
        }
        public int playerY
        {
            get { return _playerY; }
            set { _playerY = value; }
        }
        public Inventory Inventory 
        {
            get { return _inventory; } 
            set { _inventory = value; }
        }
        public void PlayerAttack()//projectile을 이용해서 공격하는 함수
        {

        }
        public void PlayerAddItemToInventory(Item item)
        {
            _inventory.AddItem(item);
            _playerStatus = item.;
        }
        public void PlayerSellItemFromInventory(int index)
        {
            _inventory.RemoveItem(index);
        }


    }
}
