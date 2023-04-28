namespace ProjectRPG
{
    internal class BattleRoom : DungeonRoom
    {
        bool battleOver;    // 전투 종료 여부

        public BattleRoom(Player player, Party enemy, Item item) : base(player, enemy, item)
        {
            name = "전투 방";
            battleOver = false;
        }

        protected override void ShowContent()
        {
            Console.SetCursorPosition(22, 5);
            if (!battleOver)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("[전투하기]");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("[나아가기]");
            }
        }

        protected override void MoveCursor()
        {
            switch (InputManager.GetInput())
            {
                case Key.ENTER:
                    clicked = true;
                    break;
            }
        }

        protected override void ClickCursor()
        {
            if (clicked)
            {
                if (!battleOver)
                {
                    new Battle(player, enemy).StartBattle();
                    if(player.PARTY.MEMBERS > 0)
                    {
                        ShowUI();
                        Console.SetCursorPosition(18, 6);
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        ShowUI();
                        Console.SetCursorPosition(18, 6);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("[모든 파티원을 잃었다]");
                        Thread.Sleep(1000);
                    }
                }
                else
                {
                    inRoom = false;
                }
                clicked = false;
            }
        }
    }
}
