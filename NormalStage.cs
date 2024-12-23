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

        }
    }
}
