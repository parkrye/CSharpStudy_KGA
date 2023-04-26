namespace ProjectRPG
{
    internal abstract class TownSite
    {
        protected string name;
        protected Player player;
        protected int cursor;
        protected bool outSite, goSite;

        public string NAME { get { return name; } }

        /// <summary>
        /// 커서, 나가기, 입장을 초기화하는 생성자
        /// </summary>
        public TownSite()
        {
            cursor = 0;
            outSite = false;
            goSite = false;
        }

        public void GetIn(Player _player)
        {
            player = _player;
            while (!outSite)
            {
                ShowSites();
                GetCursor();
                ClickCursor();
            }
            cursor = 0;
            outSite = false;
        }

        protected abstract void ShowSites();
        protected abstract void GetCursor();
        protected abstract void ClickCursor();

        /// <summary>
        /// 입력 처리
        /// </summary>
        /// <returns>입력 종류</returns>
        protected int Input()
        {
            switch (InputManager.GetInput())
            {
                default:
                case Key.NONE:
                    return 0;
                case Key.LEFT:
                    return 1;
                case Key.RIGHT:
                    return 2;
                case Key.UP:
                    return 3;
                case Key.DOWN:
                    return 4;
                case Key.ENTER:
                    return 5;
                case Key.CANEL:
                    return 6;
            }
        }
    }
}
