namespace ProjectRPG
{
    internal class Field
    {
        enum Tile { BLOCK, ROAD, BUSH, TOWN }

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
            player = _player;
            inMap = true;
            SetField();
            while (inMap)
            {
                DrawMap();
                Move();
            }
        }

        void SetField()
        {
            tiles = new Tile[20, 20]
            {
                {Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK },
                {Tile.BLOCK, Tile.ROAD, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK },
                {Tile.BLOCK, Tile.ROAD, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK },
                {Tile.BLOCK, Tile.ROAD, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK },
                {Tile.BLOCK, Tile.ROAD, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK },
                {Tile.BLOCK, Tile.ROAD, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK },
                {Tile.BLOCK, Tile.ROAD, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK },
                {Tile.BLOCK, Tile.ROAD, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK },
                {Tile.BLOCK, Tile.ROAD, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK },
                {Tile.BLOCK, Tile.ROAD, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK },
                {Tile.BLOCK, Tile.ROAD, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK },
                {Tile.BLOCK, Tile.ROAD, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK },
                {Tile.BLOCK, Tile.ROAD, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK },
                {Tile.BLOCK, Tile.ROAD, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK },
                {Tile.BLOCK, Tile.ROAD, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK },
                {Tile.BLOCK, Tile.ROAD, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK },
                {Tile.BLOCK, Tile.ROAD, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK },
                {Tile.BLOCK, Tile.ROAD, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK },
                {Tile.BLOCK, Tile.ROAD, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK, Tile.BLOCK },
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
                        case Tile.ROAD:
                            Console.Write("　");
                            break;
                        case Tile.BUSH:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("□");
                            break;
                        case Tile.TOWN:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("▤");
                            break;
                    }
                }
                Console.WriteLine();
            }
            Console.SetCursorPosition(posX, posY);
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
                        if (tiles[posY, posX + 1] == Tile.ROAD)
                        {
                            posX--;
                        }
                        else if (tiles[posY, posX + 1] == Tile.BUSH)
                        {
                            posX--;
                        }
                        else if (tiles[posY, posX + 1] == Tile.TOWN)
                        {
                            posX--;
                        }
                    }
                    break;
                case Key.RIGHT:
                    if (posX < tiles.GetLength(1) - 1)
                    {
                        if (tiles[posY, posX - 1] == Tile.ROAD)
                        {
                            posX++;
                        }
                        else if (tiles[posY, posX - 1] == Tile.BUSH)
                        {
                            posX++;
                        }
                        else if (tiles[posY, posX - 1] == Tile.TOWN)
                        {
                            posX++;
                        }
                    }
                    break;
                case Key.UP:
                    if (posY > 0)
                    {
                        if (tiles[posY - 1, posX] == Tile.ROAD)
                        {
                            posY--;
                        }
                        else if (tiles[posY - 1, posX] == Tile.BUSH)
                        {
                            posY--;
                        }
                        else if (tiles[posY - 1, posX] == Tile.TOWN)
                        {
                            posY--;
                        }
                    }
                    break;
                case Key.DOWN:
                    if (posX < tiles.GetLength(0) - 1)
                    {
                        if (tiles[posY + 1, posX] == Tile.ROAD)
                        {
                            posY++;
                        }
                        else if (tiles[posY + 1, posX] == Tile.BUSH)
                        {
                            posY++;
                        }
                        else if (tiles[posY + 1, posX] == Tile.TOWN)
                        {
                            posY++;
                        }
                    }
                    break;
                case Key.ENTER:
                    if (tiles[posY, posX] == Tile.TOWN)
                    {
                        inMap = false;
                    }
                    else if (tiles[posY, posX] == Tile.BUSH)
                    {

                    }
                    break;
            }
        }
    }
}
