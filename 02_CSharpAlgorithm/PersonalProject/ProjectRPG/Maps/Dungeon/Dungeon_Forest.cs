using System.IO;

namespace ProjectRPG
{
    internal class Dungeon_Forest : Dungeon
    {
        public Dungeon_Forest(Player player) : base(player)
        {
            name = "숲 던전";
            depth = 2;

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
                switch (new Random().Next(3))
                {
                    case 0:
                        party.AddPC(new Monster_Skeleton(j + 1));
                        break;
                    case 1:
                        party.AddPC(new Monster_Zombie(j + 1));
                        break;
                    case 2:
                        party.AddPC(new Monster_Vampire(j + 1));
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
            boss.AddPC(new Monster_Necromancer(1));
            boss.AddPC(new Monster_Necromancer(2));
            boss.AddPC(new Monster_Necromancer(3));
            Item bossDrop = new Item_MysteriousRing();

            bossRoom = new BossRoom(player, boss, bossDrop);
        }

        protected override void BossCutScene()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.DarkRed;
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
            Console.WriteLine("　■　　■　　　　■　■　■　　　　　■　■　　　　■　　■　");
            Console.WriteLine("　■　　■　■　　■　■　　■　■　　■　■　　　　■　　■　");
            Console.WriteLine("　■■■　■■■　■　■　　■■■　■■　■　■■■　■　■　");
            Console.WriteLine("　　　　■■■■■　　　　■■■■■　　　　■■■■■　　　　");
            Thread.Sleep(200);
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　");
            Console.WriteLine("　■■■　　　■■　　■　　■　　■■■　■■■■　■■■　　");
            Console.WriteLine("　■　　■　■　　■　■　　■　■　　　　■　　　　■　　■　");
            Console.WriteLine("　■　　■　■　　■　■■　■　■　　　　■　　　　■　　■　");
            Console.WriteLine("　■　　■　　■■■　■■　　　　　　　　■■■■　■■■　　");
            Console.WriteLine("　■　　■　■　　■　■　　■　■　■■　■　　　　■　　■　");
            Console.WriteLine("　■　　　■■■　■　■　　■■■　　■　■　■■■　　　■　");
            Console.WriteLine("　■　　■■■■■　　■　■■■■■　■　　■■■■■　　■　");
            Console.WriteLine("　■■　■■■■■　　　　■■■■■　■　　■■■■■　　■　");
            Console.WriteLine("　　　　■■■■■　　　　■■■■■　　　　■■■■■　　　　");
            Thread.Sleep(200);
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　");
            Console.WriteLine("　■■■　　　■■　　■　　　　　■■■　■■■■　■■■　　");
            Console.WriteLine("　■　　■　■　　■　■　　■　■　　　　■　　　　■　　■　");
            Console.WriteLine("　■　　　■■■　■　■■　■■■　　　　■　■■■　　　■　");
            Console.WriteLine("　■　　■■■■■　　■　■■■■■　　　　■■■■■　■　　");
            Console.WriteLine("　■　　■■■■■　　■　■■■■■　■　　■■■■■　　■　");
            Console.WriteLine("　■　　■■■■■　　■　■■■■■　■　　■■■■■　　■　");
            Console.WriteLine("　■　　■■■■■　　■　■■■■■　■　　■■■■■　　■　");
            Console.WriteLine("　■　■■■■■■■　　■■■■■■■　　■■■■■■■　■　");
            Console.WriteLine("　　　■■■■■■■　　■■■■■■■　　■■■■■■■　　　");
            Thread.Sleep(200);
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　");
            Console.WriteLine("　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　");
            Console.WriteLine("　　　　　　■　　　　　　　■　■　　　　　　　　　　　　　　");
            Console.WriteLine("　　　　　■■■　　　　　　■■■　　　　　　■■■　　　　　");
            Console.WriteLine("　　　　■■■■■　　　　■■■■■　　　　■■■■■　　　　");
            Console.WriteLine("　　　　■■■■■　　　　■■■■■　　　　■■■■■　　　　");
            Console.WriteLine("　　　　■■■■■　　　　■■■■■　　　　■■■■■　　　　");
            Console.WriteLine("　　　　■■■■■　　　　■■■■■　　　　■■■■■　　　　");
            Console.WriteLine("　　　■■■■■■■　　■■■■■■■　　■■■■■■■　　　");
            Console.WriteLine("　　　■■■■■■■　　■■■■■■■　　■■■■■■■　　　");
            Thread.Sleep(200);
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　");
            Console.WriteLine("　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　");
            Console.WriteLine("　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　");
            Console.WriteLine("　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　");
            Console.WriteLine("　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　");
            Console.WriteLine("　　　　　■　■　　　　　　■　■　　　　　　■　■　　　　　");
            Console.WriteLine("　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　");
            Console.WriteLine("　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　");
            Console.WriteLine("　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　");
            Console.WriteLine("　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　");
            Thread.Sleep(500);
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　");
            Console.WriteLine("　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　");
            Console.WriteLine("　　　　　　■　　　　　　　■　■　　　　　　　　　　　　　　");
            Console.WriteLine("　　　　　■■■　　　　　　■■■　　　　　　■■■　　　　　");
            Console.WriteLine("　　　　■■■■■　　　　■■■■■　　　　■■■■■　　　　");
            Console.WriteLine("　　　　■　■　■　　　　■　■　■　　　　■　■　■　　　　");
            Console.WriteLine("　　　　■■■■■　　　　■■■■■　　　　■■■■■　　　　");
            Console.WriteLine("　　　　■■■■■　　　　■■■■■　　　　■■■■■　　　　");
            Console.WriteLine("　　　■■■■■■■　　■■■■■■■　　■■■■■■■　　　");
            Console.WriteLine("　　　■■■■■■■　　■■■■■■■　　■■■■■■■　　　");
            Thread.Sleep(500);
            Console.Clear();
        }
    }
}
