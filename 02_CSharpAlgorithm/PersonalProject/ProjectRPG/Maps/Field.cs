namespace ProjectRPG
{
    internal class Field
    {
        enum Tile { BLOCK, ROAD_, BUSH_, TOWN_, WATER }

        Tile[,] tiles;
        string name;
        int posX, posY;
        bool inMap;

        Player player;

        public string NAME
        {
            get { return name; }
            set { name = value; }
        }

        public void StartMap(Player _player)
        {
            posX = 2; posY = 2;
            player = _player;
            inMap = true;
            SetField();
            DrawMap();
            while (inMap)
            {
                DrawPlayer();
                Move();
            }
        }

        void SetField()
        {
            tiles = new Tile[20, 20]
            {
                {Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.WATER, Tile.WATER, Tile.WATER, Tile.WATER, Tile.WATER, Tile.WATER },
                {Tile.BLOCK, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.WATER, Tile.WATER, Tile.WATER, Tile.WATER, Tile.WATER, Tile.WATER },
                {Tile.BLOCK, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.WATER, Tile.WATER, Tile.WATER, Tile.WATER, Tile.WATER },
                {Tile.BLOCK, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.WATER, Tile.WATER, Tile.WATER, Tile.WATER, Tile.WATER },
                {Tile.BLOCK, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.WATER, Tile.WATER, Tile.WATER, Tile.WATER },
                {Tile.BLOCK, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.WATER, Tile.WATER, Tile.WATER, Tile.WATER, Tile.WATER },
                {Tile.BLOCK, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.WATER, Tile.WATER, Tile.WATER, Tile.WATER },
                {Tile.BLOCK, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.WATER, Tile.WATER, Tile.WATER },
                {Tile.BLOCK, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.WATER, Tile.WATER, Tile.WATER },
                {Tile.BLOCK, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.WATER, Tile.WATER },
                {Tile.BLOCK, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.WATER },
                {Tile.BLOCK, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.BLOCK },
                {Tile.BLOCK, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.BLOCK },
                {Tile.BLOCK, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.BLOCK },
                {Tile.BLOCK, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.BLOCK },
                {Tile.BLOCK, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.BLOCK },
                {Tile.BLOCK, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.BLOCK },
                {Tile.BLOCK, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.BLOCK },
                {Tile.BLOCK, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.ROAD_, Tile.BLOCK },
                {Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK },
            };
        }

        void DrawMap()
        {
            Console.SetCursorPosition(0, 0);
            for (int y = 0; y < tiles.GetLength(0); y++)
            {
                for (int x = 0; x < tiles.GetLength(1); x++)
                {
                    switch (tiles[y, x])
                    {
                        default:
                        case Tile.BLOCK:
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write("■");
                            break;
                        case Tile.ROAD_:
                            Console.Write("　");
                            break;
                        case Tile.BUSH_:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("□");
                            break;
                        case Tile.TOWN_:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("▤");
                            break;
                        case Tile.WATER:
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("∬");
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
                    Console.SetCursorPosition(posX + x, posY + y);
                    switch (tiles[posY + y, posX + x])
                    {
                        default:
                        case Tile.BLOCK:
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write("■");
                            break;
                        case Tile.ROAD_:
                            Console.Write("　");
                            break;
                        case Tile.BUSH_:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("□");
                            break;
                        case Tile.TOWN_:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("▤");
                            break;
                        case Tile.WATER:
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("∬");
                            break;
                    }
                }
                Console.WriteLine();
            }

            Console.SetCursorPosition(posX * 2, posY);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("☆");
        }

        void Move()
        {
            switch (InputManager.GetInput())
            {
                default:
                case Key.NONE:
                case Key.CANEL:
                    break;
                case Key.LEFT:
                    if(posX > 0)
                    {
                        if (tiles[posY, posX + 1] == Tile.ROAD_)
                        {
                            posX--;
                        }
                        else if (tiles[posY, posX + 1] == Tile.BUSH_)
                        {
                            posX--;
                        }
                        else if (tiles[posY, posX + 1] == Tile.TOWN_)
                        {
                            posX--;
                        }
                    }
                    break;
                case Key.RIGHT:
                    if (posX < tiles.GetLength(1) - 1)
                    {
                        if (tiles[posY, posX - 1] == Tile.ROAD_)
                        {
                            posX++;
                        }
                        else if (tiles[posY, posX - 1] == Tile.BUSH_)
                        {
                            posX++;
                        }
                        else if (tiles[posY, posX - 1] == Tile.TOWN_)
                        {
                            posX++;
                        }
                    }
                    break;
                case Key.UP:
                    if (posY > 0)
                    {
                        if (tiles[posY - 1, posX] == Tile.ROAD_)
                        {
                            posY--;
                        }
                        else if (tiles[posY - 1, posX] == Tile.BUSH_)
                        {
                            posY--;
                        }
                        else if (tiles[posY - 1, posX] == Tile.TOWN_)
                        {
                            posY--;
                        }
                    }
                    break;
                case Key.DOWN:
                    if (posX < tiles.GetLength(0) - 1)
                    {
                        if (tiles[posY + 1, posX] == Tile.ROAD_)
                        {
                            posY++;
                        }
                        else if (tiles[posY + 1, posX] == Tile.BUSH_)
                        {
                            posY++;
                        }
                        else if (tiles[posY + 1, posX] == Tile.TOWN_)
                        {
                            posY++;
                        }
                    }
                    break;
                case Key.ENTER:
                    if (tiles[posY, posX] == Tile.TOWN_)
                    {
                        inMap = false;
                    }
                    else if (tiles[posY, posX] == Tile.BUSH_)
                    {

                    }
                    break;
            }
        }
    }
}
