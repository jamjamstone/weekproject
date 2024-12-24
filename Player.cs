using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace weekproject
{
    internal class Player
    {
        string _playerName;
        Inventory _inventory;
        Status _playerStatus;
        int _playerX=26;
        int _playerY=26;
        Projectile[] _projectiles= new Projectile[30];
        Projectile _playerProjectile=new Projectile();
        
        public Player()
        {
            _playerStatus = new Status();
            //_projectiles = new List<Projectile>();
            _inventory = new Inventory();
            //
            _playerProjectile = new Projectile(1,1,2);
            _playerProjectile.isShot = false;
            //
            for(int i = 0; i < _projectiles.Length; i++)
            {
                _projectiles[i] = new Projectile(1,1,2);
                //_projectiles[i] = _playerProjectile;
                _projectiles[i].isShot = false;
            }

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
        public Status PlayerStatus
        {
            get { return _playerStatus; }
            set { _playerStatus = value; }
        }
        public Projectile PlayerProjectile
        {
            get { return _playerProjectile; }
            set { _playerProjectile = value; }
        }
        public Projectile[] projectiles
        {
            get { return _projectiles; }
            set { projectiles = value; }
        }
        public Projectile PlayerAttack()//projectile을 이용해서 공격하는 함수 // 구현중
        {
            //_playerProjectile.Dmg += _playerStatus.ATK;
            //_playerProjectile.ProjectileShoot();
            //_playerProjectile.Dmg -= _playerStatus.ATK;
            for (int i = 0; i < projectiles.Length; i++)
            {
                if (projectiles[i].isShot)
                {
                    continue;
                }
                else
                {
                    projectiles[i].isShot = true;
                    projectiles[i].projY = _playerY;
                    
                    projectiles[i].projX = _playerX;
                    
                    return projectiles[i];   
                }
            }
            return null;



        }
        public void PlayerAddItemToInventory(Item item)//아이템을 사면서 스탯 변화 적용
        {
            _inventory.AddItem(item);
            _playerStatus.HP += _inventory.SumStatus().HP;
            _playerStatus.def += _inventory.SumStatus().def;
            _playerStatus.ATK += _inventory.SumStatus().ATK;
            if (item is ItemChangeProj)
            {
                (item as ItemChangeProj).ChangePlayerProjectile(this);
            }
            //_playerStatus
        }
        public void PlayerSellItemFromInventory(int index)//아이템을 팔면서 스탯변화 적용
        {
            _playerStatus.ATK -= _inventory.getItems[index].status.ATK;
            _playerStatus.HP -= _inventory.getItems[index].status.HP;
            _playerStatus.def -= _inventory.getItems[index].status.def;
            if(_inventory.getItems[index] is ItemChangeProj)
            {
                (_inventory.getItems[index] as ItemChangeProj).ChangePlayerProjectile(this);
            }

            _inventory.RemoveItem(index);
        }
        public void PlayerAddGoldToInventory(int gold)
        {
            _inventory.getGold += gold;
        }

        public void Jump()//점프가진행되는동안 멈춤 좀 더 부드럽게 되는게 필요
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
        public void Move(string direction)//이동제한조건을 여기에 넣을까 딴데 넣을까-> 필드를 인자로 가지고 있지 않으니 이동 조건은 스테이지에 달자
        {
            if(direction == "left")
            {
                _playerX -= 1;
                //_playerProjectile.IsShotLeft = true;


            }else if(direction == "right")
            {
                _playerX += 1;
                //_playerProjectile.IsShotLeft = false;
            }
        }

    }
}
