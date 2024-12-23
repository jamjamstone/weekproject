using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weekproject
{
    abstract class Item
    {
        string _itemName;
        int _price;
        Status _status;

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

    }

    

}
