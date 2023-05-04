namespace ProjectTextRPG
{
    public class Attack : Skill
    {
        public Attack()
        {
            name = "공격";

        }

        public override void Active(Monster monster)
        {
            Console.WriteLine($"플레이어가 {name}으로 {monster.name}(을/를) 공격한다.");
            monster.TakeDamage(Data.player.AP);
            Thread.Sleep(1000);
        }
    }
}
