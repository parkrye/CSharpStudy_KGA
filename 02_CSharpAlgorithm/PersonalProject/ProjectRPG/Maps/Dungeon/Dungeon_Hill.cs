using System.IO;

namespace ProjectRPG
{
    internal class Dungeon_Hill : Dungeon
    {
        public Dungeon_Hill(Player player) : base(player)
        {
            name = "언덕 던전";
            depth = 1;

            EnemySetting();
            ItemSetting();
            FloorSetting();
            BossSetting();
        }

        protected override void EnemySetting()
        {
            for(int i = 0; i < 100; i++)
            {
                Party party = new Party();
                int num = new Random().Next(4) + 1;
                for(int j = 0; j < num; j++)
                {
                    int mon = new Random().Next(4);
                    switch (mon)
                    {
                        case 0:
                            party.AddPC(new Monster_Orc(j + 1));
                            break;
                        default:
                            party.AddPC(new Monster_Goblin(j + 1));
                            break;
                    }
                }
                enemies.party.Add(party);
            }
        }

        protected override void ItemSetting()
        {
            items.items.Add((new Item_HPPotion1()));
            items.items.Add((new Item_SPPotion1()));
            items.items.Add(new Item_WoodenAculpture());
            items.items.Add(new Item_WoodenAculpture());
            items.items.Add(new Item_WoodenAculpture());
            items.items.Add(new Item_WoodenAculpture());
            items.items.Add(new Item_WoodenAculpture());
            items.items.Add(new Item_WoodenAculpture());
            items.items.Add(new Item_WoodenAculpture());
            items.items.Add(new Item_WoodenAculpture());
        }

        protected override void FloorSetting()
        {
            for (int i = 0; i < depth; i++)
            {
                Queue<DungeonRoom> room = new Queue<DungeonRoom>();
                for (int j = 0; j < 10; j++)
                {
                    Enemies tEnemies = enemies;
                    Items tItems = items;

                    Party enemy = tEnemies.party[new Random().Next(enemies.party.Count)];
                    Item item = tItems.items[new Random().Next(items.items.Count)];

                    switch (new Random().Next(5))
                    {
                        case 0:
                            room.Enqueue(new EmptyRoom(player, enemy, item));
                            break;
                        case 1:
                            room.Enqueue(new ChestRoom(player, enemy, item));
                            break;
                        default:
                            room.Enqueue(new BattleRoom(player, enemy, item));
                            break;
                    }
                }
                floors.Enqueue(room);
            }
        }

        protected override void BossSetting()
        {
            Party boss = new Party();
            boss.AddPC(new Monster_Orc(0));
            Item bossDrop = new Item_HPPotion2();

            bossRoom = new BossRoom(player, boss, bossDrop);
        }

        protected override void BossCutScene()
        {
            Console.Clear();
            Thread.Sleep(500);
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Red;
            Thread.Sleep(500);
            Console.WriteLine("　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　");
            Console.WriteLine("　□□□　　　□□　　□　　□　　□□□　□□□□　□□□　　");
            Console.WriteLine("　□　　□　□　　□　□　　□　□　　　　□　　　　□　　□　");
            Console.WriteLine("　□　　□　□　　□　□□　□　□　　　　□　　　　□　　□　");
            Console.WriteLine("　□　　□　□□□□　□□　□　□　　　　□□□□　□□□　　");
            Console.WriteLine("　□　　□　□　　□　□　□□　□　□□　□　　　　□　　□　");
            Console.WriteLine("　□　　□　□　　□　□　□□　□　　□　□　　　　□　　□　");
            Console.WriteLine("　□　　□　□　　□　□　　□　□　　□　□　　　　□　　□　");
            Console.WriteLine("　□□□　　□　　□　□　　□　　□□□　□□□□　□　　□　");
            Console.WriteLine("　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　");
            Thread.Sleep(500);
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　");
            Console.WriteLine("　■■■　　　■■　　■　　■　　■■■　■■■■　■■■　　");
            Console.WriteLine("　■　　■　■　　■　■　　■　■　　　　■　　　　■　　■　");
            Console.WriteLine("　■　　■　■　　■　■■　■　■　　　　■　　　　■　　■　");
            Console.WriteLine("　■　　■　■■■■　■■　■　■　　　　■■■■　■■■　　");
            Console.WriteLine("　■　　■　■　　■　■　■■　■　■■　■　　　　■　　■　");
            Console.WriteLine("　■　　■　■　　■　■　■■　■　　■　■　　　　■　　■　");
            Console.WriteLine("　■　　■　■　　■　■　　■　■　　■　■　　　　■　　■　");
            Console.WriteLine("　■■■　　■　　■　■　　■　　■■■　■■■■　■　　■　");
            Console.WriteLine("　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　");
            Thread.Sleep(500);
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　");
            Console.WriteLine("　□□□　　　□□　　□　　□　　□□□　□□□□　□□□　　");
            Console.WriteLine("　□　　□　□　　□　□　　□　□　　　　□　　　　□　　□　");
            Console.WriteLine("　□　　□　□　　□　□□　□　□　　　　□　　　　□　　□　");
            Console.WriteLine("　□　　□　□□□□　□□　□　□　　　　□□□□　□□□　　");
            Console.WriteLine("　□　　□　□　　□　□　□□　□　□□　□　　　　□　　□　");
            Console.WriteLine("　□　　□　□　　□　□　□□　□　　□　□　　　　□　　□　");
            Console.WriteLine("　□　　□　□　　□　□　　□　□　　□　□　　　　□　　□　");
            Console.WriteLine("　□□□　　□　　□　□　　□　　□□□　□□□□　□　　□　");
            Console.WriteLine("　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　");
            Thread.Sleep(500);
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　");
            Console.WriteLine("　■■■　　　■■　　■　　■　　■■■　■■■■　■■■　　");
            Console.WriteLine("　■　　■　■　　■　■　　■　■　　　　■　　　　■　　■　");
            Console.WriteLine("　■　　■　■　　■　■■　■　■　　　　■　　　　■　　■　");
            Console.WriteLine("　■　　■　■■■■　■■　■　■　　　　■■■■　■■■　　");
            Console.WriteLine("　■　　■　■　　■　■　■■　■　■■　■　　　　■　　■　");
            Console.WriteLine("　■　　■　■　　■　■　■■　■　　■　■　　　　■　　■　");
            Console.WriteLine("　■　　■　■　　■　■　　■　■　　■　■　　　　■　　■　");
            Console.WriteLine("　■■■　　■　　■　■　　■　　■■■　■■■■　■　　■　");
            Console.WriteLine("　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　");
            Thread.Sleep(500);
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　");
            Console.WriteLine("　□□□　　　□□　　□　　□　　□□□　□□□□　□□□　　");
            Console.WriteLine("　□　　□　□　　□　□　　□　□　　　　□　　　　□　　□　");
            Console.WriteLine("　□　　□　□　　□　□□　□　□　　　　□　　　　□　　□　");
            Console.WriteLine("　□　　□　□□□□　□□　□　□　　　　□□□□　□□□　　");
            Console.WriteLine("　□　　□　□　　□　□　□□　□　□□　□　　　　□　　□　");
            Console.WriteLine("　□　　□　□　　□　□　□□　□　　□　□　　　　□　　□　");
            Console.WriteLine("　□　　□　□　　□　□　　□　□　　□　□　　　　□　　□　");
            Console.WriteLine("　□□□　　□　　□　□　　□　　□□□　□□□□　□　　□　");
            Console.WriteLine("　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　");
            Thread.Sleep(500);
            Console.Clear();
        }
    }
}
