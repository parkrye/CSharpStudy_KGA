namespace ProjectRPG
{
    /// <summary>
    /// 마을에 대한 클래스
    /// </summary>
    internal class Town : TownSite
    {
        Clinic clinic;
        Home home;
        Market market;
        Tavern tavern;

        public Town()
        {
            name = "마을";
            clinic = new Clinic();
            home = new Home();
            market = new Market();
            tavern = new Tavern();

            cursor = 0;
            outSite = false;
            goSite = false;
        }

        public override void GetIn()
        {
            while(!outSite)
            {
                ShowSites();
                GetCursor();
                MoveSite();
            }
        }

        void ShowSites()
        {
            Console.Clear();

            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("[마을]");
            if (cursor == 0)
                Console.ForegroundColor = ConsoleColor.Green;
            else
                Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"[{home.NAME}]");
            if (cursor == 1)
                Console.ForegroundColor = ConsoleColor.Green;
            else
                Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"[{tavern.NAME}]");
            if (cursor == 2)
                Console.ForegroundColor = ConsoleColor.Green;
            else
                Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"[{clinic.NAME}]");
            if (cursor == 3)
                Console.ForegroundColor = ConsoleColor.Green;
            else
                Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"[{market.NAME}]");
            if (cursor == 4)
                Console.ForegroundColor = ConsoleColor.Green;
            else
                Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("[마을 나가기]");
        }

        int GetCursor()
        {
            int key = Input();
            switch (key)
            {
                case 1:
                case 3:
                    cursor--;
                    if (cursor < 0)
                        cursor = 4;
                    break;
                case 2:
                case 4:
                    cursor++;
                    if (cursor > 4)
                        cursor = 0;
                    break;
                case 5:
                    goSite = true;
                    break;
            }
            return cursor;
        }

        void MoveSite()
        {
            if (goSite)
            {
                switch (cursor)
                {
                    case 0:
                        home.GetIn();
                        break;
                    case 1:
                        tavern.GetIn();
                        break;
                    case 2:
                        clinic.GetIn();
                        break;
                    case 3:
                        market.GetIn();
                        break;
                    case 4:
                        outSite = true;
                        break;
                }
                goSite = false;
            }
        }

        /// <summary>
        /// 입력 처리
        /// </summary>
        /// <returns>입력 종류</returns>
        int Input()
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
