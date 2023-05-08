namespace ProjectTextRPG
{
    public class ShopScene : Scene
    {
        int cursor;
        enum Screen { Main, Buy, Sell };
        Screen screen = Screen.Main;

        public ShopScene(Game game) : base(game)
        {

        }

        public override void Render()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("[상점]");
            Console.WriteLine($"[소지금 : {Data.player.Money} | 현재 무게 : {Data.player.NowEight} / {Data.player.LimitWeight}]");
        }

        public override void Update()
        {
            switch (screen)
            {
                case Screen.Main:
                    MainUpdate();
                    break;
                case Screen.Buy:
                    BuyUpdate();
                    break;
                case Screen.Sell:
                    SellUpdate();
                    break;
            }
        }

        void MainUpdate()
        {
            if (cursor == 0) Console.ForegroundColor = ConsoleColor.Green;
            else Console.ForegroundColor = ConsoleColor.White;
            Console.Write("아이템 구매\t");
            if (cursor == 1) Console.ForegroundColor = ConsoleColor.Green;
            else Console.ForegroundColor = ConsoleColor.White;
            Console.Write("아이템 판매\t");
            if (cursor == 2) Console.ForegroundColor = ConsoleColor.Green;
            else Console.ForegroundColor = ConsoleColor.White;
            Console.Write("상점 나가기");

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.LeftArrow:
                case ConsoleKey.UpArrow:
                    cursor--;
                    if (cursor < 0)
                        cursor = 2;
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.DownArrow:
                    cursor++;
                    if (cursor > 2)
                        cursor = 0;
                    break;
                case ConsoleKey.Enter:
                    Console.Clear();
                    switch (cursor)
                    {
                        case 0:
                            screen = Screen.Buy;
                            break;
                        case 1:
                            screen = Screen.Sell;
                            break;
                        case 2:
                            game.Map();
                            break;
                    }
                    cursor = 0;
                    break;
                case ConsoleKey.Backspace:
                    game.Map();
                    cursor = 0;
                    break;
            }
        }

        void BuyUpdate()
        {
            if(Data.shop.Count == 0)
            {
                screen = Screen.Main;
                cursor = 0;
                return;
            }
            Console.SetCursorPosition(0, 3);

            Console.WriteLine($"구매 가능한 아이템");

            for(int i = 0; i < Data.shop.Count; i++)
            {
                if(cursor == i) Console.ForegroundColor = ConsoleColor.Green;
                else Console.ForegroundColor= ConsoleColor.White;
                Console.WriteLine($"{Data.shop[i].name} {Data.shop[i].price}$ {Data.shop[i].weight}㎏ {Data.shop[i].description}");
            }

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.LeftArrow:
                case ConsoleKey.UpArrow:
                    cursor--;
                    if (cursor < 0)
                        cursor = Data.shop.Count - 1;
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.DownArrow:
                    cursor++;
                    if (cursor >= Data.shop.Count)
                        cursor = 0;
                    break;
                case ConsoleKey.Enter:
                    if (Data.shop[cursor].price <= Data.player.Money)
                    {
                        Data.player.Money -= Data.shop[cursor].price;
                        Data.player.inventory.Add(Data.shop[cursor]);
                        Data.shop.RemoveAt(cursor);
                    }
                    if (cursor >= Data.player.inventory.Count)
                        cursor --;
                    Console.Clear();
                    break;
                case ConsoleKey.Backspace:
                    Console.Clear();
                    screen = Screen.Main;
                    cursor = 0;
                    break;
            }
        }

        void SellUpdate()
        {
            if (Data.player.inventory.Count == 0)
            {
                screen = Screen.Main;
                cursor = 0;
                return;
            }
            Console.SetCursorPosition(0, 3);

            Console.WriteLine($"판매 가능한 아이템");

            for (int i = 0; i < Data.player.inventory.Count; i++)
            {
                if (cursor == i) Console.ForegroundColor = ConsoleColor.Green;
                else Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"{Data.player.inventory[i].name} {(int)(Data.player.inventory[i].price * 0.8)}$ {Data.player.inventory[i].weight}㎏ {Data.player.inventory[i].description}");
            }

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.LeftArrow:
                case ConsoleKey.UpArrow:
                    cursor--;
                    if (cursor < 0)
                        cursor = Data.player.inventory.Count - 1;
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.DownArrow:
                    cursor++;
                    if (cursor >= Data.player.inventory.Count)
                        cursor = 0;
                    break;
                case ConsoleKey.Enter:
                    Data.player.Money += (int)(Data.player.inventory[cursor].price * 0.8);
                    Data.shop.Add(Data.player.inventory[cursor]);
                    Data.player.inventory.RemoveAt(cursor);
                    if (cursor >= Data.player.inventory.Count)
                        cursor--;
                    Console.Clear();
                    break;
                case ConsoleKey.Backspace:
                    Console.Clear();
                    screen = Screen.Main;
                    cursor = 0;
                    break;
            }
        }
    }
}
