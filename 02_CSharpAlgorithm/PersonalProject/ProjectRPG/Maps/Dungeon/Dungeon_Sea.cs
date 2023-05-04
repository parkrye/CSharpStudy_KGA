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
                case 4:
                    return new Item_HPPotion3();
                case 5:
                    return new Item_SPPotion3();
                default:
                    return new Item_ShiningShell();
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
            boss.AddPC(new Monster_Seaserpent());
            Item bossDrop = new Item_Trident();
            skillStone = new SkillStone(player, boss.PCs[0].SKILLSLOT.SKILLS);

            bossRoom = new BossRoom(player, boss, bossDrop);
        }

        protected override void BossCutScene()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.DarkBlue;
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
            for (int i = 58; i >= 0; i-=2)
            {
                Thread.Sleep(100);
                Console.SetCursorPosition(i, 7);
                Console.Write("　");
                if(i < 56)
                {
                    Console.SetCursorPosition(i + 4, 7);
                    Console.Write("■");
                }
            }
            Console.SetCursorPosition(0, 7);
            Console.Write("■■");
            for (int i = 0; i < 60; i+=2)
            {
                Thread.Sleep(100);
                Console.SetCursorPosition(i, 4);
                Console.Write("　");
                Console.SetCursorPosition(i, 5);
                Console.Write("　");
                Console.SetCursorPosition(i, 6);
                Console.Write("　");
                if(i > 6)
                {
                    Console.SetCursorPosition(i - 8, 4);
                    Console.Write("■");
                    Console.SetCursorPosition(i - 8, 5);
                    Console.Write("■");
                    Console.SetCursorPosition(i - 8, 6);
                    Console.Write("■");
                }
            }
            Console.SetCursorPosition(52, 4);
            Console.Write("■■■■");
            Console.SetCursorPosition(52, 5);
            Console.Write("■■■■");
            Console.SetCursorPosition(52, 6);
            Console.Write("■■■■");
            Thread.Sleep(500);
            for(int i = 0; i < 4; i++)
            {
                Thread.Sleep(50);
                Console.SetCursorPosition(0, i);
                Console.WriteLine("　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　");
                Console.SetCursorPosition(0, 9 - i);
                Console.WriteLine("　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　");
                Console.SetCursorPosition(0, i + 1);
                Console.WriteLine("　■　■　■　■　■　■　■　■　■　■　■　■　■　■　■　");
                Console.SetCursorPosition(0, 9 - i - 1);
                Console.WriteLine("■　■　■　■　■　■　■　■　■　■　■　■　■　■　■　■");
            }
        }
    }
}
