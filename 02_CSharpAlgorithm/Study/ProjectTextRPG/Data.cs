using System.Drawing;

namespace ProjectTextRPG
{
    public static class Data
    {
        public static Random random;
        public static bool[,] map;
        public static Player player;
        public static List<Monster> monsters;
        public static List<Item> inventory;
        public static List<Item> items;

        public static void init()
        {
            random = new Random();
            player = new Player();
            monsters = new List<Monster>();
            inventory = new List<Item>();
            items = new List<Item>();
        }

        public static void Release()
        {

        }

        public static void LoadLevel()
        {
            CreateMap();
            SetPlayer();
            SetMonster();
            SetItem();
        }

        static void CreateMap()
        {
            int mapSizeX = 50, mapSizeY = 50;
            map = new bool[mapSizeY, mapSizeX];

            int roomCount = 10;
            List<(Position position, Position size)> rooms = new List<(Position position, Position size)>();
            for(int i = 0; i < roomCount; i++)
            {
                bool done = false;
                Position position, size;
                do
                {
                    position = new Position(random.Next(mapSizeX - 2) + 1, random.Next(mapSizeY - 2) + 1);
                    size = new Position(random.Next(5) + 3, random.Next(5) + 3);

                    if (position.x + size.x < 0 || position.x + size.x >= mapSizeX || position.y + size.y < 0 || position.y + size.y >= mapSizeY)
                        continue;

                    done = true;
                } while (!done);
                rooms.Add((position, size));
            }

            foreach((Position position, Position size) room in rooms)
            {
                for (int y = room.position.y; y < room.position.y + room.size.y; y++)
                {
                    for (int x = room.position.x; x < room.position.x + room.size.x; x++)
                    {
                        map[y, x] = true;
                    }
                }
            }

            bool[,] check = new bool[mapSizeY, mapSizeX];
            for(int i = 0; i <mapSizeY; i++)
            {
                for(int j = 0; j < mapSizeX; j++)
                {
                    check[j, i] = true;
                }
            }
            List<Position> path;
            for (int i = 0; i < roomCount; i++)
            {
                for(int j = i + 1; j < roomCount; j++)
                {
                    if(!AStar.PathFinding(map, rooms[i].position, rooms[j].position, out path))
                    {
                        AStar.PathFinding(check, rooms[i].position, rooms[j].position, out path);
                        foreach (Position road in path)
                        {
                            map[road.y, road.x] = true;
                        }
                    }
                }
            }
        }

        static void SetPlayer()
        {
            while (true)
            {
                int y = random.Next(map.GetLength(0));
                int x = random.Next(map.GetLength(1));

                if (map[y, x])
                {
                    player.position = new Position(x, y);
                    return;
                }
            }
        }

        static void SetMonster()
        {
            Slime slime = new Slime();
            monsters.Add(slime);
            Zombie zombie = new Zombie();
            monsters.Add(zombie);
            Centaurs centaurs = new Centaurs();
            monsters.Add(centaurs);
            Gremrin gremrin = new Gremrin();
            monsters.Add(gremrin);
        }

        static void SetItem()
        {
            Potion potion = new Potion();
            items.Add(potion);
            PowerPotion powerPotion = new PowerPotion();
            items.Add(powerPotion);
            ConsPotion consPotion = new ConsPotion();
            items.Add(consPotion);
            WarriorPotion warriorPotion = new WarriorPotion();
            items.Add(warriorPotion);
            WizardPotion wizardPotion = new WizardPotion();
            items.Add(wizardPotion);
        }

        public static Monster MonsterInPos(Position position)
        {
            return monsters.Find(target => target.position.x == position.x && target.position.y == position.y);
        }

        public static bool IsObjectInPos(Position pos)
        {
            return MonsterInPos(pos) == null && ItemInPos(pos) == null;
        }

        public static Item ItemInPos(Position pos)
        {
            foreach (Item item in items)
            {
                if (item.position.x == pos.x &&
                    item.position.y == pos.y)
                {
                    return item;
                }
            }
            return null;
        }

    }
}
