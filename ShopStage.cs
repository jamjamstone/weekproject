using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weekproject
{
    class ShopStage: Stage, IMapDrawing
    {
        List<Item> _sellingItems;
        int _shopGold;
        public int ShopGold
        {
            get { return _shopGold; }
            set { _shopGold = value; }
        }
        public ShopStage()
        {
            _sellingItems = new List<Item>();
            _shopGold = 1000;
        }
        public void SellItemToPlayer(Player player,int index)
        {
            if (player == null) { return; }
            
            player.PlayerAddItemToInventory(_sellingItems[index]);
            player.Inventory.getGold -= _sellingItems[index].price;

            _sellingItems.RemoveAt(index);

        }
        public void BuyItemFromPlayer(Player player,int index)//말그대로 구매기능만 판매 대화나 판매가능 여부는 다른 함수에 구현하기
        {
            
            if (_shopGold > player.Inventory.getGold)
            {
                int temp = _shopGold;
                _shopGold = _shopGold - player.Inventory.getGold;
                player.Inventory.getGold = player.Inventory.getGold + temp;
                player.PlayerSellItemFromInventory(index);
            }
            else
            {
                while (true)
                {
                    Console.WriteLine("판매하려고 하는 물품이 상점이 보유한 골드보다 비쌉니다 정말로 파시겠습니까?");
                    string tempString = Console.ReadLine();
                    if (tempString == "y")
                    {
                        player.Inventory.getGold = player.Inventory.getGold + _shopGold;
                        _shopGold = 0;
                        player.PlayerSellItemFromInventory(index);
                        break;

                    }
                    else if (tempString == "n")
                    {
                        Console.WriteLine("판매를 취소하였습니다.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다. 다시 입력해 주세요");
                    }
                }
            }

        }
        public bool isStageEnd(ConsoleKeyInfo inputKey)
        {
            if(inputKey.Key == ConsoleKey.Q)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void DrawMap()
        {
            
        }

        public void SetField()
        {
            for(int )
        }
    }//end
}
