namespace HomeWork_11
{
    internal class Program
    {
        static void HW11Main(string[] args)
        {
            // 문제 1 - 4.
            Console.WriteLine("문제 1 - 4.");
            Player player = new Player();
            SFX sfx = new SFX(player);
            VFX vfx = new VFX(player);
            UI ui = new UI(player);
            player.GetDamage();
            Console.WriteLine();
            player.RemoveListener(sfx.PlaySound1);
            player.GetHeal();
            Console.WriteLine();

            // 문제 5.
            Console.WriteLine("문제 5.");
            Armor armor = new Armor(player);
            player.GetDamage(10);
            player.GetDamage(50);
            player.GetDamage(10);
            Console.WriteLine();

            Console.WriteLine("문제 5-2.");
            Armor armor2 = new Armor(player);
            player.TakeOnArmor(armor2);
            player.GetDamage3(20);
            player.GetDamage3(50);
            player.GetDamage3(10);
            Console.WriteLine();

            // 문제 6.
            Console.WriteLine("문제 6.");
            ActiveSkill qSkill = new ActiveSkill(30);
            ActiveSkill wSkill = new ActiveSkill(10);
            ActiveSkill eSkill = new ActiveSkill(20);
            ActiveSkill rSkill = new ActiveSkill(60);
            PassiveSkill passive = new PassiveSkill(player);
            player.SetActiveSkill(0, qSkill);
            player.SetActiveSkill(1, wSkill);
            player.SetActiveSkill(2, eSkill);
            player.SetActiveSkill(3, rSkill);
            player.UseSkill(0);
            player.UseSkill(1);
            player.UseSkill(2);
            player.UseSkill(3);
        }
    }
}