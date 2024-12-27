using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weekproject
{
    class BossMonster: Monster
    {
        int[,] _bossPosition = new int[50, 50];
        public int [,] bossPosition
        {
            get {  return _bossPosition; }
            set { _bossPosition = value; }
        }
    }
}
