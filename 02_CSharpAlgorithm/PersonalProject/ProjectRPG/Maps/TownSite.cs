namespace ProjectRPG
{
    internal abstract class TownSite
    {
        protected string name;          // 장소 이름
        protected Player player;        // 플레이어
        protected int cursor;           // 커서
        protected bool outSite, goSite; // 이 장소를 나가는지, 커서의 선택지를 선택하는지

        /// <summary>
        /// 이름에 대한 프로퍼티
        /// </summary>
        public string NAME { get { return name; } }

        /// <summary>
        /// 커서, 나가기, 입장을 초기화하는 생성자
        /// </summary>
        public TownSite(Player _player)
        {
            player = _player;
            cursor = 0;
            outSite = false;
            goSite = false;
        }

        /// <summary>
        /// 해당 장소에 들어가는 메소드
        /// </summary>
        /// <param name="_player">플레이어</param>
        public void GetIn()
        {
            ShowUI();
            while (!outSite)
            {
                ShowSites();
                GetCursor();
                ClickCursor();
            }
            cursor = 0;
            outSite = false;
            Console.Clear();
        }

        protected void ShowUI()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < 60; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("=");
                Console.SetCursorPosition(i, 10);
                Console.Write("=");
            }
            for (int i = 1; i < 10; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("||");
                Console.SetCursorPosition(58, i);
                Console.Write("||");
            }
        }

        /// <summary>
        /// 선택지를 보여주는 메소드
        /// </summary>
        protected abstract void ShowSites();

        /// <summary>
        /// 커서를 이동시키는 메소드
        /// </summary>
        protected abstract void GetCursor();

        /// <summary>
        /// 현재 커서의 선택지를 선택하는 메소드
        /// </summary>
        protected abstract void ClickCursor();
    }
}
