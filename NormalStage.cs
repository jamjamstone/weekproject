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
        public void DrawMap()//x,y가 일반적인 좌표처럼 작동!
        {
            for (int i = _fieldInfo.GetLength(1); i >=0 ; i-- )
            {
                for (int j = 0;j<_fieldInfo.GetLength(0); j++) 
                {
                    switch (_fieldInfo[j, i]) 
                    {
                        case 0:
                            Console.WriteLine();
                            break;
                        case 1:
                            Console.WriteLine();
                            break;
                        case 2:
                            Console.WriteLine();
                            break;
                        case 3:
                            Console.WriteLine();
                            break;


                    }

                }
            }
        }

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


    }//end
}
