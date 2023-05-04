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
            Console.WriteLine($"플레이어가 {name}으로 회복을 시도합니다.");
            Thread.Sleep(1000);
            Data.player.Heal(5);
            Console.WriteLine($"플레이어의 체력이 {Data.player.CurHp}가 되었습니다.");
            Thread.Sleep(1000);
        }
    }
}
