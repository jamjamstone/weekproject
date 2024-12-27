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
        //public void CreateWorldMapTree(WorldMap<Stage> worldMap,Stage stage )
        //{
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
                    if (Program.jumpCount > 0 )//무한점프
                    {
                        //Console.WriteLine("점프카운트추가안됨!");
                        break;
                    }
                    else if(Program.jumpCount==0 && stage.fieldInfo[player.playerX, player.playerY - 1] != 0)
                    {
                        //Console.SetCursorPosition(53, 0);
                        Program.jumpCount = 4;
                       // Console.WriteLine("점프카운트 추가");
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
                    Console.WriteLine(monster.monsterX);
                    Console.WriteLine(monster.monsterY);
                    stage.fieldInfo[monster.monsterX, monster.monsterY] = 4;
                }
                else
                {
                    Console.WriteLine(monster.monsterX);
                    Console.WriteLine(monster.monsterY);
                    
                    stage.fieldInfo[monster.monsterX, monster.monsterY] = 5;
                }
            }
        }
        //public void SetWorldMap()
        //{
        //
        //}
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
        public void SetMosterAtStage(Stage battleStage, Monster normalMonster, Monster normalMonster2)
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

        public void SetBattle2(Stage stage)
        {
            int count = 1;
            for (int i = 0; i < stage.fieldInfo.GetLength(0); i++)//0이 y, i가 y
            {
                for (int j = 0; j < stage.fieldInfo.GetLength(1); j++)//1이 x,j가 x
                {

                    if (10 < j && j < 30)
                    {
                        stage.fieldInfo[j, i] = 0;
                    }
                }
            }
            for (int i = 0; i < stage.fieldInfo.GetLength(0); i++)//0이 y, i가 y
            {
                for (int j = 0; j < stage.fieldInfo.GetLength(1); j++)//1이 x,j가 x
                {

                    if (10 < j && j < 30 && i == 26)
                    {
                        stage.fieldInfo[j, i] = 1;
                    }
                }
            }
            for (int i = 0; i < stage.fieldInfo.GetLength(1); i++)
            {
                stage.fieldInfo[0, i] = 1;
                stage.fieldInfo[49, i] = 1;
                stage.fieldInfo[i, 49] = 1;
            }
            foreach (Monster monster in stage.monsters)
            {
                switch (count)
                {
                    case 1:
                        monster.SetMonsterXY(Program.random.Next(5, 10), 25);
                        break;
                    case 2:
                        monster.SetMonsterXY(Program.random.Next(30, 40), 25);
                        break;
                    case 3:
                        monster.SetMonsterXY(Program.random.Next(11, 15), 27);
                        break;
                    case 4:
                        monster.SetMonsterXY(Program.random.Next(15, 29), 27);
                        break;
                    default:
                        break;
                }
                count++;
            }
        }

       




        public void SetBattle3(Stage stage)
        {
            int count = 1;
            for (int i = 0; i < stage.fieldInfo.GetLength(0); i++)//0이 y
            {
                for (int j = 0; j < stage.fieldInfo.GetLength(1); j++)//1이 x
                {
                    if (i -j <=22&&j<25)
                    {
                        stage.fieldInfo[j, i] = 1;//1은 땅, 및 벽을 의미
                    }
                }
            }
            for (int i = 0; i < stage.fieldInfo.GetLength(0); i++)//0이 y
            {
                for (int j = 0; j < stage.fieldInfo.GetLength(1); j++)//1이 x
                {
                    if (j>= 25 && j < 30)
                    {
                        stage.fieldInfo[j, i] = 0;//1은 땅, 및 벽을 의미
                    }
                }
            }

            for (int i = 0; i < stage.fieldInfo.GetLength(1); i++)
            {
                stage.fieldInfo[0, i] = 1;
                stage.fieldInfo[49, i] = 1;
                stage.fieldInfo[i, 49] = 1;
            }
            foreach (Monster monster in stage.monsters)
            {
                switch (count)
                {
                    case 1:
                        monster.SetMonsterXY(8, 31);
                        break;
                    case 2:
                        monster.SetMonsterXY(10, 33);
                        break;
                    case 3:
                        monster.SetMonsterXY(33,25);
                        break;
                    case 4:
                        monster.SetMonsterXY(41, 25);
                        break;
                    default:
                        break;
                }
                count++;
            }

        }

        public void SetBattle4(Stage stage)//배틀 4까지 작성 완료
        {
            int count = 1;
            for (int i = 0; i < stage.fieldInfo.GetLength(0); i++)//0이 y
            {
                for (int j = 0; j < stage.fieldInfo.GetLength(1); j++)//1이 x
                {
                    if (13 < j && j < 18 && i == 27)
                    {
                        stage.fieldInfo[j, i] = 1;
                    }

                    if(31 < j && j < 36 && i == 27)
                    {
                        stage.fieldInfo[j, i] = 1;
                    }
                    if(18 < j && j < 31 && i == 29)
                    {
                        stage.fieldInfo[j, i] = 1;
                    }
                }
            }
            for (int i = 0; i < stage.fieldInfo.GetLength(0); i++)//0이 y
            {
                for (int j = 0; j < stage.fieldInfo.GetLength(1); j++)//1이 x
                {
                    if (i < 25&&13<j&&j<36)
                    {
                        stage.fieldInfo[j, i] = 0;//1은 땅, 및 벽을 의미
                    }
                }
            }





            for (int i = 0; i < stage.fieldInfo.GetLength(1); i++)//바닥은 갱신 안함!
            {
                stage.fieldInfo[0, i] = 1;
                stage.fieldInfo[49, i] = 1;
                stage.fieldInfo[i, 49] = 1;
            }
            foreach (Monster monster in stage.monsters)
            {
                switch (count)
                {
                    case 1:
                        monster.SetMonsterXY(15, 28);
                        break;
                    case 2:
                        monster.SetMonsterXY(21, 30);
                        break;
                    case 3:
                        monster.SetMonsterXY(36, 30);
                        break;
                    case 4:
                        monster.SetMonsterXY(34, 28);
                        break;
                    default:
                        break;
                }
                count++;
            }






        }//

        public void SetBoss1(Stage stage)
        {//보스 몸체는 7
            for (int i = 0; i < stage.fieldInfo.GetLength(0); i++)//0이 y
            {
                for (int j = 0; j < stage.fieldInfo.GetLength(1); j++)//1이 x
                {
                    if (j > 2&&i>1)
                    {
                        stage.fieldInfo[j, i] = 0;//1은 땅, 및 벽을 의미
                    }
                }
            }

            for (int i = 0; i < stage.fieldInfo.GetLength(0); i++)//0이 y
            {
                for (int j = 0; j < stage.fieldInfo.GetLength(1); j++)//1이 x
                {
                    if (j > 38 && i < 35)
                    {
                        stage.fieldInfo[j, i] = 7;//1은 땅, 및 벽을 의미
                    }
                    if (i>=35&&j+i==39+34)
                    {
                        stage.fieldInfo[j, i] = 7;
                    }
                }
            }

        }

        public void SetBoss2(Stage stage)
        {
            for (int i = 0; i < stage.fieldInfo.GetLength(0); i++)//0이 y
            {
                for (int j = 0; j < stage.fieldInfo.GetLength(1); j++)//1이 x
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
