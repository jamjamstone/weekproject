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
        protected Projectile[] _projects;

        protected Status _monsterStatus;
        protected Projectile _monsterProjectile;
        public Monster()
        {
            _monsterStatus = new Status();
            _monsterProjectile = new Projectile();
            _projects = new Projectile[10];
            for (int i = 0; i < 10; i++)
            {
                _projects[i] = new Projectile();
                _projects[i].isShot = false;
            }
        }
        public Monster(string name, int hp, int def, int atk, int projspeed, int projdmg):this()
        {
            _monsterName = name;
            _monsterStatus.def = def;
            _monsterStatus.HP = hp;
            _monsterStatus.ATK = atk;
            _monsterProjectile = new Projectile(projdmg,projspeed,0);
            foreach (Projectile p in _projects)
            {
                p.Dmg = projdmg;
                p.Speed = projspeed;
            }
        }
        public Projectile[] projectiles
        {
            get { return _projects; }
            set { _projects = value; }
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
            foreach (Projectile p in _projects)
            {
                if (p.isShot==false)
                {
                    p.isShot = true;
                    p.IsShotLeft = true;
                    p.projX = _monsterX;
                    p.projY = _monsterY;
                    break;
                    Console.WriteLine("나오면 안됨");
                }
            }
           
        }

        public void MonsterHit(Projectile proj,Player player)
        {
            _monsterStatus.HP = _monsterStatus.HP - (proj.Dmg+player.PlayerStatus.ATK - _monsterStatus.def);
        }

        public void SetMonsterXY(int x, int y)
        {
            _monsterX = x;
            _monsterY = y;
        }
        public void AddProjectiles(int dmg,int speed)//생각중
        {
            foreach (Projectile p in _projects)
            {
                p.Dmg = dmg;
                p.Speed = speed;
            }
        }
    }
}
