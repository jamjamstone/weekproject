using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weekproject
{
    partial class Game
    {

        //public Game()//생성자로 사용할 몬스터, 아이템, 스테이지, 보스 객체 생성 -> 생성자에서 생성해 봤자 play함수에서는 못씀 실패! Play함수에서 다시 작성!
        //{
        //    
        //
        //}
        public void DetectKey(ConsoleKeyInfo inputKey, Player player)
        {
            switch (inputKey.Key)
            {
                case ConsoleKey.Q:
                    //Console.WriteLine("게임 종료!");
                    Program.isGameRunning = false;
                    return;
                case ConsoleKey.W:
                    //player.Jump();
                    Program.jumpCount = 3;
                    break;
                case ConsoleKey.A:
                    player.Move("left");
                    break;
                case ConsoleKey.D:
                    player.Move("right");
                    break;
                case ConsoleKey.E:
                    player.Inventory.ShowInventory();
                    Program.stopwatch.Stop();
                    break;
                default:
                    break;


            }
        }
        public void SetWorldMap()
        {

        }

        public void SetShopItem(ShopStage shop,Item[] item)
        {
            for (int i = 0; i < item.Length; i++)
            {
                shop.AddItemToSellList(item[i]);
            }
        }
        public void SetMosterAtStage(NormalStage battleStage, Monster normalMonster, Monster normalMonster2)
        {
            int slimeNum = Program.random.Next(0, 4);
            for (int i = 0; i < slimeNum; i++)
            {
                battleStage.AddMonster(normalMonster);
            }
            for (int i = 0; i < 3 - slimeNum; i++)
            {
                battleStage.AddMonster(normalMonster2);
            }
        }
        public void SetBaseField(Stage stage)
        {
            for(int i=0; i<stage.fieldInfo.GetLength(0); i++)//0이 y
            {
                for(int j=0;j<stage.fieldInfo.GetLength(1); j++)//1이 x
                {
                    if (i < 25)
                    {
                        stage.fieldInfo[j, i] = 1;//1은 땅, 및 벽을 의미
                    }
                }
            }
        }
    }
}
