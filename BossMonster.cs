using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace weekproject
{
    class BossMonster: Monster
    {
        int[,] _bossPosition = new int[50, 50];
        protected Projectile[] _projects2;
        public int [,] bossPosition
        {
            get {  return _bossPosition; }
            set { _bossPosition = value; }
        }
        public BossMonster():base()
        {
            _projects2 = new Projectile[10];
            for (int i = 0; i < 10; i++)
            {
                _projects[i] = new Projectile(5,1,0);
                _projects[i].isShot = false;
            }
            for (int i = 0; i < 10; i++)
            {
                _projects2[i] = new Projectile(5, 1, 0);
                _projects2[i].isShot = false;
            }
        }
        public void BossAttack1(Player player)
        {
            int shootCount = 0;
            foreach(Projectile proj in _projects)
            {
                if(!proj.isShot&&shootCount<5)
                {
                    
                    proj.isShot = true;
                    proj.IsShotLeft = true;
                    proj.projX = 37;
                    proj.projY = player.playerY+(shootCount*2);
                }

            }
        }
        public void BossAttack2(Player player) 
        {
            int shootCount = 0;
            foreach (Projectile proj in _projects2)
            {
                if (!proj.isShot && shootCount < 5)
                {

                    proj.isShot = true;
                    proj.IsShotLeft = true;
                    proj.projY = 30;
                    proj.projX= player.playerX + (shootCount * 2);
                }

            }

        }
    }
}
