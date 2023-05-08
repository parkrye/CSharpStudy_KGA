namespace ProjectTextRPG
{
    public class BattleScene : Scene
    {
        Monster monster;
        int cursor;

        public BattleScene(Game _game) : base(_game)
        {

        }

        public override void Render()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine($"[{monster.name}    {monster.curHp,3}/{monster.maxHp,3}]");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"[플레이어    {Data.player.CurHp,3}/{Data.player.MaxHp}]");
            Console.WriteLine();
        }

        public override void Update()
        {
            for (int i = 0; i < Data.player.skills.Count; i++)
            {
                if(cursor == i) Console.ForegroundColor = ConsoleColor.Green;
                else Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"[{Data.player.skills[i].name}] ");
            }
            Console.WriteLine("\n");

            bool action = false;
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.LeftArrow:
                    cursor--;
                    if (cursor < 0)
                        cursor = Data.player.skills.Count - 1;
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.RightArrow:
                    cursor++;
                    if (cursor >= Data.player.skills.Count)
                        cursor = 0;
                    break;
                case ConsoleKey.Enter:
                    Console.ForegroundColor = ConsoleColor.White;
                    Data.player.skills[cursor].Active(monster);
                    action = true;
                    break;
            }

            if (!action)
                return;

            // 턴 결과
            if (monster.curHp <= 0)
            {
                game.Map();
                return;
            }

            // 몬스터 턴
            monster.Attack(Data.player);

            // 턴 결과
            if (Data.player.CurHp <= 0)
            {
                game.GameOver(monster.deadCause);
                return;
            }
            else
            {
                Data.player.AddEXP(monster.maxHp + monster.ap + monster.dp);
            }
        }

        public void BattleStart(Monster monster)
        {
            this.monster = monster;
            Data.monsters.Remove(monster);
            cursor = 0;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.WriteLine($"[{monster.name}(와/과) 전투 시작!]");
            Thread.Sleep(500);
        }

        public void EndBattle()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("[전투에서 승리했다!]");

            Thread.Sleep(500);
            Console.Clear();
            game.Map();
        }
    }
}
