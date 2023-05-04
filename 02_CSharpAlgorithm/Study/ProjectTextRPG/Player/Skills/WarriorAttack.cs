namespace ProjectTextRPG
{
    public class WarriorAttack : Skill
    {
        public WarriorAttack()
        {
            name = "전사 공격";

        }

        public override void Active(Monster monster)
        {
            Console.WriteLine($"플레이어가 {name}으로 {monster.name}(을/를) 공격한다.");
            monster.TakeDamage(Data.player.AP * 2);
            Thread.Sleep(1000);
        }
    }
}
