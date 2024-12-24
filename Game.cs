using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace weekproject
{
    partial class Game
    {
        

       
        public void DrawStartWindow()
        {
            Console.WriteLine("  ____  _  _   _     \r\n / ___|| || |_| |__  \r\n| |  |_  ..  _| '_ \\ \r\n| |__|_      _| |_) |\r\n \\____||_||_| |_.__/ ");
            Console.WriteLine("Game Start!");
            Console.ReadLine();
        }
        public void Update(Stage stage,Player player)
        {
            if (stage == null) { return; }
            if(player == null) { return; }
            if(stage is ShopStage)
            {
                return;
            }
            else
            {
                if (stage?.fieldInfo[player.playerX, player.playerY - 1] != 1&&Program.jumpCount==0)
                {
                    player.playerY -= 1; 
                }
                if (player.playerY <= 0)
                {
                    Program.isGameRunning = false;
                }
                if (stage is ShopStage)
                {
                    (stage as ShopStage).DrawMap();
                }
                else
                {
                    stage.DrawMap();
                }

                for (int k = 0; k < player.projectiles.Length; k++)
                {
                    if (player.projectiles[k].isShot)
                    {
                        if (player.projectiles[k].IsShotLeft)//왼쪽으로 날아가는 중이면
                        {
                            int tempX = player.projectiles[k].projX - player.projectiles[k].Speed;
                            if (stage.fieldInfo[tempX, player.projectiles[k].projY] == 1)//벽에 부딫히면
                            {
                                player.projectiles[k].isShot = false;
                                continue;
                            }
                            else//아닐경우
                            {
                                player.projectiles[k].projX -= player.projectiles[k].Speed;
                            }
                        }
                        else
                        {
                            int tempX = player.projectiles[k].projX + player.projectiles[k].Speed;
                            if (stage.fieldInfo[tempX, player.projectiles[k].projY] == 1)//벽에 부딫히면
                            {
                                player.projectiles[k].isShot = false;
                                continue;
                            }
                            else//아닐경우
                            {
                                player.projectiles[k].projX += player.projectiles[k].Speed;
                            }
                            
                        }
                    }
                }



                //for(int i=stage.fieldInfo.GetLength(0);i>=0; i++)
                //{
                //    for(int j = 0; j < stage.fieldInfo.GetLength(1); j++)
                //    {
                //        
                //        for(int k=0;k<player.projectiles.Length;k++)
                //        {
                //            if (player.projectiles[k].isShot)
                //            {
                //                if(player.projectiles[k].IsShotLeft)
                //                {
                //                    int tempX = player.projectiles[k].projX - player.projectiles[k].Speed;
                //                    if (stage.fieldInfo[tempX,])
                //                    player.projectiles[k].projX -= player.projectiles[k].Speed;
                //                }
                //                else
                //                {
                //                    player.projectiles[k].projX += player.projectiles[k].Speed;
                //                }
                //            }
                //        }
                //
                //
                //
                //    }
                //}



            }
        }

        public void Play()
        {

            //WorldMap<Stage> worldMap = new WorldMap<Stage>();
            //아이템 설정
            Item[] items = new Item[4];
            Item redSword = new Item("빨강검", 300);
            redSword.SetItemStatus(0, -1, 2);

            redSword.description = "붉은 검, 방어를 대가로 높은 공격력을 얻는다.";
            Item sling = new ItemChangeProj(1, 2, 1);
            sling.SetItemStatus(0, 0, 1);

            sling.description = "가벼운 새총, 공격이 기이한 궤도를 그린다.";
            Item woodShield = new Item("나무방패", 200);
            woodShield.SetItemStatus(0, 1, 0);

            woodShield.description = "나무방패, 가벼운 나무방패 안심된다.";
            Item heartGem = new Item("하트보석", 200);
            heartGem.SetItemStatus(5, 0, 0);
            heartGem.description = "하트보석, 하트모양 보석 왠지 따듯하다.";
            //아이템 설정 
            Monster normalMonster = new Monster("슬라임", 2, 0, 1);
            normalMonster.MonsterProjectile = new Projectile(1, 1, 0);
            Monster normalMonster2 = new Monster("#", 3, 2, 1);
            normalMonster.MonsterProjectile = new Projectile(1, 2, 0);

            Stage shop1 = new ShopStage();
            SetShopItem((shop1 as ShopStage), items);

            Stage battle1 = new NormalStage();
            Stage battle2 = new NormalStage();
            Stage battle3 = new NormalStage();
            Stage battle4 = new NormalStage();

            battle1.AddMonster(normalMonster);//1은 튜토리얼 스테이지로 조작법을 맵 위에 뛰울 예정, set커서로 배경그리고 커서 이동시켜서 조작법 출력하면 될듯
            SetMosterAtStage(battle2 as NormalStage, normalMonster, normalMonster2);//전투 스테이지에 몬스터 배정 
            SetMosterAtStage(battle3 as NormalStage, normalMonster, normalMonster2);
            SetMosterAtStage(battle4 as NormalStage, normalMonster, normalMonster2);
            SetBaseField(battle1);

            Stage Boss1 = new BossStage();
            Stage Boss2 = new BossStage();


            //아이템 대강 5종류?//4개로 완성
            //몬스터 3종류// 2종류 완성
            //보스 2종류//이걸 어케 하지
            //스테이지 3종류 여러개// 생성은 함
            //발사체도 여러개 만들기// 2종류만 구현






            ConsoleKeyInfo inputKey;
            DrawStartWindow();
            Console.WriteLine("플레이어의 이름을 입력해 주세요!");
            Player player = new Player();
            player.playerName = Console.ReadLine();
            WorldMap <Stage> worldMap = new WorldMap <Stage>();
            MapNode<Stage> nowMapNode;
            //worldMap.AddNodeRandom();
            MapNode<Stage> battle1Node = new MapNode<Stage>(battle1,0);
            worldMap.StartStage = battle1Node;
            nowMapNode = worldMap.StartStage;



            //
            Program.stopwatch.Start();
            while (Program.isGameRunning) 
            {
               
                if (Console.KeyAvailable)
                {//키가 눌렸을 때 이동, 중력 작용, 공격기능, 메뉴 열기, 스페이스바 공격 w 위로 점프 a왼쪽 d오른쪽 s 아무것도 없음 q 종료 e 인벤토리 열기 및 일시정지
                    inputKey = Console.ReadKey();
                    DetectKey(inputKey, player);
                    Console.WriteLine("키 인식");

                }
                if (Program.jumpCount > 0&&nowMapNode.stage.fieldInfo[player.playerX,player.playerY+1]==0) 
                {
                    player.playerY += 1;
                    Program.jumpCount--;
                }
                if (Program.stopwatch.ElapsedMilliseconds > 200)
                {
                    Update(nowMapNode.stage,player);
                    Console.WriteLine("시간 지남");
                    Program.stopwatch.Restart();
                }
                if (nowMapNode.stage.isStageEnd())
                {

                }
                //아닐때 중력 작용
                //일정 시간마다 몬스터 공격
                //보스는 패턴 존재




            }

            Console.WriteLine("게임 종료!");


























            //


        }


    }//end
}
