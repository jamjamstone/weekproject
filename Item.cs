using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weekproject
{
    class Item
    {
        string _itemName;
        int _price;
        Status _status;
        string _description;

        public Item() 
        {
            _status = new Status();
        }
        public Item(string itemName, int price):this()
        {
            _itemName = itemName;
            _price = price;
        }
        public Status status
        {
            get { return _status; }
        }
        public string itemName
        {
            get { return _itemName; }
            set { _itemName = value; }
        }
        public int price
        {
            get { return _price; }
            set { _price = value; }
        }
        public string description
        {
            get { return _description; }
            set { _description = value; }
        }
    }

    class ItemChangeProj:Item
    {
        Projectile _projectile;
        public Projectile projectile
        {
            get { return _projectile; }
            set { _projectile = value; }
        }
        public ItemChangeProj(int dmg, int speed, int interval)
        {
            _projectile = new Projectile(dmg, speed, interval);
        }
        public void ChangePlayerProjectile(Player player)
        {
            Projectile tem = _projectile;
            _projectile=player.PlayerProjectile;
            player.PlayerProjectile = tem;
        }

    }

}
