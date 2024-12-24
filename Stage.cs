using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weekproject
{
    internal class Stage
    {
        protected string _stageName;
        protected int[,] _fieldInfo = new int[50, 50];
        protected List<Monster> _monsters;
        protected List<Projectile> _projects;
        
        public Stage()
        {
            _monsters = new List<Monster>();

        }
        public string stageName
        {
            get { return _stageName; }
            set { _stageName = value; }
        }
        public int[,] fieldInfo
        {
            get { return _fieldInfo; }
            set { _fieldInfo = value; }
        }


        public void AddMonster(Monster monster)
        {
            _monsters.Add(monster);
        }
        public void RemoveMonster(int index)
        {
            _monsters.RemoveAt(index);
        }
        public virtual bool isStageEnd()
        {
            return false;
        }
    }
}
