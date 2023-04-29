using System.IO;

namespace ProjectRPG
{
    /// <summary>
    /// 마을의 집에 대한 클래스
    /// </summary>
    internal class Home : TownSite
    {
        enum Screen { Main, Party, Storage, Lodging, Room, PartyCharacter, StorageItem, LodgingCharacter }
        Screen screen;
        int prevCursor;     // 이전 커서를 기억하기 위한 변수
        int subCursor;

        public Home() : base()
        {
            name = "집";
            prevCursor = 0;
            subCursor = 0;
        }

        protected override void ShowSites()
        {
            for (int j = 1; j < 10; j++)
            {
                for (int i = 1; i < 59; i++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write(" ");
                }
            }

            Console.SetCursorPosition(20, 1);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"[{name} | 소지금 : $ {player.MONEY}]");
            switch (screen)
            {
                case Screen.Main:
                    Console.SetCursorPosition(10, 4);
                    if (cursor == 0)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("[파티]");

                    Console.SetCursorPosition(10, 5);
                    if (cursor == 1)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("[창고]");

                    Console.SetCursorPosition(10, 6);
                    if (cursor == 2)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("[객실]");

                    Console.SetCursorPosition(10, 7);
                    if (cursor == 3)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("[침실]");

                    Console.SetCursorPosition(40, 9);
                    if (cursor == 4)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"[{name} 나가기]");
                    break;

                case Screen.Party:
                    Console.SetCursorPosition(25, 2);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("[파티]");
                    for (int i = 0; i < player.PARTY.MEMBERS; i++)
                    {
                        Console.SetCursorPosition(10, i + 4);
                        if (cursor == i)
                            Console.ForegroundColor = ConsoleColor.Green;
                        else
                            Console.ForegroundColor = ConsoleColor.White;
                        if (player.PARTY.PCs[i] != null)
                            Console.Write($"[{i + 1}. {player.PARTY.PCs[i].NAME}]");
                        else
                            Console.Write("[---]");
                    }

                    Console.SetCursorPosition(40, 9);
                    if (cursor == player.PARTY.MEMBERS)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("[나가기]");
                    break;

                case Screen.Storage:
                    Console.SetCursorPosition(25, 2);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("[창고]");
                    for (int i = 0; i < 4; i++)
                    {
                        if (subCursor + i >= player.INVENTORY.Count)
                            break;

                        Console.SetCursorPosition(10, i + 4);
                        if (cursor == i)
                            Console.ForegroundColor = ConsoleColor.Green;
                        else
                            Console.ForegroundColor = ConsoleColor.White;
                        Console.Write($"[{player.INVENTORY[i + subCursor].NAME}]");
                    }

                    Console.SetCursorPosition(40, 9);
                    if (cursor == (player.INVENTORY.Count - subCursor >= 4 ? 4 : player.INVENTORY.Count - subCursor))
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("[나가기]");
                    break;

                case Screen.Lodging:
                    Console.SetCursorPosition(25, 2);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("[객실]");
                    for (int i = 0; i < 4; i++)
                    {
                        if (subCursor + i >= player.EMPLOYED.Count)
                            break;

                        Console.SetCursorPosition(10, 4 + i);
                        if (cursor == i)
                            Console.ForegroundColor = ConsoleColor.Green;
                        else
                            Console.ForegroundColor = ConsoleColor.White;
                        Console.Write($"[{player.EMPLOYED[i + subCursor].NAME}]");
                    }

                    Console.SetCursorPosition(40, 9);
                    if (cursor == (player.EMPLOYED.Count - subCursor >= 4 ? 4 : player.EMPLOYED.Count - subCursor))
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("[나가기]");
                    break;

                case Screen.Room:
                    Console.SetCursorPosition(25, 2);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("[침실]");

                    Console.SetCursorPosition(20, 5);
                    if (cursor == 0)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("[저장]");

                    Console.SetCursorPosition(30, 5);
                    if (cursor == 1)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("[나가기]");
                    break;

                case Screen.PartyCharacter:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(10, 2);
                    Console.Write($"[{player.PARTY.PCs[prevCursor].NAME}] [HP : {player.PARTY.PCs[prevCursor].MAX_HP} | SP : {player.PARTY.PCs[prevCursor].MAX_HP}]");
                    Console.SetCursorPosition(10, 3);
                    Console.Write($"[신체 : {player.PARTY.PCs[prevCursor].MAX_PHYSICSAL} | 정신 : {player.PARTY.PCs[prevCursor].MAX_MENTAL} | 순발력 : {player.PARTY.PCs[prevCursor].MAX_INITIATIVE}]");
                    Console.SetCursorPosition(5, 4);
                    Console.Write("[보유 기술] ");
                    for (int i = 0; i < player.PARTY.PCs[prevCursor].SKILLSLOT.QUANTITY; i++)
                    {
                        if(i == 1) Console.SetCursorPosition(10, 5);
                        Console.Write($"[{player.PARTY.PCs[prevCursor].SKILLSLOT.SKILLS[i].NAME}] ");
                    }
                    Console.SetCursorPosition(5, 6);
                    Console.Write("[보유 아이템] ");
                    for (int i = 0; i < player.PARTY.PCs[prevCursor].ITEMSLOT.QUANTITY; i++)
                    {
                        if (i == 1) Console.SetCursorPosition(10, 7);
                        Console.Write($"[{player.PARTY.PCs[prevCursor].ITEMSLOT.ITEMS[i].NAME}] ");
                    }

                    Console.SetCursorPosition(10, 8);
                    if (cursor == 0 && subCursor == 0)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("[아이템 회수하기]");

                    Console.SetCursorPosition(30, 8);
                    if (cursor == 1 && subCursor == 0)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("[파티에서 내보내기]");

                    Console.SetCursorPosition(40, 9);
                    if (subCursor == 1)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("[취소]");
                    break;

                case Screen.StorageItem:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(10, 2);
                    Console.Write($"[{player.INVENTORY[prevCursor].NAME} : 아이템을 전달할 대상]");
                    for (int i = 0; i < player.PARTY.MEMBERS; i++)
                    {
                        Console.SetCursorPosition(10, 4 + i);
                        if (cursor == i)
                            Console.ForegroundColor = ConsoleColor.Green;
                        else
                            Console.ForegroundColor = ConsoleColor.White;
                        Console.Write($"[{i + 1}. {player.PARTY.PCs[i].NAME}]");
                    }

                    Console.SetCursorPosition(40, 9);
                    if (cursor == player.PARTY.MEMBERS)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("[취소]");
                    break;

                case Screen.LodgingCharacter:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(24, 3);
                    Console.Write($"[{player.EMPLOYED[prevCursor].NAME}]");
                    Console.SetCursorPosition(18, 4);
                    Console.Write($"[현재 파티 인원 ({player.PARTY.MEMBERS}/{player.PARTY.PCs.Length})]");

                    Console.SetCursorPosition(10, 6);
                    if (cursor == 0)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("[파티에 들여보내기]");

                    Console.SetCursorPosition(35, 6);
                    if (cursor == 1)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("[취소]");
                    break;
            }
        }

        protected override void GetCursor()
        {
            switch (screen)
            {
                case Screen.Main:
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
                    break;

                case Screen.Party:
                    switch (InputManager.GetInput())
                    {
                        default:
                            break;
                        case Key.LEFT:
                        case Key.UP:
                            cursor--;
                            if (cursor < 0)
                                cursor = player.PARTY.MEMBERS;
                            break;
                        case Key.RIGHT:
                        case Key.DOWN:
                            cursor++;
                            if (cursor > player.PARTY.MEMBERS)
                                cursor = 0;
                            break;
                        case Key.ENTER:
                            goSite = true;
                            break;
                        case Key.CANEL:
                            screen = Screen.Main;
                            cursor = 0;
                            break;
                    }
                    break;

                case Screen.Storage:
                    switch (InputManager.GetInput())
                    {
                        default:
                            break;
                        case Key.LEFT:
                            if (subCursor > 0)
                                subCursor -= 4;
                            break;
                        case Key.UP:
                            cursor--;
                            if (cursor < 0)
                                cursor = (player.INVENTORY.Count - subCursor >= 4 ? 4 : player.INVENTORY.Count - subCursor);
                            break;
                        case Key.RIGHT:
                            if (player.INVENTORY.Count > (subCursor + 4))
                                subCursor += 4;
                            break;
                        case Key.DOWN:
                            cursor++;
                            if (cursor > (player.INVENTORY.Count - subCursor >= 4 ? 4 : player.INVENTORY.Count - subCursor))
                                cursor = 0;
                            break;
                        case Key.ENTER:
                            goSite = true;
                            break;
                        case Key.CANEL:
                            screen = Screen.Main;
                            cursor = 1;
                            break;
                    }
                    break;

                case Screen.Lodging:
                    switch (InputManager.GetInput())
                    {
                        default:
                            break;
                        case Key.LEFT:
                            if (subCursor > 0)
                                subCursor -= 4;
                            break;
                        case Key.UP:
                            cursor--;
                            if (cursor < 0)
                                cursor = (player.EMPLOYED.Count - subCursor >= 4 ? 4 : player.EMPLOYED.Count - subCursor);
                            break;
                        case Key.RIGHT:
                            if (player.EMPLOYED.Count > (subCursor + 4))
                                subCursor += 4;
                            break;
                        case Key.DOWN:
                            cursor++;
                            if (cursor > (player.EMPLOYED.Count - subCursor >= 4 ? 4 : player.EMPLOYED.Count - subCursor))
                                cursor = 0;
                            break;
                        case Key.ENTER:
                            goSite = true;
                            break;
                        case Key.CANEL:
                            screen = Screen.Main;
                            cursor = 2;
                            break;
                    }
                    break;

                case Screen.Room:
                    switch (InputManager.GetInput())
                    {
                        default:
                            break;
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
                            goSite = true;
                            break;
                        case Key.CANEL:
                            screen = Screen.Main;
                            cursor = 3;
                            break;
                    }
                    break;

                case Screen.PartyCharacter:
                    switch (InputManager.GetInput())
                    {
                        default:
                            break;
                        case Key.LEFT:
                            cursor--;
                            if (cursor < 0)
                                cursor = 1;
                            break;
                        case Key.UP:
                            subCursor--;
                            if (subCursor < 0)
                                subCursor = 1;
                            break;
                        case Key.RIGHT:
                            cursor++;
                            if (cursor > 1)
                                cursor = 0;
                            break;
                        case Key.DOWN:
                            subCursor++;
                            if (subCursor > 1)
                                subCursor = 0;
                            break;
                        case Key.ENTER:
                            goSite = true;
                            break;
                        case Key.CANEL:
                            screen = Screen.Party;
                            break;
                    }
                    break;

                case Screen.StorageItem:
                    switch (InputManager.GetInput())
                    {
                        default:
                            break;
                        case Key.LEFT:
                        case Key.UP:
                            cursor--;
                            if (cursor < 0)
                                cursor = player.PARTY.MEMBERS;
                            break;
                        case Key.RIGHT:
                        case Key.DOWN:
                            cursor++;
                            if (cursor > player.PARTY.MEMBERS)
                                cursor = 0;
                            break;
                        case Key.ENTER:
                            goSite = true;
                            break;
                        case Key.CANEL:
                            screen = Screen.Storage;
                            break;
                    }
                    break;

                case Screen.LodgingCharacter:
                    switch (InputManager.GetInput())
                    {
                        default:
                            break;
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
                            goSite = true;
                            break;
                        case Key.CANEL:
                            screen = Screen.Lodging;
                            break;
                    }
                    break;
            }
        }

        protected override void ClickCursor()
        {
            if (goSite)
            {
                goSite = false;
                switch (screen)
                {
                    case Screen.Main:
                        switch (cursor)
                        {
                            case 0:
                                screen = Screen.Party;
                                cursor = 0;
                                break;
                            case 1:
                                screen = Screen.Storage;
                                cursor = 0;
                                break;
                            case 2:
                                screen = Screen.Lodging;
                                cursor = 0;
                                break;
                            case 3:
                                screen = Screen.Room;
                                cursor = 0;
                                break;
                            case 4:
                                outSite = true;
                                break;
                        }
                        break;

                    case Screen.Party:
                        if (cursor == player.PARTY.MEMBERS)
                        {
                            screen = Screen.Main;
                            cursor = 0;
                            break;
                        }
                        if (player.PARTY.PCs[cursor] != null)
                        {
                            screen = Screen.PartyCharacter;
                            prevCursor = cursor;
                            cursor = 0;
                        }
                        break;

                    case Screen.Storage:
                        if (cursor == (player.INVENTORY.Count - subCursor >= 4 ? 4 : player.INVENTORY.Count - subCursor))
                        {
                            screen = Screen.Main;
                            cursor = 1;
                        }
                        else
                        {
                            screen = Screen.StorageItem;
                            prevCursor = subCursor + cursor;
                            cursor = 0;
                        }
                        subCursor = 0;
                        break;

                    case Screen.Lodging:
                        if (cursor == (player.EMPLOYED.Count - subCursor >= 4 ? 4 : player.EMPLOYED.Count - subCursor))
                        {
                            screen = Screen.Main;
                            cursor = 2;
                        }
                        else
                        {
                            screen = Screen.LodgingCharacter;
                            prevCursor = subCursor + cursor;
                            cursor = 0;
                        }
                        subCursor = 0;
                        break;

                    case Screen.Room:
                        if (cursor == 1)
                        {
                            screen = Screen.Main;
                            cursor = 3;
                            break;
                        }
                        SaveProcess();
                        cursor = 0;
                        break;

                    case Screen.PartyCharacter:
                        if(subCursor == 0)
                        {
                            switch (cursor)
                            {
                                case 0:
                                    while (player.PARTY.PCs[prevCursor].ITEMSLOT.QUANTITY > 0)
                                    {
                                        player.AddItem(player.PARTY.PCs[prevCursor].ITEMSLOT.ITEMS[0]);
                                        player.PARTY.PCs[prevCursor].ITEMSLOT.RemoveItem(0);
                                    }
                                    screen = Screen.Party;
                                    break;
                                case 1:
                                    player.PartyToEmployed(prevCursor);
                                    screen = Screen.Party;
                                    break;
                            }
                        }
                        else
                        {
                            screen = Screen.Party;
                        }
                        cursor = 0;
                        subCursor = 0;
                        break;

                    case Screen.StorageItem:
                        if (cursor == player.PARTY.MEMBERS)
                        {
                        }
                        else if (player.PARTY.PCs[cursor].ITEMSLOT.HASSLOT)
                        {
                            player.PARTY.PCs[cursor].ITEMSLOT.AddItem(player.INVENTORY[prevCursor]);
                            player.RemoveItem(prevCursor);
                        }
                        screen = Screen.Storage;
                        cursor = 0;
                        subCursor = 0;
                        break;

                    case Screen.LodgingCharacter:
                        if (cursor != 1)
                        {
                            player.EmployedToParty(prevCursor);
                        }
                        screen = Screen.Lodging;
                        cursor = 0;
                        subCursor = 0;
                        break;
                }
            }
        }

        void SaveProcess()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(25, 6);
            Console.Write("[저장중...]");
            Thread.Sleep(500);
            DataManager.SaveFile(player);
            Console.Clear();
            Console.SetCursorPosition(20, 6);
            Console.WriteLine("[저장되었습니다!]");
            Thread.Sleep(500);
            Console.Clear();
            ShowUI();
        }
    }
}
