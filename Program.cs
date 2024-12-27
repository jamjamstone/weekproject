﻿using System.Diagnostics;

namespace weekproject
{

    /// <summary>
    /// projectile을 이용한 전투 시스템, 무작위 맵 생성 및 월드맵 할당 시스템, 이렇게 2개가 중요한 코드
    /// 투사체 객체를 생성하는 식으로 투사체를 생성할 지
    /// 전투 시스템까진 구현 완료
    /// 구현해야 할 시스템은 이제 월드맵 시스템
    /// 무한 점프 시스템 -> 고쳤다! 점프 카운트는 최대치에 올라가면 0이 되므로 공중에서 w키를 누르면 계속해서 점프카운트가 보충된다!
    /// 상점으로 넘어가야 하는데 자꾸 노말 스테이지가 실행됨 이걸 막아야 함
    /// 2번몹은 공격을 안함-> 2번몹 투사체 스피드가 0으로 설정되있음!
    /// 
    /// </summary>
    internal class Program
    {
        public static int stageAddCount = 0;
        public static bool isStageChange = false;
        public static Stopwatch monsterAttackTimer = new Stopwatch();
        public static int jumpCount = 0;
        public static bool isGameRunning = true;
        public static Stopwatch stopwatch = Stopwatch.StartNew();
        public static bool isProjectileWeegleUp = false;
        public static Random random = new Random();
        public static string merchant = "@@@@@@@@@@@%%##*###%@@%%@#%%%@@@@%@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@%%##*****=:....:+###%%%%@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@%%#**+-:........:*######%@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@#*+=-==--:=-..:::=#####%%@@@@@@@@@@@@\r\n@@@@@@@@@@@@@%*=:+*#%@%**#*+=--+#%%%%@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@%*==*#@@@%###%@#+--+#%@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@%*==#@@@@@#***#@@#=--*%@@@@@@@@@@@@@@@\r\n@@@@@@@@@@%%*==+#%@@%#%%%#%%@%#+--*@@@@@@@@@@@@@@@\r\n@@@@@@@@%%##+-=+#@@@@%@#@%%@@@%%*-+%@@@@@@@@@@@@@@\r\n@@@@@@@%###+:+%@@@@@@@@*%#%@@@@@#++*%@@@@@@@@@@@@@\r\n@@@@@@@%%#+%**#%@@@@#%@@@@*#%@@@%@#*+#@@@@@@@@@%@@\r\n@@@@@%%#%@#%@%@@@@@%####**+*#@@@%+**@@%%@@@@@@@@@@\r\n#%@@@@%#%@@@@@@@@@%#***%%++**%@@@##@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@%%*++##=*##%@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@#****#+**##@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@%@@@@@@@@@@@%#*++#+**%%@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@#*++##+=##%@@@@@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@%%#+*#*+#%@@@@@@@@@%%@@@@@@@@@@\r\n@@@@@@@@@@@@@@@@@@@@%*##***%%@@@@@@@@@@@@@%%@@@@@@\r\n@@@@@@@@@@@@@@@@@@@###%%#+#%@@@@@@@@@@@@@@@@@@@@@@\r\n@@@%###%@@%%*@@@@@@@@%%%*#%%@@@@@@@@@@@@@@#*@@@@@@\r\n@@@@@@@%=+#*@@@@@@@@@@@@%#%@@@@@@@@@@@@#*:-+%@@@@@\r\n@@@@@%#%****@@@@@@@@@@@@@@@@@@@%%@@@@@%#==+#%@@@@@\r\n@@@@@@@++++#@@@@@@@@@@%##*%@@@@@@@@@@%##+*=-+@@@@@\r\n@@@@@@@@#+#%%@@@@@%###****#%@@@@@@@%%@@%=++#@@@@@@\r\n@@@@@@@%#%%%@@@@#*#+:::::::+#@@@@@@@@@@@%=*@@@@@@@\r\n@@@@@@@@@@@@@@@%#+----===-:::+*#@@@@@@%#%%%@@@@@@@\r\n@@@@@@@@@@@@@%**=-.::::.::-:.:=+*%@@@@@@@@@@@@@@@@\r\n@@@@@@@@@@%%%#**+-.:--:.:--..:-=****#%@@@@@@@@@@@@\r\n@@@@@@@%@%%#+====-...:::--:..:-=+##*#**#%@@@@@@@@@\r\n@@@@@@@##%#*+++=+=-:.......:---=+####*##%@%%#%@@@@\r\n@@@@@@@@@@%####*##++=:::.:-+****#**###%%%%%%%@@@@@";
        static void Main(string[] args)
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            
            Game game = new Game();
            game.Play();
            //Console.SetWindowPosition(5,5);
            //ShopStage shopstage = new ShopStage();//디버그용
            //shopstage.DrawMap();//디버그용
            
        }
    }
}
