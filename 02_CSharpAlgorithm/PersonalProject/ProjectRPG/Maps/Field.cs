namespace ProjectRPG
{
    internal class Field
    {
        protected enum Tile { BLOCK, ROAD, EVENT, PORTAL }

        protected Tile[,] tiles;
        protected string name;
        protected int posX, posY;
        protected bool inMap;

        public string NAME
        {
            get { return name; }
            set { name = value; }
        }

        public void StartMap()
        {
            inMap = true;
            while (inMap)
            {
                DrawMap();
                Input();
            }
        }

        public void DrawMap()
        {
            Console.SetCursorPosition(0, 0);
            for (int y = 0; y < tiles.GetLength(0); y++)
            {
                for (int x = 0; x < tiles.GetLength(1); x++)
                {
                    switch (tiles[y, x])
                    {
                        case Tile.BLOCK:
                            Console.Write("■");
                            break;
                        case Tile.ROAD:
                            Console.Write("　");
                            break;
                        case Tile.PORTAL:
                            Console.Write("◎");
                            break;
                    }
                }
            }
        }

        public void Input()
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
                            posX++;
                        }
                        else if (tiles[posY, posX + 1] == Tile.EVENT)
                        {
                            posX++;
                        }
                        else if (tiles[posY, posX + 1] == Tile.PORTAL)
                        {
                            posX++;
                        }
                    }
                    break;
                case Key.RIGHT:
                    if (posX < tiles.GetLength(1) - 1)
                    {
                        if (tiles[posY, posX - 1] == Tile.ROAD)
                        {
                            posX--;
                        }
                        else if (tiles[posY, posX - 1] == Tile.EVENT)
                        {
                            posX--;
                        }
                        else if (tiles[posY, posX - 1] == Tile.PORTAL)
                        {
                            posX--;
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
                        else if (tiles[posY - 1, posX] == Tile.EVENT)
                        {
                            posY--;
                        }
                        else if (tiles[posY - 1, posX] == Tile.PORTAL)
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
                        else if (tiles[posY + 1, posX] == Tile.EVENT)
                        {
                            posY++;
                        }
                        else if (tiles[posY + 1, posX] == Tile.PORTAL)
                        {
                            posY++;
                        }
                    }
                    break;
                case Key.ENTER:
                    if (tiles[posX, posY] == Tile.PORTAL)
                    {
                        inMap = false;
                    }
                    else if (tiles[posX, posY] == Tile.EVENT)
                    {

                    }
                    break;
            }
        }
    }
}
