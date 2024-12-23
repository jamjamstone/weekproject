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
        public int rewardGold
        {
            get { return _rewardGold; }
            set { _rewardGold = value; }
        }
        public void DrawMap()
        {

        }
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
