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
        public void DrawMap()
        {
            for (int i = 0; i < _fieldInfo.Length; i++ )
            {
                for (int j = _fieldInfo.GetLength(1);j>=0; j--) 
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

        }


    }//end
}
