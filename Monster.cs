using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weekproject
{
    internal class Monster
    {
        protected string _monsterName;
        protected int _monsterX;
        protected int _monsterY;
        
        protected Status _monsterStatus;
        protected Projectile _monsterProjectile = new Projectile();
        public Monster()
        {
            _monsterStatus = new Status();
            _monsterProjectile = new Projectile();  
        }
        public Monster(string name, int hp, int def, int atk)
        {
            _monsterName = name;
            _monsterStatus = new Status();
            _monsterStatus.def = def;
            _monsterStatus.HP = hp;
            _monsterStatus.ATK = atk;
        }
        public int monsterX
        {
            get { return _monsterX; }
            set { _monsterX = value; }
        }
        public int monsterY
        {
            get { return _monsterY; }
            set { _monsterY = value; }
        }
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
            //_monsterProjectile.ProjectileShoot();
        }

        public void MonsterHit(Projectile proj)
        {
            _monsterStatus.HP = _monsterStatus.HP - (proj.Dmg - _monsterStatus.def);
        }


    }
}
