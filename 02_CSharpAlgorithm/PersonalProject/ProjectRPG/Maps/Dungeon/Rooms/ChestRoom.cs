using System;

namespace ProjectRPG
{
    internal class ChestRoom : DungeonRoom
    {
        bool hasBox;

        public ChestRoom(Player player, Party enemy, Item item) : base(player, enemy, item)
        {
            name = "상자 방";
            hasBox = true;
        }

        protected override void ShowContent()
        {
            Console.SetCursorPosition(15, 4);
            if(cursor == 0)
                Console.ForegroundColor = ConsoleColor.Green;
            else
                Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[열어보기]");

            Console.SetCursorPosition(35, 4);
            if (cursor == 1)
                Console.ForegroundColor = ConsoleColor.Green;
            else
                Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[나아가기]");
        }

        protected override void MoveCursor()
        {
            if (hasBox)
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
            else
            {
                switch (InputManager.GetInput())
                {
                    case Key.LEFT:
                    case Key.UP:
                    case Key.RIGHT:
                    case Key.DOWN:
                        cursor = 1;
                        break;
                    case Key.ENTER:
                        clicked = true;
                        break;
                }
            }
        }

        protected override void ClickCursor()
        {
            if (clicked)
            {
                if(cursor == 0)
                {
                    if(new Random().Next(3) == 0)
                    {
                        Console.SetCursorPosition(13, 6);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("[어둠 속에서 적이 나타났다!]");
                        Thread.Sleep(500);
                        new Battle(player, enemy).StartBattle();
                        ShowUI();
                        if (player.PARTY.MEMBERS > 0)
                        {
                            Console.SetCursorPosition(13, 6);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("[상자는 완전히 부서져버렸다]");
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
                        inRoom = false;
                    }
                    else
                    {
                        Console.SetCursorPosition(13, 6);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("[상자 안에 아이템이 들어있었다]");
                        Thread.Sleep(1000);
                        player.AddItem(item);
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
