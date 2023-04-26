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

            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"[{name}]");
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
            Console.WriteLine($"[{name} 나가기]");
        }

        protected override void GetCursor()
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
