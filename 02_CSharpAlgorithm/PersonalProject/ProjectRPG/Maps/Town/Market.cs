using System.Linq;

namespace ProjectRPG
{
    /// <summary>
    /// 마을의 상점에 대한 클래스
    /// </summary>
    internal class Market : TownSite
    {
        List<Item> items;  // 아이템 종류와 총 개수 파악을 위한 리스트
        Item[] products;   // 대기중인 아이템들. 최대 4
        enum Screen { MAIN, BUY, SELL }
        Screen screen;
        int subCursor;

        public Market() : base()
        {
            name = "상점";
            items = new List<Item>();
            ItemSetting();
            products = new Item[4];
            ProductSetting();
            screen = 0;
            subCursor = 0;
        }

        /// <summary>
        /// 아이템의 총 종류 수를 가시적으로 확인하기 위한 리스트 작성
        /// </summary>
        void ItemSetting()
        {
            items.Add(new Item_HPPotion1());
            items.Add(new Item_HPPotion2());
            items.Add(new Item_HPPotion3());
            items.Add(new Item_SPPotion1());
            items.Add(new Item_SPPotion2());
            items.Add(new Item_SPPotion3());
            items.Add(new Item_MysteriousRing());
            items.Add(new Item_PowerBelt());
            items.Add(new Item_WindBoots());
            items.Add(new Item_WoodenClub());
        }

        /// <summary>
        /// 상점에서 판매될 아이템 생성
        /// </summary>
        void ProductSetting()
        {
            for (int i = 0; i < 4; i++)
            {
                Item product;
                switch(new Random().Next(items.Count))
                {
                    default:
                    case 0: product = new Item_HPPotion1(); break;
                    case 1: product = new Item_HPPotion2(); break;
                    case 2: product = new Item_HPPotion3(); break;
                    case 3: product = new Item_SPPotion1(); break;
                    case 4: product = new Item_SPPotion2(); break;
                    case 5: product = new Item_SPPotion3(); break;
                    case 6: product = new Item_MysteriousRing(); break;
                    case 7: product = new Item_PowerBelt(); break;
                    case 8: product = new Item_WindBoots(); break;
                    case 9: product = new Item_WoodenClub(); break;
                }
                products[i] = product;
            }
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
            Console.WriteLine($"[{name} | 소지금 : $ {player.MONEY}]");
            switch (screen)
            {
                case Screen.MAIN:
                    Console.SetCursorPosition(10, 4);
                    if (cursor == 0 && subCursor == 0)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("[구매]");

                    Console.SetCursorPosition(40, 4);
                    if (cursor == 1 && subCursor == 0)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("[판매]");

                    Console.SetCursorPosition(40, 9);
                    if (subCursor == 1)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"[{name} 나가기]");
                    break;

                case Screen.BUY:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(25, 2);
                    Console.Write("[구매]");

                    for (int i = 0; i < 4; i++)
                    {
                        Console.SetCursorPosition(10, i + 4);

                        if (cursor == i)
                            Console.ForegroundColor = ConsoleColor.Green;
                        else
                            Console.ForegroundColor = ConsoleColor.White;

                        
                        if (products[i] != null)
                        {
                            Console.Write($"[{products[i].NAME} : $ {products[i].PRICE}]");
                        }
                        else
                        {
                            Console.Write("[---]");
                        }
                    }

                    Console.SetCursorPosition(40, 9);
                    if (cursor == 4)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"[{name} 나가기]");
                    break;

                case Screen.SELL:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(25, 2);
                    Console.Write("[판매]");

                    for (int i = 0; i < 4; i++)
                    {
                        if (subCursor + i >= player.INVENTORY.Count)
                            break;

                        Console.SetCursorPosition(10, i + 4);

                        if (cursor == i)
                            Console.ForegroundColor = ConsoleColor.Green;
                        else
                            Console.ForegroundColor = ConsoleColor.White;

                        Console.WriteLine($"[{player.INVENTORY[i + subCursor].NAME} : $ {player.INVENTORY[i + subCursor].PRICE}]");
                    }

                    Console.SetCursorPosition(40, 9);
                    if (cursor == 4)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"[{name} 나가기]");
                    break;
            }
        }

        protected override void GetCursor()
        {
            switch (screen)
            {
                case Screen.MAIN:
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
                            if(subCursor < 0)
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
                            outSite = true;
                            break;
                    }
                    break;

                case Screen.BUY:
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
                            screen = Screen.MAIN;
                            break;
                    }
                    break;

                case Screen.SELL:
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
                                cursor = 4;
                            break;
                        case Key.RIGHT:
                            if (player.INVENTORY.Count > (subCursor + 4))
                                subCursor += 4;
                            break;
                        case Key.DOWN:
                            cursor++;
                            if (cursor > 4)
                                cursor = 0;
                            break;
                        case Key.ENTER:
                            goSite = true;
                            break;
                        case Key.CANEL:
                            screen = Screen.MAIN;
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
                    case Screen.MAIN:
                        if(subCursor == 0)
                        {
                            switch (cursor)
                            {
                                case 0:
                                    screen = Screen.BUY;
                                    break;
                                case 1:
                                    screen = Screen.SELL;
                                    break;
                            }
                        }
                        else
                            outSite = true;

                        goSite = false;
                        cursor = 0;
                        subCursor = 0;
                        break;

                    case Screen.BUY:
                        goSite = false;
                        if (cursor == 4)
                        {
                            screen = Screen.MAIN;
                            cursor = 0;
                            subCursor = 0;
                            break;
                        }

                        if (products[cursor] == null)
                            break;
                        if (player.LoseMoney(products[cursor].PRICE))
                        {
                            player.AddItem(products[cursor]);
                            products[cursor] = null;
                        }
                        cursor = 0;
                        subCursor = 0;
                        break;

                    case Screen.SELL:
                        goSite = false;
                        if (cursor == 4)
                        {
                            screen = Screen.MAIN;
                        }
                        else
                        {
                            player.AddMoney(player.INVENTORY[cursor + subCursor].PRICE);
                            player.RemoveItem(cursor + subCursor);
                        }
                        cursor = 1;
                        subCursor = 0;
                        break;
                }
            }
        }
    }
}
