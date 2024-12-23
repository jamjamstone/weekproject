using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weekproject
{
    internal class Stage
    {
        string _stageName;
        int[,] _fieldInfo;
        List<Monster> _monsters;
        public Stage()
        {
            _monsters = new List<Monster>();

        }
        public string stageName
        {
            get { return _stageName; }
            set { _stageName = value; }
        }

    }
}
