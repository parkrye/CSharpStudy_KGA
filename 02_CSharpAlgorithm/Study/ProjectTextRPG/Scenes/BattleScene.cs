namespace ProjectTextRPG
{
    public class BattleScene : Scene
    {
        Monster monster;

        public BattleScene(Game _game) : base(_game)
        {

        }

        public override void Render()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine($"{monster.name}    {monster.curHp,3}/{monster.maxHp,3}");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"플레이어    {Data.player.CurHp,3}/{Data.player.MaxHp}");
            Console.WriteLine();
        }

        public override void Update()
        {
            for (int i = 0; i < Data.player.skills.Count; i++)
            {
                Console.Write($"{i + 1,2}. {Data.player.skills[i].name} ");
            }
            Console.WriteLine();
            Console.Write("명령을 입력하세요 : ");

            string input = Console.ReadLine();

            int index;
            if (!int.TryParse(input, out index))
            {
                Console.WriteLine("잘못 입력하셨습니다.");
                return;
            }
            if (index < 1 || index > Data.player.skills.Count)
            {
                Console.WriteLine("잘못 입력하셨습니다.");
                return;
            }

            Data.player.skills[index - 1].Active(monster);

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
                game.GameOver();
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

            Console.Clear();
            Console.WriteLine($"{monster.name}(와/과) 전투 시작!");
            Thread.Sleep(1000);
        }

        public void EndBattle()
        {
            Console.Clear();
            Console.WriteLine("전투에서 승리했다!");

            Thread.Sleep(2000);
            game.Map();
        }
    }
}
