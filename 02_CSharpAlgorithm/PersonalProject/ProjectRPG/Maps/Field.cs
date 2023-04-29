namespace ProjectRPG
{
    internal class Field
    {
        enum Tile { B, R, W, T, S, D }                   // 벽, 길, 수풀, 마을, 바다, 던전

        Tile[,] tiles;                                   // x, y
        (int x, int y) position;                         // 플레이어 위치
        bool inMap;                                      // 필드에 남아있는지 여부

        Dictionary<int, (int y, int x)> dungeonDict1;    // 던전 번호, 던전 위치(y, x)
        Dictionary<(int y, int x), int> dungeonDict2;    // 던전 위치(y, x), 던전 번호

        Player player;

        public Field()
        {
            tiles = new Tile[20, 20];
            dungeonDict1 = new Dictionary<int, (int x, int y)>();
            dungeonDict2 = new Dictionary<(int y, int x), int>();

            SetField();
            SetDungeons();
            EnemySetting();
        }

        public void StartMap(Player _player)
        {
            inMap = true;
            player = _player;
            position = player.POSITION;

            DrawMap();
            while (inMap)
            {
                DrawPlayer();
                Move();
            }
            Console.Clear();
        }

        void SetField()
        {
            tiles = new Tile[20, 20]
            {   // 0       1       2       3       4       5       6       7       8       9       10      11      12      13      14      15      16      17      18      19
                {Tile.B, Tile.B, Tile.B, Tile.B, Tile.B, Tile.B, Tile.B, Tile.B, Tile.B, Tile.B, Tile.B, Tile.B, Tile.B, Tile.B, Tile.B, Tile.B, Tile.B, Tile.B, Tile.B, Tile.B },  // 0
                {Tile.B, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.S, Tile.S, Tile.S, Tile.S, Tile.S, Tile.S, Tile.S, Tile.B },  // 1
                {Tile.B, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.S, Tile.S, Tile.S, Tile.S, Tile.S, Tile.S, Tile.S, Tile.B },  // 2
                {Tile.B, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.S, Tile.S, Tile.S, Tile.S, Tile.S, Tile.B },  // 3
                {Tile.B, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.S, Tile.S, Tile.S, Tile.S, Tile.S, Tile.B },  // 4
                {Tile.B, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.S, Tile.S, Tile.S, Tile.S, Tile.S, Tile.B },  // 5
                {Tile.B, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.S, Tile.S, Tile.S, Tile.S, Tile.B },  // 6
                {Tile.B, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.S, Tile.S, Tile.S, Tile.S, Tile.B },  // 7
                {Tile.B, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.R, Tile.R, Tile.R, Tile.R, Tile.R, Tile.W, Tile.W, Tile.W, Tile.W, Tile.S, Tile.S, Tile.S, Tile.S, Tile.B },  // 8
                {Tile.B, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.R, Tile.R, Tile.R, Tile.R, Tile.R, Tile.W, Tile.W, Tile.W, Tile.W, Tile.S, Tile.S, Tile.S, Tile.S, Tile.B },  // 9
                {Tile.B, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.R, Tile.R, Tile.T, Tile.R, Tile.R, Tile.W, Tile.W, Tile.W, Tile.W, Tile.S, Tile.S, Tile.S, Tile.S, Tile.B },  // 10
                {Tile.B, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.R, Tile.R, Tile.R, Tile.R, Tile.R, Tile.W, Tile.W, Tile.W, Tile.W, Tile.S, Tile.S, Tile.S, Tile.S, Tile.B },  // 11
                {Tile.B, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.R, Tile.R, Tile.R, Tile.R, Tile.R, Tile.W, Tile.W, Tile.W, Tile.W, Tile.S, Tile.S, Tile.S, Tile.S, Tile.B },  // 12
                {Tile.B, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.S, Tile.S, Tile.S, Tile.S, Tile.B },  // 13
                {Tile.B, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.S, Tile.S, Tile.S, Tile.S, Tile.B },  // 14
                {Tile.B, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.S, Tile.S, Tile.S, Tile.S, Tile.B },  // 15
                {Tile.B, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.S, Tile.S, Tile.S, Tile.S, Tile.B },  // 16
                {Tile.B, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.S, Tile.S, Tile.S, Tile.S, Tile.S, Tile.B },  // 17
                {Tile.B, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.W, Tile.S, Tile.S, Tile.S, Tile.S, Tile.S, Tile.B },  // 18
                {Tile.B, Tile.B, Tile.B, Tile.B, Tile.B, Tile.B, Tile.B, Tile.B, Tile.B, Tile.B, Tile.B, Tile.B, Tile.B, Tile.B, Tile.B, Tile.B, Tile.B, Tile.B, Tile.B, Tile.B },  // 19
            };
        }

        void SetDungeons()
        {
            dungeonDict1.Add(0, (5, 8));    dungeonDict2.Add((5, 8), 0);
            dungeonDict1.Add(1, (17, 3));   dungeonDict2.Add((17, 3), 1);
            dungeonDict1.Add(2, (10, 14));  dungeonDict2.Add((10, 14), 2);
            dungeonDict1.Add(3, (14, 18));  dungeonDict2.Add((14, 18), 3);
        }

        void OpenDungeons()
        {
            for(int i = 0; i < player.FINDINGS.Length; i++)
            {
                if (player.FINDINGS[i])
                {
                    for (int y = -1; y < 2; y++)
                    {
                        for (int x = -1; x < 2; x++)
                        {
                            if (tiles[dungeonDict1[i].y + y, dungeonDict1[i].x + x] == Tile.W)
                                tiles[dungeonDict1[i].y + y, dungeonDict1[i].x + x] = Tile.R;
                        }
                    }

                    switch (i)
                    {
                        case 0:
                            tiles[7, 8] = Tile.R;
                            break;
                        case 1:
                            tiles[10, 4] = Tile.R;
                            tiles[10, 5] = Tile.R;
                            tiles[10, 3] = Tile.R;
                            tiles[11, 3] = Tile.R;
                            tiles[12, 3] = Tile.R;
                            tiles[13, 3] = Tile.R;
                            tiles[14, 3] = Tile.R;
                            tiles[15, 3] = Tile.R;
                            break;
                        case 2:
                            tiles[10, 11] = Tile.R;
                            tiles[10, 12] = Tile.R;
                            break;
                        case 3:
                            tiles[14, 15] = Tile.R;
                            tiles[14, 16] = Tile.R;
                            tiles[13, 17] = Tile.R;
                            tiles[14, 17] = Tile.R;
                            tiles[15, 17] = Tile.R;
                            tiles[13, 18] = Tile.R;
                            tiles[15, 18] = Tile.R;
                            break;
                    }

                    tiles[dungeonDict1[i].y, dungeonDict1[i].x] = Tile.D;
                }
            }
        }

        void DrawMap()
        {
            Console.Clear();
            OpenDungeons();
            Console.SetCursorPosition(0, 0);
            for (int y = 0; y < tiles.GetLength(0); y++)
            {
                for (int x = 0; x < tiles.GetLength(1); x++)
                {
                    switch (tiles[y, x])
                    {
                        default:
                        case Tile.B:
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write("■");
                            break;
                        case Tile.R:
                            Console.Write("　");
                            break;
                        case Tile.W:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("WW");
                            break;
                        case Tile.T:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("▤");
                            break;
                        case Tile.S:
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("∬");
                            break;
                        case Tile.D:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("∏");
                            break;
                    }
                }
                Console.WriteLine();
            }
        }

        void DrawPlayer()
        {
            for (int y = -1; y < 2; y++)
            {
                for (int x = -1; x < 2; x++)
                {
                    Console.SetCursorPosition((position.x + x) * 2, position.y + y);
                    switch (tiles[position.y + y, position.x + x])
                    {
                        default:
                        case Tile.B:
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write("■");
                            break;
                        case Tile.R:
                            Console.Write("　");
                            break;
                        case Tile.W:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("WW");
                            break;
                        case Tile.T:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("▤");
                            break;
                        case Tile.S:
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("∬");
                            break;
                        case Tile.D:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("∏");
                            break;
                    }
                }
                Console.WriteLine();
            }

            Console.SetCursorPosition(position.x * 2, position.y);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("☆");
        }

        void Move()
        {
            switch (InputManager.GetInput())
            {
                default:
                case Key.NONE:
                    break;
                case Key.LEFT:
                    if(position.x > 0)
                    {
                        if (tiles[position.y, position.x - 1] == Tile.R ||
                            tiles[position.y, position.x - 1] == Tile.W ||
                            tiles[position.y, position.x - 1] == Tile.D ||
                            tiles[position.y, position.x - 1] == Tile.T)
                        {
                            position.x--;
                        }
                    }
                    break;
                case Key.RIGHT:
                    if (position.x < tiles.GetLength(1) - 1)
                    {
                        if (tiles[position.y, position.x + 1] == Tile.R ||
                            tiles[position.y, position.x + 1] == Tile.W ||
                            tiles[position.y, position.x + 1] == Tile.D ||
                            tiles[position.y, position.x + 1] == Tile.T)
                        {
                            position.x++;
                        }
                    }
                    break;
                case Key.UP:
                    if (position.y > 0)
                    {
                        if (tiles[position.y - 1, position.x] == Tile.R ||
                            tiles[position.y - 1, position.x] == Tile.W ||
                            tiles[position.y - 1, position.x] == Tile.D ||
                            tiles[position.y - 1, position.x] == Tile.T)
                        {
                            position.y--;
                        }
                    }
                    break;
                case Key.DOWN:
                    if (position.y < tiles.GetLength(0) - 1)
                    {
                        if (tiles[position.y + 1, position.x] == Tile.R ||
                            tiles[position.y + 1, position.x] == Tile.W ||
                            tiles[position.y + 1, position.x] == Tile.D ||
                            tiles[position.y + 1, position.x] == Tile.T)
                        {
                            position.y++;
                        }
                    }
                    break;
                case Key.ENTER:
                    if (tiles[position.y, position.x] == Tile.T)
                    {
                        new Town().GetIn(player);
                        DrawMap();
                        DrawPlayer();
                    }
                    else if (tiles[position.y, position.x] == Tile.D)
                    {
                        if(dungeonDict2.ContainsKey((position.y, position.x)))
                        {
                            switch(dungeonDict2[(position.y, position.x)])
                            {
                                case 0:
                                    new Dungeon_Hill(player).EnterDungeon();
                                    DrawMap();
                                    DrawPlayer();
                                    break;
                                case 1:
                                    new Dungeon_Forest(player).EnterDungeon();
                                    DrawMap();
                                    DrawPlayer();
                                    break;
                                case 2:
                                    DrawMap();
                                    DrawPlayer();
                                    break;
                                case 3:
                                    DrawMap();
                                    DrawPlayer();
                                    break;
                            }
                        }
                    }
                    break;
                case Key.CANEL:
                    inMap = false;
                    break;
            }

            if (tiles[position.y, position.x] == Tile.W)
            {
                if(new Random().Next(10) == 0)
                {
                    if (player.PARTY.MEMBERS > 0)
                    {
                        new Battle(player, EnemySetting()).StartBattle();
                        if(player.PARTY.MEMBERS > 0)
                        {
                            Console.Clear();
                            Thread.Sleep(500);
                        }
                        else
                        {
                            Console.Clear();
                            Console.SetCursorPosition(18, 5);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("[모든 파티원을 잃었다]");
                            Console.SetCursorPosition(18, 5);
                            Console.Write("[그리고 돈을 빼앗겼다]");
                            player.LoseMoney(player.MONEY / 2);
                            Thread.Sleep(1000);
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.SetCursorPosition(15, 6);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("[도적을 만나 돈을 빼앗겼다]");
                        player.LoseMoney(player.MONEY / 2);
                        Thread.Sleep(1000);
                    }
                    DrawMap();
                    DrawPlayer();
                }
            }
        }

        Party EnemySetting()
        {
            Party party = new Party();
            int num = new Random().Next(4) + 1;
            for (int j = 0; j < num; j++)
            {
                int mon = new Random().Next(20);
                switch (mon)
                {
                    case 0:
                        party.AddPC(new PC(new Class_Soldier()));
                        break;
                    case 1:
                        party.AddPC(new PC(new Class_Clown()));
                        break;
                    case 2:
                        party.AddPC(new PC(new Class_Hunter()));
                        break;
                    case 3:
                        party.AddPC(new PC(new Class_Soccerer()));
                        break;
                    default:
                        party.AddPC(new Monster_Goblin(j + 1));
                        break;
                }
            }
            return party;
        }
    }
}
