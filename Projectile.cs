using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weekproject
{
    internal class Projectile
    {
        int _dmg;
        int _speed;
        int _interval;
        bool _isShotLeft;
        int _projectileX;
        int _projectileY;
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
    }
}
