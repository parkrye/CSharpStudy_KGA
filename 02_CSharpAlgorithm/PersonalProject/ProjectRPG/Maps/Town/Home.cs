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

        public Home() : base()
        {
            name = "집";
            prevCursor = 0;
        }

        protected override void ShowSites()
        {
            Console.Clear();

            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"[{name} | 소지금 : $ {player.MONEY}]");
            switch (screen)
            {
                case Screen.Main:
                    Console.WriteLine();
                    if (cursor == 0)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("[파티]");
                    if (cursor == 1)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("[창고]");
                    if (cursor == 2)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("[객실]");
                    if (cursor == 3)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("[침실]");
                    if (cursor == 4)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"[{name} 나가기]");
                    break;
                case Screen.Party:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("[파티]");
                    Console.WriteLine();
                    for (int i = 0; i < player.PARTY.MEMBERS; i++)
                    {
                        if (cursor == i)
                            Console.ForegroundColor = ConsoleColor.Green;
                        else
                            Console.ForegroundColor = ConsoleColor.White;
                        if (player.PARTY.PCs[i] != null)
                            Console.WriteLine($"[{i + 1}. {player.PARTY.PCs[i].NAME}]");
                        else
                            Console.WriteLine("[---]");
                    }
                    if (cursor == player.PARTY.MEMBERS)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("[나가기]");
                    break;
                case Screen.Storage:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("[창고]");
                    Console.WriteLine();
                    for (int i = 0; i < player.INVENTORY.Count; i++)
                    {
                        if (cursor == i)
                            Console.ForegroundColor = ConsoleColor.Green;
                        else
                            Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"[{i+1}. {player.INVENTORY[i].NAME}]");
                    }
                    if (cursor == player.INVENTORY.Count)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("[나가기]");
                    break;
                case Screen.Lodging:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("[객실]");
                    Console.WriteLine();
                    for (int i = 0; i < player.EMPLOYED.Count; i++)
                    {
                        if (cursor == i)
                            Console.ForegroundColor = ConsoleColor.Green;
                        else
                            Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"[{i + 1}. {player.EMPLOYED[i].NAME}]");
                    }
                    if (cursor == player.EMPLOYED.Count)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("[나가기]");
                    break;
                case Screen.Room:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("[침실]");
                    Console.WriteLine();
                    if (cursor == 0)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("[저장]");
                    if (cursor == 1)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("[나가기]");
                    break;
                case Screen.PartyCharacter:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"[{player.PARTY.PCs[prevCursor].NAME}]");
                    Console.WriteLine($"[HP : {player.PARTY.PCs[prevCursor].MAX_HP} | SP : {player.PARTY.PCs[prevCursor].MAX_HP}]");
                    Console.WriteLine($"[신체 : {player.PARTY.PCs[prevCursor].MAX_PHYSICSAL} | 정신 : {player.PARTY.PCs[prevCursor].MAX_MENTAL} | 순발력 : {player.PARTY.PCs[prevCursor].MAX_INITIATIVE}]");
                    Console.Write($"[보유 기술] ");
                    for(int i = 0; i < player.PARTY.PCs[prevCursor].SKILLSLOT.QUANTITY; i++)
                        Console.Write($"[{player.PARTY.PCs[prevCursor].SKILLSLOT.SKILLS[i].NAME}]");
                    Console.WriteLine();
                    Console.Write($"[보유 아이템] ");
                    for(int i = 0; i < player.PARTY.PCs[prevCursor].ITEMSLOT.QUANTITY; i++)
                        Console.Write($"[{player.PARTY.PCs[prevCursor].ITEMSLOT.ITEMS[i].NAME}]");
                    Console.WriteLine();
                    Console.WriteLine();
                    if (cursor == 0)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("[아이템 회수하기]");
                    if (cursor == 1)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("[파티에서 내보내기]");
                    if (cursor == 2)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("[취소]");
                    break;
                case Screen.StorageItem:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"[{player.INVENTORY[prevCursor].NAME} : 아이템을 전달할 대상]");
                    Console.WriteLine();
                    for (int i = 0; i < player.PARTY.MEMBERS; i++)
                    {
                        if (cursor == i)
                            Console.ForegroundColor = ConsoleColor.Green;
                        else
                            Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"[{i + 1}. {player.PARTY.PCs[i].NAME}]");
                    }
                    if (cursor == player.PARTY.MEMBERS)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("[취소]");
                    break;
                case Screen.LodgingCharacter:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"[{player.EMPLOYED[prevCursor].NAME}]");
                    Console.WriteLine();
                    if (cursor == 0)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("[파티에 들여보내기]");
                    if (cursor == 1)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("[취소]");
                    break;
            }
        }

        protected override void GetCursor()
        {
            int key = Input();
            switch (screen)
            {
                case Screen.Main:
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
                    break;
                case Screen.Party:
                    switch (key)
                    {
                        case 1:
                        case 3:
                            cursor--;
                            if (cursor < 0)
                                cursor = player.PARTY.MEMBERS;
                            break;
                        case 2:
                        case 4:
                            cursor++;
                            if (cursor > player.PARTY.MEMBERS)
                                cursor = 0;
                            break;
                        case 5:
                            goSite = true;
                            break;
                    }
                    break;
                case Screen.Storage:
                    switch (key)
                    {
                        case 1:
                        case 3:
                            cursor--;
                            if (cursor < 0)
                                cursor = player.INVENTORY.Count;
                            break;
                        case 2:
                        case 4:
                            cursor++;
                            if (cursor > player.INVENTORY.Count)
                                cursor = 0;
                            break;
                        case 5:
                            goSite = true;
                            break;
                    }
                    break;
                case Screen.Lodging:
                    switch (key)
                    {
                        case 1:
                        case 3:
                            cursor--;
                            if (cursor < 0)
                                cursor = player.EMPLOYED.Count;
                            break;
                        case 2:
                        case 4:
                            cursor++;
                            if (cursor > player.EMPLOYED.Count)
                                cursor = 0;
                            break;
                        case 5:
                            goSite = true;
                            break;
                    }
                    break;
                case Screen.Room:
                    switch (key)
                    {
                        case 1:
                        case 3:
                            cursor--;
                            if (cursor < 0)
                                cursor = 1;
                            break;
                        case 2:
                        case 4:
                            cursor++;
                            if (cursor > 1)
                                cursor = 0;
                            break;
                        case 5:
                            goSite = true;
                            break;
                    }
                    break;
                case Screen.PartyCharacter:
                    switch (key)
                    {
                        case 1:
                        case 3:
                            cursor--;
                            if (cursor < 0)
                                cursor = 2;
                            break;
                        case 2:
                        case 4:
                            cursor++;
                            if (cursor > 2)
                                cursor = 0;
                            break;
                        case 5:
                            goSite = true;
                            break;
                    }
                    break;
                case Screen.StorageItem:
                    switch (key)
                    {
                        case 1:
                        case 3:
                            cursor--;
                            if (cursor < player.PARTY.MEMBERS)
                                cursor = 1;
                            break;
                        case 2:
                        case 4:
                            cursor++;
                            if (cursor > player.PARTY.MEMBERS)
                                cursor = 0;
                            break;
                        case 5:
                            goSite = true;
                            break;
                    }
                    break;
                case Screen.LodgingCharacter:
                    switch (key)
                    {
                        case 1:
                        case 3:
                            cursor--;
                            if (cursor < 0)
                                cursor = 1;
                            break;
                        case 2:
                        case 4:
                            cursor++;
                            if (cursor > 1)
                                cursor = 0;
                            break;
                        case 5:
                            goSite = true;
                            break;
                    }
                    break;
            }
        }

        protected override void ClickCursor()
        {
            if (goSite)
            {
                switch (screen)
                {
                    case Screen.Main:
                        switch (cursor)
                        {
                            case 0:
                                screen = Screen.Party;
                                cursor = 0;
                                goSite = false;
                                break;
                            case 1:
                                screen = Screen.Storage;
                                cursor = 0;
                                goSite = false;
                                break;
                            case 2:
                                screen = Screen.Lodging;
                                cursor = 0;
                                goSite = false;
                                break;
                            case 3:
                                screen = Screen.Room;
                                cursor = 0;
                                goSite = false;
                                break;
                            case 4:
                                outSite = true;
                                break;
                        }
                        break;
                    case Screen.Party:
                        goSite = false;
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
                        goSite = false;
                        if (cursor == player.INVENTORY.Count)
                        {
                            screen = Screen.Main;
                            cursor = 1;
                            break;
                        }
                        screen = Screen.StorageItem;
                        prevCursor = cursor;
                        cursor = 0;
                        break;
                    case Screen.Lodging:
                        goSite = false;
                        if (cursor == player.EMPLOYED.Count)
                        {
                            screen = Screen.Main;
                            cursor = 2;
                            break;
                        }
                        screen = Screen.LodgingCharacter;
                        prevCursor = cursor;
                        cursor = 0;
                        break;
                    case Screen.Room:
                        goSite = false;
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
                        goSite = false;
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
                            case 2:
                                screen = Screen.Main;
                                break;
                        }
                        cursor = 0;
                        break;
                    case Screen.StorageItem:
                        goSite = false;
                        if (cursor == player.PARTY.MEMBERS)
                        {
                            screen = Screen.Main;
                            cursor = 0;
                            break;
                        }
                        if (player.PARTY.PCs[cursor].ITEMSLOT.HASSLOT)
                        {
                            player.PARTY.PCs[cursor].ITEMSLOT.AddItem(player.INVENTORY[prevCursor]);
                            player.RemoveItem(prevCursor);
                            screen = Screen.Storage;
                            cursor = 0;
                        }
                        break;
                    case Screen.LodgingCharacter:
                        goSite = false;
                        if (cursor == 1)
                        {
                            screen = Screen.Main;
                            cursor = 0;
                            break;
                        }
                        player.EmployedToParty(prevCursor);
                        screen = Screen.Lodging;
                        cursor = 0;
                        break;
                }
            }
        }

        void SaveProcess()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("저장중");
            Thread.Sleep(500);
            Console.Write(".");
            Thread.Sleep(500);
            Console.Clear();
            Console.Write(".");
            Thread.Sleep(500);
            Console.Clear();
            Console.Write(".");
            Thread.Sleep(500);
            Console.Clear();
            Console.WriteLine("저장되었습니다!");
            Thread.Sleep(1500);

            // 이하 파일 저장 코드 추가
        }
    }
}
