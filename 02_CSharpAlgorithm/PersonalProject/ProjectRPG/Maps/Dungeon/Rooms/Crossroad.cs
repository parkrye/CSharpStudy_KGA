namespace ProjectRPG
{
    internal class Crossroad : DungeonRoom
    {
        bool isReturn;

        public Crossroad(Player player, Party enemy, Item item) : base(player, enemy, item)
        {
            name = "갈림길";
        }

        protected override void ShowContent()
        {
            Console.SetCursorPosition(16, 4);
            if(cursor == 0)
                Console.ForegroundColor = ConsoleColor.Green;
            else
                Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[휴식하기]");

            Console.SetCursorPosition(34, 4);
            if (cursor == 1)
                Console.ForegroundColor = ConsoleColor.Green;
            else
                Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[돌아가기]");
        }

        protected override void MoveCursor()
        {
            switch (InputManager.GetInput())
            {
                case Key.LEFT:
                case Key.UP:
                    cursor--;
                    if (cursor < 0)
                        cursor = 0;
                    break;
                case Key.RIGHT:
                case Key.DOWN:
                    cursor++;
                    if (cursor > 1)
                        cursor = 0;
                    break;
                case Key.ENTER:
                    clicked = true;
                    break;
            }
        }

        protected override void ClickCursor()
        {
            if (clicked)
            {
                switch (cursor)
                {
                    case 0:
                        Console.SetCursorPosition(12, 6);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("[무사히 휴식할 수 있었다]");
                        Thread.Sleep(1000);
                        foreach (PC pc in player.PARTY.PCs)
                        {
                            if (pc == null)
                                break;
                            pc.NOW_HP += pc.MAX_HP / 2;
                            pc.NOW_SP += pc.MAX_SP / 2; ;
                        }
                        isReturn = false;
                        break;
                    case 1:
                        isReturn = true;
                        break;
                }
                inRoom = false;
                clicked = false;
            }
        }

        public bool IsReturn()
        {
            return isReturn;
        }
    }
}
