using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weekproject
{
    internal class Inventory
    {
        List<Item> _getItems=new List<Item>();
        int _getGold;
        public int getGold
        {
            get { return _getGold; }
            set { _getGold = value; }
        }
        public List<Item> getItems
        {
            get { return _getItems; }
            set { _getItems = value; }
        }
        public void AddItem(Item getItem)// 인벤토리에 아이템 추가
        {
            _getItems?.Add(getItem);
        }
        public void RemoveItem(int itemNum)//인벤토리에 아이템 제거
        {
            _getItems?.RemoveAt(itemNum);
        }

        public void ShowInventory()
        {
            Console.WriteLine("보유한 아이템 목록");
            int i = 1;
            foreach (Item item in _getItems)
            {
                Console.WriteLine($"{i}: {item.itemName}");
                i++;
            }
        }

        public Status SumStatus()
        {
            Status sumStatus= new Status();
            foreach (Item item in _getItems)
            {
                sumStatus.HP += item.status.HP;
                sumStatus.def += item.status.def;
                sumStatus.ATK += item.status.ATK;

            }
            return sumStatus;
        }


        }
}
