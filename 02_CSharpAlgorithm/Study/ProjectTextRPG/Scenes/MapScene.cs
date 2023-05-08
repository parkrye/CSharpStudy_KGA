using System.Text;

namespace ProjectTextRPG
{
    public class MapScene : Scene
    {
        int Sight;
        int up, down, left, right;
        int outUp, outDown, outLeft, outRight;
        bool turn;

        public MapScene(Game _game) : base(_game)
        {
        }

        public override void Render()
        {
            PrintMap();
            PrintMenu();
            PrintInfo();

            PrintEvent();
            PrintItem();
            PrintMonster();
            PrintPlayer();
        }

        public override void Update()
        {
            PlayerMove();
            MonsterMove();
            BattleCheck();
            ItemCheck();
            EventCheck();
        }

        void PrintMap()
        {
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(0, 1);

            Sight = Data.player.Sight;
            up = Data.player.position.y >= Sight ? Data.player.position.y - Sight : 0;
            down = Data.player.position.y + Sight <= Data.map.GetLength(0) ? Data.player.position.y + Sight : Data.map.GetLength(0);
            left = Data.player.position.x >= Sight ? Data.player.position.x - Sight : 0;
            right = Data.player.position.x + Sight <= Data.map.GetLength(1) ? Data.player.position.x + Sight : Data.map.GetLength(1);
            outUp = Data.player.position.y >= Sight + 1 ? Data.player.position.y - Sight - 1 : 0;
            outDown = Data.player.position.y + Sight + 1 <= Data.map.GetLength(0) ? Data.player.position.y + Sight + 1 : Data.map.GetLength(0);
            outLeft = Data.player.position.x >= Sight + 1 ? Data.player.position.x - Sight - 1 : 0;
            outRight = Data.player.position.x + Sight + 1 <= Data.map.GetLength(1) ? Data.player.position.x + Sight + 1 : Data.map.GetLength(1);

            for (int y = outUp; y < outDown; y++)
            {
                for(int x = outLeft; x < outRight; x++)
                {
                    if (Data.map[y, x] && y >= up && y < down && x >= left && x < right)
                        Console.Write('　');
                    else
                        Console.Write('▩');
                }
                Console.WriteLine();
            }
        }

        void PrintPlayer()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition((Data.player.position.x < outLeft ? Data.player.position.x : Data.player.position.x - outLeft) * 2, Data.player.position.y < outUp ? Data.player.position.y + 1 : Data.player.position.y - outUp + 1);
            Console.Write(Data.player.icon);
        }

        void PrintMonster()
        {
            foreach (Monster monster in Data.monsters)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition((monster.position.x < outLeft ? monster.position.x : monster.position.x - outLeft) * 2, monster.position.y < outUp ? monster.position.y + 1 : monster.position.y - outUp + 1);
                if (monster.position.y >= up && monster.position.y < down && monster.position.x >= left && monster.position.x < right)
                {
                    Console.Write(monster.icon);
                }
            }
        }

        void PrintItem()
        {
            foreach (Item item in Data.items)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition((item.position.x < outLeft ? item.position.x : item.position.x - outLeft) * 2, item.position.y < outUp ? item.position.y + 1 : item.position.y - outUp + 1);
                if (item.position.y >= up && item.position.y < down && item.position.x >= left && item.position.x < right)
                {
                    Console.Write(item.icon);
                }
            }
        }

        void PrintEvent()
        {
            foreach (Event evt in Data.events)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.SetCursorPosition((evt.position.x < outLeft ? evt.position.x : evt.position.x - outLeft) * 2, evt.position.y < outUp ? evt.position.y + 1 : evt.position.y - outUp + 1);
                if (evt.position.y >= up && evt.position.y < down && evt.position.x >= left && evt.position.x < right)
                {
                    Console.Write(evt.icon);
                }
            }
        }

        void PlayerMove()
        {
            Console.SetCursorPosition(0, 0);
            turn = false;
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.LeftArrow:
                    turn = Data.player.Move(Direction.Left);
                    break;
                case ConsoleKey.RightArrow:
                    turn = Data.player.Move(Direction.Right);
                    break;
                case ConsoleKey.UpArrow:
                    turn = Data.player.Move(Direction.Up);
                    break;
                case ConsoleKey.DownArrow:
                    turn = Data.player.Move(Direction.Down);
                    break;
                case ConsoleKey.Q:
                    game.MainMenu();
                    break;
                case ConsoleKey.I:
                    game.Inventory();
                    break;
            }
            if(Data.player.Hunger == 0)
                game.GameOver(DeadCause.Starve);
        }

        void MonsterMove()
        {
            if (turn)
            {
                foreach (Monster monster in Data.monsters)
                {
                    monster.MonsterAction();
                }
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
                if(Data.player.NowEight + item.weight < Data.player.LimitWeight)
                {
                    Data.player.GetItem(item);
                    Data.items.Remove(item);
                }
            }
        }

        void EventCheck()
        {
            Event evt = Data.EventInPos(Data.player.position);
            if (evt != null)
            {
                evt.Active();
            }
        }

        private void PrintMenu()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(Sight * 2 + 30, 1);
            Console.Write($"[{Data.floor} 층]");
            if(Data.high > 0)
            {
                Console.SetCursorPosition(Sight * 2 + 30, 2);
                Console.Write($"[최고 기록 : {Data.high} 층]");
            }
            Console.SetCursorPosition(Sight * 2 + 30, 4);
            Console.Write("메뉴 : Q");
            Console.SetCursorPosition(Sight * 2 + 30, 5);
            Console.Write("이동 : 방향키");
            Console.SetCursorPosition(Sight * 2 + 30, 6);
            Console.Write("인벤토리 : I");
        }

        private void PrintInfo()
        {
            Console.SetCursorPosition(0, Sight * 2 + 4);
            for(int i = 0; i < 100; i++)
                Console.Write(" ");
            Console.SetCursorPosition(0, Sight * 2 + 4);
            Console.Write($"생명력 : {Data.player.CurHp,3}/{Data.player.MaxHp,3}\t");
            Console.Write($"경험치 : {Data.player.CurExp,3}/{Data.player.MaxExp,3}\t");
            Console.Write($"굶주림 : {Data.player.Hunger}");
        }
    }
}
