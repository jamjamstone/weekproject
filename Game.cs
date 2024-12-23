using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weekproject
{
    partial class Game
    {
        

        public void Update(Stage stage)
        {

        }

        public void Play()
        {
            ConsoleKeyInfo inputKey;
            Stopwatch stopwatch = Stopwatch.StartNew();
            Player player = new Player();









            //
            stopwatch.Start();
            while (true) 
            {
                inputKey = Console.ReadKey();
                if (Console.KeyAvailable)
                {//키가 눌렸을 때 이동, 중력 작용, 공격기능, 메뉴 열기, 스페이스바 공격 w 위로 점프 a왼쪽 d오른쪽 s 아무것도 없음 q 종료 e 인벤토리 열기 및 일시정지
                    switch (inputKey.Key) 
                    {
                        case ConsoleKey.Q:
                            Console.WriteLine("게임 종료!");
                            return;
                        case ConsoleKey.W:
                            player.Jump();
                            break;
                        case ConsoleKey.A:
                            player.Move("left");
                            break;
                        case ConsoleKey.D:
                            player.Move("right");
                            break;
                        case ConsoleKey.E:
                            player.Inventory.ShowInventory();
                            stopwatch.Stop();
                            break;
                        default:
                            break;


                    }
 
                }

                if (stopwatch.ElapsedMilliseconds > 200)
                {

                }

                //아닐때 중력 작용
                //일정 시간마다 몬스터 공격
                //보스는 패턴 존재




            }




























            //


        }


    }//end
}
