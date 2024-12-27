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

        List<MapNode<T>> _nodes;
        public MapNode()
        {
            _stage = new T();
            _nodes = new List<MapNode<T>>();
        }
        public MapNode(T stage) : this()
        {
            _stage = stage;


        }
        public List<MapNode<T>> Nodes
        {
            get { return _nodes; }
            set { _nodes = value; }
        }
        //public int level
        //{
        //    get { return _level; }
        //    set { _level = value; }
        //}
        public T stage
        {
            get { return _stage; }
            set { _stage = value; }
        }




    }
    class WorldMap<T> where T : class, new()
    {
        MapNode<T> _startStage;
        List<MapNode<T>> _nodes;

        public List<MapNode<T>> nodes
        {
            get { return _nodes; }
            set { _nodes = value; }
        }
        public MapNode<T> StartStage
        {
            get { return _startStage; }
            set { _startStage = value; }
        }
        public WorldMap()
        {
            _nodes = new List<MapNode<T>>();
            //_startStage = new MapNode<T>();
        }
        //public void AddNode(T stage, int layer)//구현완 테스트x
        //{
        //    int countLayer = 0;
        //    if (_startStage == null)
        //    {
        //        _startStage = new MapNode<T>(stage, 0);
        //
        //
        //    }
        //    else
        //    {
        //        MapNode<T> current = _startStage;
        //        while (countLayer < layer-1)
        //        {
        //            
        //            current = current?.Nodes[Program.random.Next(0, current.Nodes.Count)];
        //        }
        //        if (current.Nodes.Count <= 0)
        //        {
        //            current.Nodes.Add(new MapNode<T>(stage, countLayer));
        //        }
        //        else
        //        {
        //            current.Nodes[Program.random.Next(0, current.Nodes.Count)] = new MapNode<T>(stage, layer);//에러
        //        }
        //    }
        //    
        //
        //}

        public void AddNode(MapNode<T> addMapNode)
        {
            _nodes.Add(addMapNode);
            if (_startStage == null)
            {
                Console.WriteLine("1스테이지 설정");
                _startStage = addMapNode;
            }
            //_startStage.Nodes.Add(addMapNode);
        }
        public void SetTreeLine(MapNode<T> upper, MapNode<T> down)
        {
            upper.Nodes.Add(down);
        }

        //public void RemoveNode(MapNode<T> node) // 구현중....인데 이거 필요함? 기능에는 없어도 될거 같은데
        //{
        //    Stack<MapNode<T>> visitedNode = new Stack<MapNode<T>>();
        //    MapNode<T> current = _startStage;
        //    while (current != node)
        //    {
        //        visitedNode.Push(current);
        //        for (int i = 0; i < current.Nodes.Count; i++)
        //        {
        //            if (current.Nodes[i] == node)
        //            {
        //                current = current.Nodes[i];
        //
        //                break;
        //            }
        //        }
        //
        //
        //
        //    }
        //}


        public void ShowWorldMapPartial(MapNode<T> currentmap)
        {
            for (int i = 0; i < currentmap.Nodes.Count; ++i)
            {

            }
        }


        public void NextStageSelect(ref MapNode<T> nowStage, Player player)
        {
            Program.monsterAttackTimer.Stop();
            Program.stopwatch.Stop();
            // Program.isStageChange = true;
            int countIndex = 0;
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("다음 스테이지를 골라주세요!");
            player.ResetPlayerPosition();
            foreach (MapNode<T> nextStage in nowStage.Nodes)
            {
                Console.WriteLine("반복문 진입");

                if (nextStage != null)
                {
                    if (nextStage.stage is ShopStage)
                    {
                        Console.WriteLine($"{countIndex + 1}. 상점");
                        countIndex++;
                    }
                    else if (nextStage.stage is NormalStage)
                    {
                        Console.WriteLine($"{countIndex + 1}. 전투");
                        countIndex++;
                    }
                    else if (nextStage.stage is BossStage)
                    {
                        Console.WriteLine($"{countIndex + 1}. 보스");
                        countIndex++;
                    }
                }
                else
                {
                    Console.WriteLine("연결된 노드가 없습니다.");
                }
            }
            int inputNum;
            while (true)
            {
                //Console.WriteLine("while문 진입");
                string temp = Console.ReadLine();
               // Console.WriteLine("입력받음");
                if (int.TryParse(temp, out inputNum))
                {
                    if (nowStage.Nodes[inputNum - 1] == null)
                    {
                        continue;
                    }
                    else
                    {
                        nowStage = nowStage.Nodes[inputNum - 1];

                        break;
                    }



                }




            }


        }//worldmap end
    }
}
