using System.IO;

namespace ProjectRPG
{
    internal class Dungeon_Sea : Dungeon
    {
        public Dungeon_Sea(Player player) : base(player)
        {
            name = "해안 던전";
            depth = 3;

            EnemySetting();
            ItemSetting();
            FloorSetting();
            BossSetting();
        }

        protected override Party EnemySetting()
        {
            Party party = new Party();
            int num = new Random().Next(4) + 1;
            for (int j = 0; j < num; j++)
            {
                switch (new Random().Next(4))
                {
                    case 0:
                        party.AddPC(new Monster_ArmoredTurtle(j + 1));
                        break;
                    case 1:
                        party.AddPC(new Monster_Merman(j + 1));
                        break;
                    case 2:
                        party.AddPC(new Monster_SeaGhost(j + 1));
                        break;
                    case 3:
                        party.AddPC(new Monster_BoneFish(j + 1));
                        break;
                }
            }
            return party;
        }

        protected override Item ItemSetting()
        {

            switch (new Random().Next(10))
            {
                case 0:
                    return new Item_HPPotion1();
                case 1:
                    return new Item_SPPotion1();
                case 2:
                    return new Item_HPPotion2();
                case 3:
                    return new Item_SPPotion2();
                default:
                    return new Item_BronzeCoin();
            }
        }

        protected override void FloorSetting()
        {
            for (int i = 0; i < depth; i++)
            {
                Queue<DungeonRoom> room = new Queue<DungeonRoom>();
                for (int j = 0; j < 10; j++)
                {
                    Party enemy = EnemySetting();
                    Item item = ItemSetting();

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
            boss.AddPC(new Monster_Seaserpent());
            Item bossDrop = new Item_Trident();

            bossRoom = new BossRoom(player, boss, bossDrop);
        }

        protected override void BossCutScene()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Thread.Sleep(100);
            Console.WriteLine("　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　");
            Console.WriteLine("　□□□　　　□□　　□　　□　　□□□　□□□□　□□□　　");
            Thread.Sleep(50);
            Console.WriteLine("　□　　□　□　　□　□　　□　□　　　　□　　　　□　　□　");
            Thread.Sleep(50);
            Console.WriteLine("　□　　□　□　　□　□□　□　□　　　　□　　　　□　　□　");
            Thread.Sleep(50);
            Console.WriteLine("　□　　□　□□□□　□□　□　□　　　　□□□□　□□□　　");
            Thread.Sleep(50);
            Console.WriteLine("　□　　□　□　　□　□　□□　□　□□　□　　　　□　　□　");
            Thread.Sleep(50);
            Console.WriteLine("　□　　□　□　　□　□　□□　□　　□　□　　　　□　　□　");
            Thread.Sleep(50);
            Console.WriteLine("　□　　□　□　　□　□　　□　□　　□　□　　　　□　　□　");
            Thread.Sleep(50);
            Console.WriteLine("　□□□　　□　　□　□　　□　　□□□　□□□□　□　　□　");
            Console.WriteLine("　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　");
            Thread.Sleep(50);
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　");
            Console.WriteLine("　■■■　　　■■　　■　　■　　■■■　■■■■　■■■　　");
            Thread.Sleep(50);
            Console.WriteLine("　■　　■　■　　■　■　　■　■　　　　■　　　　■　　■　");
            Thread.Sleep(50);
            Console.WriteLine("　■　　■　■　　■　■■　■　■　　　　■　　　　■　　■　");
            Thread.Sleep(50);
            Console.WriteLine("　■　　■　■■■■　■■　■　■　　　　■■■■　■■■　　");
            Thread.Sleep(50);
            Console.WriteLine("　■　　■　■　　■　■　■■　■　■■　■　　　　■　　■　");
            Thread.Sleep(50);
            Console.WriteLine("　■　　■　■　　■　■　■■　■　　■　■　　　　■　　■　");
            Thread.Sleep(50);
            Console.WriteLine("　■　　■　■　　■　■　　■　■　　■　■　　　　■　　■　");
            Thread.Sleep(50);
            Console.WriteLine("　■■■　　■　　■　■　　■　　■■■　■■■■　■　　■　");
            Console.WriteLine("　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　");
            Thread.Sleep(50);
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　");
            Console.WriteLine("　□□□　　　□□　　□　　□　　□□□　□□□□　□□□　　");
            Thread.Sleep(50);
            Console.WriteLine("　□　　□　□　　□　□　　□　□　　　　□　　　　□　　□　");
            Thread.Sleep(50);
            Console.WriteLine("　□　　□　□　　□　□□　□　□　　　　□　　　　□　　□　");
            Thread.Sleep(50);
            Console.WriteLine("　□　　□　□□□□　□□　□　□　　　　□□□□　□□□　　");
            Thread.Sleep(50);
            Console.WriteLine("　□　　□　□　　□　□　□□　□　□□　□　　　　□　　□　");
            Thread.Sleep(50);
            Console.WriteLine("　□　　□　□　　□　□　□□　□　　□　□　　　　□　　□　");
            Thread.Sleep(50);
            Console.WriteLine("　□　　□　□　　□　□　　□　□　　□　□　　　　□　　□　");
            Thread.Sleep(50);
            Console.WriteLine("　□□□　　□　　□　□　　□　　□□□　□□□□　□　　□　");
            Console.WriteLine("　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　");
            Thread.Sleep(50);
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　");
            Console.WriteLine("　■■■　　　■■　　■　　■　　■■■　■■■■　■■■　　");
            Thread.Sleep(50);
            Console.WriteLine("　■　　■　■　　■　■　　■　■　　　　■　　　　■　　■　");
            Thread.Sleep(50);
            Console.WriteLine("　■　　■　■　　■　■■　■　■　　　　■　　　　■　　■　");
            Thread.Sleep(50);
            Console.WriteLine("　■　　■　■■■■　■■　■　■　　　　■■■■　■■■　　");
            Thread.Sleep(50);
            Console.WriteLine("　■　　■　■　　■　■　■■　■　■■　■　　　　■　　■　");
            Thread.Sleep(50);
            Console.WriteLine("　■　　■　■　　■　■　■■　■　　■　■　　　　■　　■　");
            Thread.Sleep(50);
            Console.WriteLine("　■　　■　■　　■　■　　■　■　　■　■　　　　■　　■　");
            Thread.Sleep(50);
            Console.WriteLine("　■■■　　■　　■　■　　■　　■■■　■■■■　■　　■　");
            Console.WriteLine("　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　");
            Thread.Sleep(50);
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　");
            Console.WriteLine("　□□□　　　□□　　□　　□　　□□□　□□□□　□□□　　");
            Thread.Sleep(50);
            Console.WriteLine("　□　　□　□　　□　□　　□　□　　　　□　　　　□　　□　");
            Thread.Sleep(50);
            Console.WriteLine("　□　　□　□　　□　□□　□　□　　　　□　　　　□　　□　");
            Thread.Sleep(50);
            Console.WriteLine("　□　　□　□□□□　□□　□　□　　　　□□□□　□□□　　");
            Thread.Sleep(50);
            Console.WriteLine("　□　　□　□　　□　□　□□　□　□□　□　　　　□　　□　");
            Thread.Sleep(50);
            Console.WriteLine("　□　　□　□　　□　□　□□　□　　□　□　　　　□　　□　");
            Thread.Sleep(50);
            Console.WriteLine("　□　　□　□　　□　□　　□　□　　□　□　　　　□　　□　");
            Thread.Sleep(50);
            Console.WriteLine("　□□□　　□　　□　□　　□　　□□□　□□□□　□　　□　");
            Console.WriteLine("　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　");
            Thread.Sleep(50);
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　");
            Console.WriteLine("　■■■　　　■■　　■　　■　　■■■　■■■■　■■■　　");
            Thread.Sleep(50);
            Console.WriteLine("　■　　■　■　　■　■　　■　■　　　　■　　　　■　　■　");
            Thread.Sleep(50);
            Console.WriteLine("　■　　■　■　　■　■■　■　■　　　　■　　　　■　　■　");
            Thread.Sleep(50);
            Console.WriteLine("　■　　■　■■■■　■■　■　■　　　　■■■■　■■■　　");
            Thread.Sleep(50);
            Console.WriteLine("　■　　■　■　　■　■　■■　■　■■　■　　　　■　　■　");
            Thread.Sleep(50);
            Console.WriteLine("　■　　■　■　　■　■　■■　■　　■　■　　　　■　　■　");
            Thread.Sleep(50);
            Console.WriteLine("　■　　■　■　　■　■　　■　■　　■　■　　　　■　　■　");
            Thread.Sleep(50);
            Console.WriteLine("　■■■　　■　　■　■　　■　　■■■　■■■■　■　　■　");
            Console.WriteLine("　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　");
            Thread.Sleep(100);
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
            for(int i = 9; i >= 0; i--)
            {
                Thread.Sleep(50);
                Console.SetCursorPosition(0, i);
                Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
            }
            for (int i = 29; i >= 0; i-=2)
            {
                Thread.Sleep(25);
                Console.SetCursorPosition(i, 7);
                Console.WriteLine("　　");
                if(i < 29)
                {
                    Console.SetCursorPosition(i + 2, 7);
                    Console.WriteLine("■■");
                }
            }
            Console.SetCursorPosition(0, 7);
            Console.WriteLine("■■");
            for (int i = 0; i < 26; i+=4)
            {
                Thread.Sleep(25);
                Console.SetCursorPosition(i, 4);
                Console.WriteLine("　　　　");
                Console.WriteLine("　　　　");
                Console.WriteLine("　　　　");
                if(i > 0)
                {
                    Console.SetCursorPosition(i - 4, 4);
                    Console.WriteLine("■■■■");
                    Console.WriteLine("■■■■");
                    Console.WriteLine("■■■■");
                }
            }
            Console.SetCursorPosition(26, 4);
            Console.WriteLine("■■■■");
            Console.WriteLine("■■■■");
            Console.WriteLine("■■■■");
            Thread.Sleep(500);
            Console.Clear();
        }
    }
}
