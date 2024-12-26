using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weekproject
{
    class NormalStage:Stage,IMapDrawing
    {
        int _rewardGold;
        public int rewardGold
        {
            get { return _rewardGold; }
            set { _rewardGold = value; }
        }
       //public override void DrawMap()//x,y가 일반적인 좌표처럼 작동!// 보스랑 노말은 굳이 별도로 필요 없을지도?
       //{
       //   // Console.WriteLine("일반출력");
       //    for (int i = _fieldInfo.GetLength(0)-1; i >=0 ; i-- )
       //    {
       //        for (int j = 0;j<_fieldInfo.GetLength(1); j++) 
       //        {
       //            switch (_fieldInfo[j, i]) 
       //            {
       //                case 0://빈칸
       //                    Console.WriteLine(" ");
       //                    break;
       //                case 1: //벽
       //                    Console.WriteLine("■");
       //                    break;
       //                case 2://플레이어
       //                    Console.WriteLine("☆");
       //                    break;
       //                case 3://플레이어의 투사체
       //                    Console.WriteLine("○");
       //                    break;
       //                case 4://몬스터1
       //                    Console.WriteLine("♣");
       //                    break;
       //                case 5://몬스터2
       //                    Console.WriteLine("♧");
       //                    break;
       //                case 6://몬스터 및 보스의 투사체
       //                    Console.WriteLine("●");
       //                    break;
       //                case 7://보스 몸
       //                    Console.WriteLine("＃");
       //                    break;
       //
       //            }
       //
       //        }
       //    }
       //}

        public override bool isStageEnd()
        {
            if (_monsters == null)
            {
                return true;
            }else
            {
                return false;
            }
        }

        public void EndOfStage(Player player)
        {
            player.Inventory.getGold += _rewardGold;
        }
        public void SetRewardGold()
        {
            _rewardGold = Program.random.Next(500, 1001);
        }

    }//end
}
