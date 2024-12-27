using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weekproject
{
    class BossStage:Stage,IMapDrawing
    {
        int _rewardGold;
        Item _rewardItem;
        Monster _bossMonster;
        public Monster BossMonster
        {
            get { return _bossMonster; }
            set { _bossMonster = value; }
        }
        public int rewardGold
        {
            get { return _rewardGold; }
            set { _rewardGold = value; }
        }
       // public override void DrawMap()// 보스랑 노말스테이지는 굳이 필요 없을지도?
       // {
       //     for (int i = _fieldInfo.GetLength(0)-1; i >= 0; i--)
       //     {
       //         for (int j = 0; j < _fieldInfo.GetLength(1); j++)
       //         {
       //             switch (_fieldInfo[j, i])
       //             {
       //                 case 0://빈칸
       //                     Console.WriteLine(" ");
       //                     break;
       //                 case 1: //벽
       //                     Console.WriteLine("■");
       //                     break;
       //                 case 2://플레이어
       //                     Console.WriteLine("☆");
       //                     break;
       //                 case 3://플레이어의 투사체
       //                     Console.WriteLine("○");
       //                     break;
       //                 case 4://몬스터1
       //                     Console.WriteLine("♣");
       //                     break;
       //                 case 5://몬스터2
       //                     Console.WriteLine("♧");
       //                     break;
       //                 case 6://몬스터 및 보스의 투사체
       //                     Console.WriteLine("●");
       //                     break;
       //                 case 7://보스 몸
       //                     Console.WriteLine("＃");
       //                     break;
       //
       //             }
       //
       //         }
       //     }
       // }
        public override bool isStageEnd()
        {
            if (_monsters == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void EndOfStage(Player player)
        {
            Console.WriteLine("보스를 쓰러트렸습니다!");
            Console.WriteLine("축하합니다!");
            
            player.PlayerAddItemToInventory(_rewardItem);
            player.PlayerAddGoldToInventory(_rewardGold);
        }

    }//end
}
