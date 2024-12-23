using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        Projectile _playerProjectile=new Projectile();
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
            _playerStatus.HP += _inventory.SumStatus().HP;
            _playerStatus.def += _inventory.SumStatus().def;
            _playerStatus.ATK += _inventory.SumStatus().ATK;
            //_playerStatus
        }
        public void PlayerSellItemFromInventory(int index)
        {
            _playerStatus.ATK -= _inventory.getItems[index].status.ATK;
            _playerStatus.HP -= _inventory.getItems[index].status.HP;
            _playerStatus.def -= _inventory.getItems[index].status.def;
            _inventory.RemoveItem(index);
        }
        public void PlayerAddGoldToInventory(int gold)
        {
            _inventory.getGold += gold;
        }

        public void Jump()
        {
            Stopwatch sw = Stopwatch.StartNew();
            sw.Start();
            for (int i = 0; i < 3; i++)
            {
                while (sw.ElapsedMilliseconds < 500)
                {

                }

                _playerY += 1;
                sw.Restart();
            }
            sw.Stop();
        }
        public void Move(string direction)//이동제한조건을 여기에 넣을까 딴데 넣을까
        {
            if(direction == "left")
            {
                _playerX -= 1;



            }else if(direction == "right")
            {
                _playerX += 1;
            }
        }

    }
}
