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
        int screen;        // 메인, 구매, 판매 세가지 화면을 나타내는 숫자

        public Market() : base()
        {
            name = "상점";
            items = new List<Item>();
            ItemSetting();
            products = new Item[4];
            ProductSetting();
            screen = 0;
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
                    case 8: product = new Item_PowerBelt(); break;
                    case 7: product = new Item_WindBoots(); break;
                }
                products[i] = product;
            }
        }

        protected override void ShowSites()
        {
            Console.Clear();

            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"[{name} | 소지금 : $ {player.MONEY}]");
            switch (screen)
            {
                // 메인 화면
                case 0:
                    Console.WriteLine();
                    if (cursor == 0)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("[구매]");
                    if (cursor == 1)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("[판매]");
                    if (cursor == 2)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"[{name} 나가기]");
                    break;

                // 구매 화면
                case 1:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("[구매]");
                    Console.WriteLine();
                    for (int i = 0; i < 4; i++)
                    {
                        if (cursor == i)
                            Console.ForegroundColor = ConsoleColor.Green;
                        else
                            Console.ForegroundColor = ConsoleColor.White;

                        if (products[i] != null)
                        {
                            Console.WriteLine($"[{products[i].NAME} : $ {products[i].PRICE}]");
                        }
                        else
                        {
                            Console.WriteLine("[---]");
                        }
                    }
                    if (cursor == 4)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"[{name} 나가기]");
                    break;

                // 판매 화면
                case 2:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("[판매]");
                    Console.WriteLine();
                    for (int i = 0; i < player.INVENTORY.Count; i++)
                    {
                        if (cursor == i)
                            Console.ForegroundColor = ConsoleColor.Green;
                        else
                            Console.ForegroundColor = ConsoleColor.White;

                        Console.WriteLine($"[{player.INVENTORY[i].NAME} : $ {player.INVENTORY[i].PRICE}]");
                    }
                    if (cursor == player.INVENTORY.Count)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"[{name} 나가기]");
                    break;
            }
        }

        protected override void GetCursor()
        {
            int key = Input();
            switch (screen)
            {
                // 메인 화면
                case 0:
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

                // 구매 화면
                case 1:
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

                // 판매 화면
                case 2:
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
            }
        }

        protected override void ClickCursor()
        {
            if (goSite)
            {
                switch (screen)
                {
                    // 메인 화면
                    case 0:
                        switch (cursor)
                        {
                            case 0:
                                screen = 1;
                                cursor = 0;
                                goSite = false;
                                break;
                            case 1:
                                screen = 2;
                                cursor = 0;
                                goSite = false;
                                break;
                            case 2:
                                outSite = true;
                                break;
                        }
                        break;

                    // 구매 화면
                    case 1:
                        goSite = false;
                        if (cursor == 4)
                        {
                            screen = 0;
                            cursor = 0;
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
                        break;

                    // 판매 화면
                    case 2:
                        goSite = false;
                        if (cursor == player.INVENTORY.Count)
                        {
                            screen = 0;
                            cursor = 0;
                            break;
                        }
                        player.AddMoney(player.INVENTORY[cursor].PRICE);
                        player.RemoveItem(cursor);
                        cursor = 0;
                        break;
                }
            }
        }
    }
}
