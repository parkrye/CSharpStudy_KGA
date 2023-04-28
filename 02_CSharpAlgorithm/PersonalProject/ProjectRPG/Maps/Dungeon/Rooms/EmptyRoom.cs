namespace ProjectRPG
{
    internal class EmptyRoom : DungeonRoom
    {
        public EmptyRoom(Player player, Party enemy, Item item) : base(player, enemy, item)
        {
            name = "텅빈 방";
        }

        protected override void ShowContent()
        {
            Console.SetCursorPosition(15, 4);
            if(cursor == 0)
                Console.ForegroundColor = ConsoleColor.Green;
            else
                Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[휴식하기]");

            Console.SetCursorPosition(30, 4);
            if (cursor == 1)
                Console.ForegroundColor = ConsoleColor.Green;
            else
                Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[나아가기]");
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
                        switch(new Random().Next(5))
                        {
                            case 0:
                                Console.SetCursorPosition(15, 6);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("[어둠 속에서 적이 나타났다!]");
                                Thread.Sleep(1000);
                                new Battle(player, enemy).StartBattle();
                                inRoom = false;
                                if (player.PARTY.MEMBERS > 0)
                                {
                                    ShowUI();
                                    Console.SetCursorPosition(12, 6);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write("[더이상 이곳에서 휴식하는 건 위험하다]");
                                    Thread.Sleep(1000);
                                }
                                else
                                {
                                    ShowUI();
                                    Console.SetCursorPosition(15, 6);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write("[모든 파티원을 잃었다]");
                                    Thread.Sleep(1000);
                                }
                                break;
                            default:
                                Console.SetCursorPosition(15, 6);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("[무사히 휴식할 수 있었다]");
                                Thread.Sleep(1000);
                                foreach (PC pc in player.PARTY.PCs)
                                {
                                    if (pc == null)
                                        break;
                                    pc.NOW_HP += pc.MAX_HP / 5;
                                    pc.NOW_SP += pc.MAX_SP / 5; ;
                                }
                                break;
                        }
                        break;
                    case 1:
                        inRoom = false;
                        break;
                }
                clicked = false;
            }
        }
    }
}
