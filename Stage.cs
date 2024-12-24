using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weekproject
{
    internal class Stage: IMapDrawing
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

        public virtual void DrawMap(/*Stage stage, Player player*/)
        {
            Console.SetCursorPosition(0, 0);
            for (int i = _fieldInfo.GetLength(0) - 1; i >= 0; i--)
            {
                for (int j = 0; j < _fieldInfo.GetLength(1); j++)
                {
                    switch (_fieldInfo[j, i])
                    {
                        case 0://빈칸
                            Console.Write(" ");
                            break;
                        case 1: //벽
                            Console.Write("■");
                            break;
                        case 2://플레이어
                            Console.Write("☆");
                            break;
                        case 3://플레이어의 투사체
                            Console.Write("○");
                            break;
                        case 4://몬스터1
                            Console.Write("♣");
                            break;
                        case 5://몬스터2
                            Console.Write("♧");
                            break;
                        case 6://몬스터 및 보스의 투사체
                            Console.Write("●");
                            break;
                        case 7://보스 몸
                            Console.Write("＃");
                            break;

                    }

                }
                Console.WriteLine();
            }
        }
    }
}
