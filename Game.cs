﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
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
        public void Update(Stage stage, Player player)
        {
            if (stage == null) { return; }
            if (player == null) { return; }
            if (stage is ShopStage)//상점이면 업데이트 필요 없음
            {
                return;
            }
            else
            {
                if (Program.jumpCount > 0 && stage.fieldInfo[player.playerX, player.playerY + 1] == 0) //이거 업데이트에 넣자
                {
                    player.playerY += 1;
                    SetPlayerPositionToField(stage, player);
                    Program.jumpCount--;
                }
                else if (Program.jumpCount > 0 && stage.fieldInfo[player.playerX, player.playerY + 1] != 0)//벽또는 몬스터가 있으면 점프 불가
                {
                    Program.jumpCount--;
                }
                if (stage?.fieldInfo[player.playerX, player.playerY - 1] == 0 && Program.jumpCount == 0)//플레이어 중력 작용
                {
                    player.playerY -= 1;
                    SetPlayerPositionToField(stage, player);
                }
                if (player.playerY <= 0)
                {
                    Program.isGameRunning = false;
                }
                SetMonsterPositionToField(stage);
                //foreach (var monster in stage.monsters)
                //{
                //
                //    monster.MonsterAttack();
                //}
                foreach (var monster in stage.monsters)
                {
                    foreach(var proj in monster.projectiles)
                    {

                    }
                }
                    for (int i = stage.fieldInfo.GetLength(0) - 1; i >= 0; i--)//플레이어 위치 추적
                {
                    for (int j = 0; j < stage.fieldInfo.GetLength(1); j++)
                    {
                        if (stage.fieldInfo[j, i] == 2)
                        {
                            if (j == player.playerX && i == player.playerY)
                            {
                                continue;
                            }
                            stage.fieldInfo[j, i] = 0;
                        }
                    }
                }
                
                for (int k = 0; k < player.projectiles.Length; k++)// 플레이어 투사체 업데이트
                {
                    if (player.projectiles[k].isShot)//투사체가 발사중이라면
                    {
                        if (player.projectiles[k].IsShotLeft)//왼쪽으로 날아가는 중이면
                        {
                            for (int i = 0; i < player.projectiles[k].Speed; i++)
                            {
                                int tempX = player.projectiles[k].projX - 1;
                                if (stage.fieldInfo[tempX, player.projectiles[k].projY] != 0)//허공이 아니면
                                {
                                    if (stage.fieldInfo[tempX, player.projectiles[k].projY] == 1) 
                                    {
                                        stage.fieldInfo[player.projectiles[k].projX, player.projectiles[k].projY] = 0;
                                        player.projectiles[k].isShot = false;
                                    }
                                    else
                                    {
                                        //player.projectiles[k].isShot = false;
                                        stage.fieldInfo[player.projectiles[k].projX, player.projectiles[k].projY] = 0;
                                        player.projectiles[k].projX -= 1;
                                    }
                                    continue;
                                }
                                else//아닐경우
                                {
                                    stage.fieldInfo[player.projectiles[k].projX, player.projectiles[k].projY] = 0;
                                    player.projectiles[k].projX -= 1;

                                }
                            }
                        }
                        else
                        {
                            for (int i = 0; i < player.projectiles[k].Speed; i++)
                            {
                                int tempX = player.projectiles[k].projX + 1;
                                if (stage.fieldInfo[tempX, player.projectiles[k].projY] != 0)//무언가에 부딫히면
                                {
                                    if (stage.fieldInfo[tempX, player.projectiles[k].projY] == 1) 
                                    {
                                        stage.fieldInfo[player.projectiles[k].projX, player.projectiles[k].projY] = 0;
                                        player.projectiles[k].isShot = false;
                                    }
                                    else
                                    {

                                        //player.projectiles[k].isShot = false;
                                        stage.fieldInfo[player.projectiles[k].projX, player.projectiles[k].projY] = 0;
                                        player.projectiles[k].projX += 1;
                                    }
                                        continue;
                                }
                                else//아닐경우
                                {
                                    stage.fieldInfo[player.projectiles[k].projX, player.projectiles[k].projY] = 0;
                                    player.projectiles[k].projX += 1;
                                }
                            }

                        }
                    }
                }

                foreach (Monster monster in stage.monsters)// 몬스터 투사체 업데이트 -> 몬스터 투사체가 설정이 재대로 안됨 이부분 고치면 될듯
                {
                    for (int k = 0; k < monster.projectiles.Length; k++)
                    {
                        if (monster.projectiles[k].isShot)//투사체가 발사중이라면
                        {
                           // Console.WriteLine("몬스터 투사체 발사중");
                            if (monster.projectiles[k].IsShotLeft)//왼쪽으로 날아가는 중이면
                            {
                                Console.WriteLine("왼쪽으로 발사");
                                for (int i = 0; i < monster.projectiles[k].Speed; i++)
                                {
                                    Console.WriteLine("반복1");
                                    int tempX = monster.projectiles[k].projX - 1;
                                    if (stage.fieldInfo[tempX, monster.projectiles[k].projY] != 0)//허공이 아니면
                                    {
                                        Console.WriteLine("경로 방해");

                                        if (stage.fieldInfo[tempX, monster.projectiles[k].projY] == 1) 
                                        {
                                            Console.WriteLine("벽에 만남");
                                            stage.fieldInfo[monster.projectiles[k].projX, monster.projectiles[k].projY] = 0;
                                            monster.projectiles[k].isShot = false;
                                        }
                                        else
                                        {
                                            Console.WriteLine("벽이 아님");
                                            // monster.projectiles[k].isShot = false;
                                            stage.fieldInfo[monster.projectiles[k].projX, monster.projectiles[k].projY] = 0;
                                            monster.projectiles[k].projX -= 1;
                                        }
                                        continue;
                                    }
                                    else//아닐경우
                                    {
                                        Console.WriteLine("경로 방해 없음");
                                        stage.fieldInfo[monster.projectiles[k].projX, monster.projectiles[k].projY] = 0;
                                        monster.projectiles[k].projX -= 1;

                                    }
                                }
                            }
                            else//오른쪽으로 날아가는 중이면
                            {
                                for (int i = 0; i < monster.projectiles[k].Speed; i++)
                                {
                                    int tempX = monster.projectiles[k].projX + monster.projectiles[k].Speed;
                                    if (stage.fieldInfo[tempX, player.projectiles[k].projY] != 0)//벽에 부딫히면
                                    {
                                        if (stage.fieldInfo[tempX, monster.projectiles[k].projY] == 1) 
                                        {
                                            stage.fieldInfo[monster.projectiles[k].projX, monster.projectiles[k].projY] = 0;
                                            monster.projectiles[k].isShot = false;
                                        }
                                        else
                                        {
                                            //monster.projectiles[k].isShot = false;
                                            stage.fieldInfo[monster.projectiles[k].projX, monster.projectiles[k].projY] = 0;
                                            monster.projectiles[k].projX += 1;
                                        }
                                        continue;
                                    }
                                    else//아닐경우
                                    {
                                        stage.fieldInfo[monster.projectiles[k].projX, monster.projectiles[k].projY] = 0;
                                        monster.projectiles[k].projX += 1;
                                        Console.WriteLine(monster.projectiles[k].projX);
                                        Console.WriteLine("몬스터 공격");
                                    }
                                }
                            }

                        }
                    
                    }
                }
            }

                SetPlayerPositionToField(stage, player);
                isHit(stage, player);//맞았는지 확인 및 체력이 전부 단 몬스터 제거
                
            
                foreach (var proj in player.projectiles)
                {
                    if (proj.isShot)
                    {
                        stage.fieldInfo[proj.projX, proj.projY] = 3;
                    }
                }
                foreach (var monster in stage.monsters)
                {
                    foreach (var proj in monster.projectiles)
                    {
                        if (proj.isShot)
                        {
                        Console.WriteLine("몬스터 투사체 표시");
                            stage.fieldInfo[proj.projX, proj.projY] = 6;
                        }
                    }
                }
            SetMonsterPositionToField(stage);
            stage.DrawMap();

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



            




        }//update end

        public void isHit(Stage stage, Player player)//업데이트에 호출되어 플레이어나 몬스터가 맞았는지 표현
        {
            foreach (var monster in stage.monsters)//몬스터가 맞았는지 확인 
            {
                foreach (var proj in player.projectiles) 
                {
                    if (monster.monsterX == proj.projX&&monster.monsterY==proj.projY) 
                    {
                        if (proj.isShot)
                        {
                            //Console.WriteLine("몬스터가 맞음");
                            monster.MonsterHit(proj);
                            proj.isShot = false;
                        }
                    }
                }
            }
            MonsterDead(stage);
            foreach (var monster in stage.monsters)//플레이어가 맞았는지 확인
            {
                foreach (var proj in monster.projectiles)//monster projectiles
                {
                    if (player.playerX==proj.projX&&player.playerY==proj.projY)
                    {
                        if (proj.isShot)
                        {
                            player.PlayerHit(proj);
                            //Console.WriteLine(player.PlayerStatus.HP);
                            proj.isShot = false;
                            return;
                        }
                    }
                }
            }




        }

        public void MonsterDead(Stage stage)// 몬스터 죽었는지 확인
        {
            //var monsters = new List<Monster>(stage.monsters);
            //monsters = stage.monsters;

            foreach (var monster in new List<Monster>(stage.monsters))
            {
                if (monster.MonsterStatus.HP <= 0)
                {
                    stage.fieldInfo[monster.monsterX, monster.monsterY] = 0;
                    stage.monsters.Remove(monster);
                    Console.WriteLine("몬스터 제거");
                    Console.WriteLine(monster.monsterX);
                    Console.WriteLine(monster.monsterY);
                }
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
            //몬스터 설정
            Monster normalMonster = new Monster("슬라임", 2, 0, 1,1,1);// 이거 객체 하나만 생성임 addmonster함수에서 별도 생성및 할당 넣기
            normalMonster.MonsterProjectile = new Projectile(1, 1, 0);
            //normalMonster.AddProjectiles(1, 1);
            Monster normalMonster2 = new Monster("#", 3, 2, 1,1,2);
            normalMonster.MonsterProjectile = new Projectile(2, 1, 0);
            //몬스터 설정
            //스테이지 설정
            Stage shop1 = new ShopStage();
            SetShopItem((shop1 as ShopStage), items);

            Stage battle1 = new NormalStage();
            Stage battle2 = new NormalStage();
            Stage battle3 = new NormalStage();
            Stage battle4 = new NormalStage();

            battle1.AddMonster(normalMonster);//1은 튜토리얼 스테이지로 조작법을 맵 위에 뛰울 예정, set커서로 배경그리고 커서 이동시켜서 조작법 출력하면 될듯
            battle1.monsters[0].SetMonsterXY(35, 25);
           // battle1.monsters[0].projectiles[0].Speed = 1;

            
            SetMosterAtStage(battle2 as NormalStage, normalMonster, normalMonster2);//전투 스테이지에 몬스터 배정 
            SetMosterAtStage(battle3 as NormalStage, normalMonster, normalMonster2);//이하동일
            SetMosterAtStage(battle4 as NormalStage, normalMonster, normalMonster2);//동일
            SetBaseField(battle1);
            SetBaseField(battle2);
            SetBaseField(battle3);
            SetBaseField(battle4);

            Stage Boss1 = new BossStage();
            Stage Boss2 = new BossStage();

            //스테이지설정


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


            player.playerX = 1;
            player.playerY = 27; 
            //
            Program.stopwatch.Start();
            Program.monsterAttackTimer.Start();
            while (Program.isGameRunning) 
            {
                if (player.PlayerStatus.HP <= 0)
                {
                    Program.isGameRunning = false;
                }
                if (Console.KeyAvailable)
                {//키가 눌렸을 때 이동, 중력 작용, 공격기능, 메뉴 열기, 스페이스바 공격 w 위로 점프 a왼쪽 d오른쪽 s 아무것도 없음 q 종료 e 인벤토리 열기 및 일시정지
                    inputKey = Console.ReadKey();
                    DetectKey(inputKey, nowMapNode.stage, player);
                    Console.WriteLine("키 인식");//debug

                }

                //if (Program.jumpCount > 0&&nowMapNode.stage.fieldInfo[player.playerX,player.playerY+1]==0) //이거 업데이트에 넣자
                //{
                //    player.playerY += 1;
                //    SetPlayerPositionToField(nowMapNode.stage, player);
                //    Program.jumpCount--;
                //}else if(Program.jumpCount > 0 && nowMapNode.stage.fieldInfo[player.playerX, player.playerY + 1] != 0)//벽또는 몬스터가 있으면 점프 불가
                //{
                //    Program.jumpCount--;
                //}
                if (Program.monsterAttackTimer.ElapsedMilliseconds > 1000)
                {
                    foreach (var monster in nowMapNode.stage.monsters)
                    {

                        monster.MonsterAttack();
                    }
                }
                if (Program.stopwatch.ElapsedMilliseconds > 100)//일정시간마다 업데이트
                {
                    Update(nowMapNode.stage,player);//업데이트
                    Console.WriteLine("시간 지남");//debug
                    Program.stopwatch.Restart();
                }
                if (nowMapNode.stage.isStageEnd())
                {
                    WorldMap<Stage>.NextStageSelect(nowMapNode);
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
