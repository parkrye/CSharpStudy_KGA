namespace ProjectTextRPG
{
    public class WizardAttack : Skill
    {
        public WizardAttack()
        {
            name = "마법사 공격";

        }

        public override void Active(Monster monster)
        {
            Console.WriteLine($"당신은 {name}으로 {monster.name}(을/를) 공격했다!");
            Thread.Sleep(500);
            monster.TakeDamage(Data.random.Next(Data.player.AP / 2, Data.player.AP * 2));
            Thread.Sleep(500);
        }
    }
}
