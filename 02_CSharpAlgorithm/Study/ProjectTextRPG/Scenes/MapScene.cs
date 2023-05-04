using System.Text;

namespace ProjectTextRPG
{
    public class MapScene : Scene
    {
        public MapScene(Game _game) : base(_game)
        {
            Console.CursorVisible = false;
        }

        public override void Render()
        {
            PrintMap();
            PrintMenu();
            PrintInfo();

            PrintItem();
            PrintMonster();
            PrintPlayer();
        }

        public override void Update()
        {
            PlayerMove();
            MonsterMove();
            ItemCheck();
            BattleCheck();
        }

        void PrintMap()
        {
            StringBuilder sb = new StringBuilder();
            for(int y = 0; y < Data.map.GetLength(0); y++)
            {
                for(int x = 0; x < Data.map.GetLength(1); x++)
                {
                    if (Data.map[y, x])
                        sb.Append('　');
                    else
                        sb.Append('▩');
                }
                sb.AppendLine();
            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(sb.ToString());
        }

        void PrintPlayer()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(Data.player.position.x * 2, Data.player.position.y);
            Console.Write(Data.player.icon);
        }

        void PrintMonster()
        {
            foreach (Monster monster in Data.monsters)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(monster.position.x * 2, monster.position.y);
                Console.Write(monster.icon);
            }
        }

        void PrintItem()
        {
            foreach (Item item in Data.items)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(item.position.x * 2, item.position.y);
                Console.Write(item.icon);
            }
        }

        void PlayerMove()
        {
            ConsoleKey input = Console.ReadKey().Key;
            switch (input)
            {
                case ConsoleKey.LeftArrow:
                    Data.player.Move(Direction.Left);
                    break;
                case ConsoleKey.RightArrow:
                    Data.player.Move(Direction.Right);
                    break;
                case ConsoleKey.UpArrow:
                    Data.player.Move(Direction.Up);
                    break;
                case ConsoleKey.DownArrow:
                    Data.player.Move(Direction.Down);
                    break;
                case ConsoleKey.Q:
                    game.MainMenu();
                    break;
                case ConsoleKey.I:
                    game.Inventory();
                    break;
            }
        }

        void MonsterMove()
        {
            foreach (Monster monster in Data.monsters)
            {
                monster.MonsterAction();
            }
        }

        void BattleCheck()
        {
            Monster monster = Data.MonsterInPos(Data.player.position);
            if (monster != null)
            {
                game.BattleStart(monster);
            }
        }

        void ItemCheck()
        {
            Item item = Data.ItemInPos(Data.player.position);
            if (item != null)
            {
                Data.player.GetItem(item);
                Data.items.Remove(item);
            }
        }

        private void PrintMenu()
        {
            Console.ForegroundColor = ConsoleColor.White;
            (int left, int top) pos = Console.GetCursorPosition();
            Console.SetCursorPosition(Data.map.GetLength(1) * 2 + 6, 1);
            Console.Write("메뉴 : Q");
            Console.SetCursorPosition(Data.map.GetLength(1) * 2 + 6, 3);
            Console.Write("이동 : 방향키");
            Console.SetCursorPosition(Data.map.GetLength(1) * 2 + 6, 4);
            Console.Write("인벤토리 : I");
        }

        private void PrintInfo()
        {
            Console.SetCursorPosition(0, Data.map.GetLength(0) + 1);
            Console.Write($"HP : {Data.player.CurHp,3}/{Data.player.MaxHp,3}\t");
            Console.Write($"EXP : {Data.player.CurExp,3}/{Data.player.MaxExp,3}");
        }
    }
}
