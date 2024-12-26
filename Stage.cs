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
        //protected List<Projectile> _projects;
        public List<Monster> monsters
        {
            get {  return _monsters; }
            set { _monsters = value; }
        }
        //public List<Projectile> projectiles
        //{
        //    get { return _projects; }
        //    set { _projects = value; }
        //}
        public Stage()
        {
            _monsters = new List<Monster>();
           // _projects = new List<Projectile>(10);
           // for (int i = 0; i < 10; i++)
           // {
           //     _projects[i] = new Projectile();
           //     _projects[i].isShot = false;
           // }


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


        public void AddMonster(Monster monster )
        {
            
            Monster addMonster = new Monster(monster.MonsterName,monster.MonsterStatus.HP, monster.MonsterStatus.def, monster.MonsterStatus.ATK, monster.MonsterProjectile.Speed,monster.MonsterProjectile.Dmg);
            _monsters.Add(addMonster);

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
                            Console.Write("  ");
                            break;
                        case 1: //벽
                            Console.Write("■");
                            break;
                        case 2://플레이어
                            Console.Write("☆");
                            break;
                        case 3://플레이어의 투사체->별도 함수로 덮어 씌울 예정 필요 없을지도?
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
