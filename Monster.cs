using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weekproject
{
    internal class Monster
    {
        string _monsterName;
        Status _monsterStatus;
        Projectile _monsterProjectile;
        public string MonsterName
        {
            get { return _monsterName; }
            set { _monsterName = value; }
        }
        public Status MonsterStatus
        {
            get { return _monsterStatus; }
            set { _monsterStatus = value; }
        }
        public Projectile MonsterProjectile
        {
            get { return _monsterProjectile; }
            set { _monsterProjectile = value; }
        }
        virtual public void MonsterAttack()
        {

        }
    }
}
