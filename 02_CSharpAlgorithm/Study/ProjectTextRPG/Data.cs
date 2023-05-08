using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ProjectTextRPG
{
    public static class Data
    {
        public static Game game;
        public static Random random;
        public static bool[,] map;
        public static Player player;
        public static List<Monster> monsters;
        public static List<Item> items;
        public static List<Item> shop;
        public static List<Event> events;
        public static int floor;
        public static int high;
        static string path = "record.json";

        public static void init(Game _game)
        {
            game = _game;
            random = new Random();
            player = new Player();
            monsters = new List<Monster>();
            items = new List<Item>();
            shop = new List<Item>();
            events = new List<Event>();
            if (File.Exists(path))
            {
                using (StreamReader file = File.OpenText(path))
                {
                    using (JsonTextReader reader = new JsonTextReader(file))
                    {
                        JObject json = (JObject)JToken.ReadFrom(reader);
                        high = (int)json["record"];
                    }

                }
            }
            else
                high = 0;
            floor = 1;
        }

        public static void Release()
        {
            if(floor > high)
            {
                JObject record = new JObject(new JProperty("record", floor));
                if (!File.Exists(path))
                {
                    using (File.Create(path)) ;
                }

                File.WriteAllText(path, record.ToString());
            }
        }

        public static void CreateLevel()
        {
            CreateMap();
            SetPlayer();
            SetMonster();
            SetItem();
            SetFood();
            SetEvent();
        }

        static void CreateMap()
        {
            int roomCount = floor * 10;
            List<(Position position, Position size)> rooms = new List<(Position position, Position size)>();

            int mapSizeX = roomCount * 5, mapSizeY = roomCount * 5;
            map = new bool[mapSizeY, mapSizeX];
            for (int i = 0; i < roomCount; i++)
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
            int monsterCount = random.Next(5, 10);
            for(int i = 0; i < monsterCount; i++)
            {
                switch(random.Next(4))
                {
                    case 0:
                        monsters.Add(new Slime(floor));
                        break;
                    case 1:
                        monsters.Add(new Zombie(floor));
                        break;
                    case 2:
                        monsters.Add(new Centaurs(floor));
                        break;
                    case 3:
                        monsters.Add(new Gremrin(floor));
                        break;
                }
            }
            if (floor % 5 == 0)
            {
                for(int i = 5; i <= floor; i += 5)
                    monsters.Add(new Demon(floor));
            }
        }

        static void SetItem()
        {
            int itemCount = random.Next(5, 10);
            for (int i = 0; i < itemCount; i++)
            {
                switch (random.Next(6))
                {
                    case 0:
                        items.Add(new Potion(floor));
                        break;
                    case 1:
                        items.Add(new PowerPotion(floor));
                        break;
                    case 2:
                        items.Add(new ConsPotion(floor));
                        break;
                    case 3:
                        items.Add(new WarriorPotion(floor));
                        break;
                    case 4:
                        items.Add(new WizardPotion(floor));
                        break;
                    case 5:
                        items.Add(new WeightPotion(floor));
                        break;
                }
            }
            items.Add(new Key(floor));
        }

        static void SetFood()
        {
            int foodCount = random.Next(floor * 5, floor * 10);
            for (int i = 0; i < foodCount; i++)
            {
                switch (random.Next(4))
                {
                    case 0:
                        items.Add(new Bread(floor));
                        break;
                    case 1:
                        items.Add(new Cake(floor));
                        break;
                    case 2:
                        items.Add(new Donut(floor));
                        break;
                    case 3:
                        items.Add(new Pie(floor));
                        break;
                }
            }
        }

        static void SetEvent()
        {
            events.Add(new NextFloorEvent());
            if (random.Next(5) == 0)
                events.Add(new MerchantMevent());
            for(int i = 0; i < floor * 5; i++)
            {
                if (random.Next(3) == 0)
                    events.Add(new CoinEvnet());
            }
        }

        public static Monster MonsterInPos(Position position)
        {
            return monsters.Find(target => target.position.x == position.x && target.position.y == position.y);
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

        public static Event EventInPos(Position pos)
        {
            foreach (Event evt in events)
            {
                if (evt.position.x == pos.x &&
                    evt.position.y == pos.y)
                {
                    return evt;
                }
            }
            return null;
        }

        public static void CreatShop()
        {
            shop.Clear();
            int productCount = floor <= 8 ? floor + 2 : 10;
            for(int i = 0; i < productCount; i++)
            {
                switch (random.Next(20))
                {
                    case 0:
                    case 1:
                    case 2:
                    case 3:
                        shop.Add(new Potion(floor));
                        break;
                    case 4:
                        shop.Add(new ConsPotion(floor));
                        break;
                    case 5:
                        shop.Add(new PowerPotion(floor));
                        break;
                    case 6: 
                        shop.Add(new WarriorPotion(floor));
                        break;
                    case 7:
                        shop.Add(new WizardPotion(floor));
                        break;
                    case 8:
                        shop.Add(new Potion(floor));
                        break;
                    case 9:
                        shop.Add(new WeightPotion(floor));
                        break;
                    case 10:
                    case 11:
                    case 12:
                    case 13:
                        shop.Add(new Donut(floor));
                        break;
                    case 14:
                    case 15:
                    case 16:
                        shop.Add(new Bread(floor));
                        break;
                    case 17:
                    case 18:
                        shop.Add(new Pie(floor));
                        break;
                    case 19:
                        shop.Add(new Cake(floor));
                        break;
                }
            }
        }
    }
}
