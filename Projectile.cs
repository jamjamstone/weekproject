using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weekproject
{
    class Projectile
    {
        int _dmg;
        int _speed;
        int _interval;
        bool _isShotLeft;
        int _projectileX;
        int _projectileY;
        public Projectile()
        {

        }
        public Projectile(int dmg, int speed, int interval)
        {
            _dmg = dmg;
            _speed = speed;
            _interval = interval;
        }
        public int projX
        {
            get { return _projectileX; }
            set { _projectileX = value; }
        }
        public int projY
        {
            get { return _projectileY; }
            set { _projectileY = value; }
        }
        public bool IsShotLeft
        {
            get { return _isShotLeft; }
            set { _isShotLeft = value; }
        }
        public int Dmg
        {
            get { return _dmg; }
            set { _dmg = value; }
        }
        public int Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }
        public int Interval
        {
            get { return _interval; }
            set { _interval = value; }
        }

        public virtual void ProjectileShoot()//기본
        {
            if (_isShotLeft) 
            {
                _projectileX -= _speed;


            }
            else
            {
                _projectileX += _speed;
            }
        }
        
        



    }//Projectile End


    class ProjectileWeegle:Projectile
    {
        public override void ProjectileShoot()
        {
            if (IsShotLeft)
            {
                if (Program.isProjectileWeegleUp)//총알이 위로 휠때
                {
                    projX = projX - Speed;
                    projY = projY + Speed;
                }
                else//총알이 아래로 휠때
                {
                    projX = projX - Speed;
                    projY = projY - Speed;
                }
            }
            else
            {
                if (Program.isProjectileWeegleUp)
                {
                    projX = projX + Speed;
                    projY = projY + Speed;
                }
            }
        }
    }




}
