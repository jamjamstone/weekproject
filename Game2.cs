using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weekproject
{
    partial class Game
    {

        public Game()//생성자로 사용할 몬스터, 아이템, 스테이지, 보스 객체 생성
        {
            Item redSword = new Item("빨강검",300);
            redSword.status.HP = 0;
            redSword.status.def = -1;
            redSword.status.ATK = 2;
            redSword.description = "붉은 검 방어를 대가로 높은 공격력을 얻는다.";
            Item sling = new ItemChangeProj(1,2,1);
            sling.status.HP = 0;
            sling.status.def = -1;
            sling
            //아이템 대강 5종류?
            //몬스터 3종류
            //보스 2종류
            //스테이지 3종류 여러개
            //발사체도 여러개 만들기




        }
    }
}
