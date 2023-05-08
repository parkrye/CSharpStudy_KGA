namespace ProjectTextRPG
{
    public class Recovery : Skill
    {
        public Recovery()
        {
            name = "회복";

        }

        public override void Active(Monster monster)
        {
            Console.WriteLine($"당신은 {name}으로 회복을 시도했다!");
            Thread.Sleep(500);
            Data.player.Heal(5);
            Console.WriteLine($"체력이 {Data.player.CurHp}가 되었다!");
            Thread.Sleep(500);
        }
    }
}
