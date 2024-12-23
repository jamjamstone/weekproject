using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weekproject
{
    class MapNode<T> where T : class, new()//T에는 stage가 들어갈 예정
    {
        T _stage;
        int _level;
        List<MapNode<T>> _nodes;
        public MapNode()
        {
            _stage = new T();
            _nodes = new List<MapNode<T>>();
        }
        public MapNode(T stage, int level)
        {
            _stage= stage;
            _level = level;
        }
        public List<MapNode<T>> Nodes
        {
            get { return _nodes; }
            set { _nodes = value; }
        }
        public int level
        {
            get { return _level; }
            set { _level = value; }
        }
    
        


    }
     class WorldMap<T> where T : class, new() 
    {
        MapNode<T> _startStage; 


        public WorldMap()
        {
            _startStage = new MapNode<T>();
        }
        public void AddNodeRandom(T stage,int layer)//구현완 테스트x
        {
            if (_startStage == null)
            {
                _startStage=new MapNode<T>( stage, 0 );
               
            }
            MapNode<T> current = _startStage;
            while (current.level < layer)
            {
                int branchNum = Program.random.Next(0, current.Nodes.Count);
                current = current.Nodes[branchNum];
                
            }
            current.Nodes.Add(new MapNode<T>(stage,current.level+1));

        }
        public void RemoveNode(MapNode<T> node) // 구현중
        {
            Stack<MapNode<T>> visitedNode = new Stack<MapNode<T>>();
            MapNode<T> current = _startStage;
            while(current!= node)
            {
                visitedNode.Push(current);
                for (int i = 0; i < current.Nodes.Count; i++) 
                {
                    if (current.Nodes[i] == node)
                    {
                        current = current.Nodes[i];

                        break;
                    }
                }


                
            }
        }

    }
}
