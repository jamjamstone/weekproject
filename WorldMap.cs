using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weekproject
{
    class MapNode
    {
        Stage _stage;
        List<MapNode> _nodes;
        public MapNode()
        {
            _stage = new Stage();   
            _nodes = new List<MapNode>();
        }
        public MapNode(Stage stage):this()
        {
            _stage= stage;
            
        }
        
        


    }
    internal class WorldMap
    {
        MapNode _startStage;
        public void AddNode(Stage stage,int num,int layer)
        {
            MapNode current = _startStage;

        }
        public void RemoveNode()
        {

        }

    }
}
