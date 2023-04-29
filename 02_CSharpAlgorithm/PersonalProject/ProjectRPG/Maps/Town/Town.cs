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

        public Town(Player _player) : base(_player)
        {
            name = "마을";
            clinic = new Clinic(player);
            home = new Home(player);
            market = new Market(player);
            tavern = new Tavern(player);
        }

        protected override void ShowSites()
        {
            for(int j = 1; j < 10; j++)
            {
                for (int i = 1; i < 59; i++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write(" ");
                }
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
                        home.GetIn();
                        ShowUI();
                        break;
                    case 1:
                        tavern.GetIn();
                        ShowUI();
                        break;
                    case 2:
                        clinic.GetIn();
                        ShowUI();
                        break;
                    case 3:
                        market.GetIn();
                        ShowUI();
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
