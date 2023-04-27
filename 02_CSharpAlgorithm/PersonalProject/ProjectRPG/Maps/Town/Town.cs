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

        public Town() : base()
        {
            name = "마을";
            clinic = new Clinic();
            home = new Home();
            market = new Market();
            tavern = new Tavern();
        }

        protected override void ShowSites()
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

            Console.SetCursorPosition(25, 1);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"[{name}]");

            Console.SetCursorPosition(10, 4);
            if (cursor == 0)
                Console.ForegroundColor = ConsoleColor.Green;
            else
                Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"[{home.NAME}]");

            Console.SetCursorPosition(10, 5);
            if (cursor == 1)
                Console.ForegroundColor = ConsoleColor.Green;
            else
                Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"[{tavern.NAME}]");

            Console.SetCursorPosition(10, 6);
            if (cursor == 2)
                Console.ForegroundColor = ConsoleColor.Green;
            else
                Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"[{clinic.NAME}]");

            Console.SetCursorPosition(10, 7);
            if (cursor == 3)
                Console.ForegroundColor = ConsoleColor.Green;
            else
                Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"[{market.NAME}]");

            Console.SetCursorPosition(40, 9);
            if (cursor == 4)
                Console.ForegroundColor = ConsoleColor.Green;
            else
                Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"[{name} 나가기]");
        }

        protected override void GetCursor()
        {
            switch (InputManager.GetInput())
            {
                default:
                    break;
                case Key.LEFT:
                case Key.UP:
                    cursor--;
                    if (cursor < 0)
                        cursor = 4;
                    break;
                case Key.RIGHT:
                case Key.DOWN:
                    cursor++;
                    if (cursor > 4)
                        cursor = 0;
                    break;
                case Key.ENTER:
                    goSite = true;
                    break;
                case Key.CANEL:
                    outSite = true;
                    break;
            }
        }

        protected override void ClickCursor()
        {
            if (goSite)
            {
                switch (cursor)
                {
                    case 0:
                        home.GetIn(player);
                        break;
                    case 1:
                        tavern.GetIn(player);
                        break;
                    case 2:
                        clinic.GetIn(player);
                        break;
                    case 3:
                        market.GetIn(player);
                        break;
                    case 4:
                        outSite = true;
                        break;
                }
                goSite = false;
            }
        }
    }
}
