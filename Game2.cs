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
        public void DetectKey(ConsoleKeyInfo inputKey,Stage stage ,Player player)
        {
            switch (inputKey.Key)
            {
                case ConsoleKey.Q:
                    //Console.WriteLine("게임 종료!");
                    Program.isGameRunning = false;
                    return;
                case ConsoleKey.W:
                    //player.Jump();
                    if (Program.jumpCount > 0)
                    {
                        Console.WriteLine("점프카운트추가안됨!");
                        break;
                    }
                    else if(Program.jumpCount==0)
                    {
                        Program.jumpCount = 3;
                        Console.WriteLine("점프카운트 추가");
                    }
                    break;
                case ConsoleKey.A:
                    if (stage.fieldInfo[player.playerX - 1, player.playerY] == 0)
                    {
                        stage.fieldInfo[player.playerX, player.playerY] = 0;
                        player.Move("left");
                        
                        SetPlayerPositionToField(stage, player);
                    }
                    break;
                case ConsoleKey.D:
                    if (stage.fieldInfo[player.playerX + 1, player.playerY] == 0)
                    {
                        stage.fieldInfo[player.playerX, player.playerY] = 0;
                        player.Move("right");
                        SetPlayerPositionToField(stage,player);
                    }
                    
                    break;
                case ConsoleKey.E:
                    player.Inventory.ShowInventory();
                    Program.stopwatch.Stop();
                    break;
                case ConsoleKey.Spacebar:
                    player.PlayerAttack();
                    SetPlayerPositionToField(stage, player);
                    break;
                default:
                    break;


            }
        }
        public void SetPlayerPositionToField(Stage stage, Player player)
        {
            stage.fieldInfo[player.playerX, player.playerY] = 2;
        }
        public void SetMonsterPositionToField(Stage stage)
        {
            foreach (var monster in stage.monsters)
            {
                if (monster.MonsterName == "슬라임")
                {
                    stage.fieldInfo[monster.monsterX, monster.monsterY] = 4;
                }
                else
                {
                    stage.fieldInfo[monster.monsterX, monster.monsterY] = 5;
                }
            }
        }
        public void SetWorldMap()
        {

        }
        //public void DrawProjectile(Player player)//drawMap에 넣었음 필요 없음
        //{
        //    foreach (Projectile proj in player.projectiles)
        //    {
        //        if (proj.isShot)
        //        {
        //
        //            Console.SetCursorPosition(proj.projX, proj.projY);
        //            Console.WriteLine("○");
        //        }
        //    }
        //}
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
            for(int i = 0; i < stage.fieldInfo.GetLength(1); i++)
            {
                stage.fieldInfo[0, i] = 1;
                stage.fieldInfo[49, i] = 1;
                stage.fieldInfo[i, 49] = 1;
            }
        }

        

    }
}
