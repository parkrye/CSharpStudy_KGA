namespace ProjectTextRPG
{
    public class WizardPotion : Item
    {        public WizardPotion(int floor) : base(floor)
        {
            icon = '㎖';
            name = "마법사의 포션";
            description = "마법사로 전직한다";
            weight = 1;
            price = 15 + floor;
        }

        public override bool Use()
        {
            Console.WriteLine($"포션을 사용하였다");
            Thread.Sleep(500);
            if (Data.player.AddJob(new Wizard()))
            {
                Console.WriteLine($"당신은 마법사가 되었다");
                Thread.Sleep(500);
                return true;
            }
            else
            {
                Console.WriteLine($"당신은 이미 직업을 갖고 있다");
                Thread.Sleep(500);
                return false;
            }
        }
    }
}
