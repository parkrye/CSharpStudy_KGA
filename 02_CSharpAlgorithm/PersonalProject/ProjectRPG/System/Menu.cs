using System.ComponentModel;
using System.Xml.Linq;

namespace ProjectRPG
{
    internal class Menu
    {
        Player player;
        int screen, cursor, exit;

        public bool StartMenu(Player _player)
        {
            player = _player;
            screen = 0;
            cursor = 0;
            exit = 0;

            DrawUI();
            while (exit == 0)
            {
                ShowMenu();
                GetCursor();
            }

            if (exit == 2)
                return false;
            return true;
        }

        void DrawUI()
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
            Console.SetCursorPosition(4, 1);
            Console.Write($"{player.NAME} | 보유금액 : {player.MONEY}");
        }

        void ShowMenu()
        {

            switch (screen)
            {
                case 0:
                    Console.SetCursorPosition(4, 4);
                    if (cursor == 0)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("[파티]");

                    Console.SetCursorPosition(4, 6);
                    if (cursor == 1)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("[종료]");

                    Console.SetCursorPosition(4, 8);
                    if (cursor == 2)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("[취소]");
                    break;
                case 1:
                    for(int i = 0; i < 4; i++)
                    {
                        Console.SetCursorPosition(4, 4 + i);
                        if (i == cursor)
                            Console.ForegroundColor = ConsoleColor.Green;
                        else
                            Console.ForegroundColor = ConsoleColor.White;

                        if (player.PARTY.MEMBERS <= i)
                            Console.Write("[---]");
                        else
                            Console.Write($"[{player.PARTY.PCs[i].NAME}");
                    }
                    Console.SetCursorPosition(4, 8);
                    if (cursor == 4)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("[취소]");
                    break;
                case 2:
                    Console.SetCursorPosition(16, 4);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("[정말 종료하시겠습니까?]");
                    Console.SetCursorPosition(16, 6);
                    if (cursor == 0)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("[종료]");

                    Console.SetCursorPosition(24, 6);
                    if (cursor == 1)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("[취소]");
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(4, 2);
                    Console.Write($"[{player.PARTY.PCs[cursor].NAME}] [HP : {player.PARTY.PCs[cursor].MAX_HP} | SP : {player.PARTY.PCs[cursor].MAX_HP}]");
                    Console.SetCursorPosition(4, 3);
                    Console.Write($"[신체 : {player.PARTY.PCs[cursor].MAX_PHYSICSAL} | 정신 : {player.PARTY.PCs[cursor].MAX_MENTAL} | 순발력 : {player.PARTY.PCs[cursor].MAX_INITIATIVE}]");
                    Console.SetCursorPosition(4, 4);
                    Console.Write("[보유 기술] ");
                    for (int i = 0; i < player.PARTY.PCs[cursor].SKILLSLOT.QUANTITY; i++)
                    {
                        Console.SetCursorPosition(4 + i / 2, 5 + i - (i / 2) * 2);
                        Console.Write($"[{player.PARTY.PCs[cursor].SKILLSLOT.SKILLS[i].NAME}] ");
                    }
                    Console.SetCursorPosition(4, 7);
                    Console.Write("[보유 아이템] ");
                    for (int i = 0; i < player.PARTY.PCs[cursor].ITEMSLOT.QUANTITY; i++)
                    {
                        Console.SetCursorPosition(4 + i / 2, 8 + i - (i / 2) * 2);
                        Console.Write($"[{player.PARTY.PCs[cursor].ITEMSLOT.ITEMS[i].NAME}] ");
                    }
                    break;
            }
        }

        void GetCursor()
        {
            switch (screen)
            {
                case 0:
                    switch (InputManager.GetInput())
                    {
                        case Key.LEFT:
                        case Key.UP:
                            cursor--;
                            if (cursor < 0)
                                cursor = 2;
                            break;
                        case Key.RIGHT:
                        case Key.DOWN:
                            cursor++;
                            if (cursor > 2)
                                cursor = 0;
                            break;
                        case Key.ENTER:
                            DrawUI();
                            if (cursor == 0)
                                screen = 1;
                            else if (cursor == 1)
                            {
                                screen = 2;
                                cursor = 0;
                            }
                            else
                                exit = 1;
                            break;
                        case Key.CANEL:
                            exit = 1;
                            break;
                    }
                    break;
                case 1:
                    switch (InputManager.GetInput())
                    {
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
                            DrawUI();
                            if (cursor < player.PARTY.MEMBERS)
                                screen = 3;
                            else if (cursor == 4)
                            {
                                screen = 0;
                                cursor = 0;
                            }
                            break;
                        case Key.CANEL:
                            DrawUI();
                            screen = 0;
                            cursor = 1;
                            break;
                    }
                    break;
                case 2:
                    switch (InputManager.GetInput())
                    {
                        case Key.LEFT:
                        case Key.UP:
                            cursor--;
                            if (cursor < 0)
                                cursor = 1;
                            break;
                        case Key.RIGHT:
                        case Key.DOWN:
                            cursor++;
                            if (cursor > 1)
                                cursor = 0;
                            break;
                        case Key.ENTER:
                            DrawUI();
                            screen = 0;
                            if (cursor == 0)
                                exit = 2;
                            cursor = 1;
                            break;
                        case Key.CANEL:
                            DrawUI();
                            screen = 0;
                            cursor = 2;
                            break;
                    }
                    break;
                case 3:
                    InputManager.GetInput();
                    screen = 1;
                    DrawUI();
                    break;
            }
        }
    }
}
