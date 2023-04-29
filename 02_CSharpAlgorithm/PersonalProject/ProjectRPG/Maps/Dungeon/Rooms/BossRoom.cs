namespace ProjectRPG
{
    internal class BossRoom : DungeonRoom
    {
        bool battleOver;    // 전투 종료 여부

        public BossRoom(Player player, Party enemy, Item item) : base(player, enemy, item)
        {
            name = "보스 방";
            battleOver = false;
        }

        protected override void ShowContent()
        {
            Console.SetCursorPosition(26, 5);
            if (!battleOver)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("[결전]");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("[탈출]");
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
                if (battleOver)
                {
                    inRoom = false;
                }
                else
                {
                    new Battle(player, enemy).StartBattle();
                    if (player.PARTY.MEMBERS > 0)
                    {
                        Console.SetCursorPosition(15, 5);
                        Console.Write("[보스를 격퇴하고 아이템을 획득했다]");
                        player.AddItem(item);
                        battleOver = true;
                    }
                    else
                    {
                        ShowUI();
                        Console.SetCursorPosition(15, 6);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("[모든 파티원을 잃었다]");
                        Thread.Sleep(1000);
                    }
                }
                clicked = false;
            }
        }
    }
}
