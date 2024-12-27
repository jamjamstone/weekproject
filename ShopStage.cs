using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weekproject
{
    class ShopStage: Stage, IMapDrawing
    {
        public static bool isShopEnd = false;
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
        public void AddItemToSellList(Item item)
        {
            _sellingItems.Add(item);
        }


        public void SellItemToPlayer(Player player,int index)
        {
            if (player == null) { return; }
            if(index < 0) { return; }
            if(index >= _sellingItems.Count) { return; }


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
        public override bool isStageEnd()
        {
            if (isShopEnd)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override void DrawMap()
        {
            Console.WriteLine(Program.merchant);
            ShowItems();
        }
        public void ShowItems()
        {
            int index = 0;
            foreach (Item item in _sellingItems)
            {
                Console.WriteLine($"{index+1}{item.itemName}:{item.description}");
                Console.WriteLine($"{item.price}원");
                index++;
            }
            Console.WriteLine("구매는 b, 판매는 s 를 누르세요");
        }
        public void SetField()
        {
            //for(int )
        }


        public void ShopPlay(Player player)
        {
            DrawMap();
            ConsoleKeyInfo input;   
            while (!isShopEnd)
            {
                input = Console.ReadKey();
                switch (input.Key)
                {
                    case ConsoleKey.B:
                        Console.WriteLine("구매할 물건을 선택해 주세요");
                        int a;
                        int.TryParse(Console.ReadLine(), out a);
                        SellItemToPlayer(player, a);
                        break;
                    case ConsoleKey.S:
                        
                        break;
                        default:
                        break;
                }
            }
        }
    }//end
}
