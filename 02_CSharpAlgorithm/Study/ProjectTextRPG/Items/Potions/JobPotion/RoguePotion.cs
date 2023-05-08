namespace ProjectTextRPG
{
    public class RoguePotion : Item
    {
        public RoguePotion(int floor) : base(floor)
        {
            icon = '㎖';
            name = "도적의 포션";
            description = "도적으로 전직한다";
            weight = 1;
            price = 15 + floor;
        }

        public override bool Use()
        {
            Console.WriteLine($"포션을 사용하였다");
            Thread.Sleep(500);
            if (Data.player.AddJob(new Rogue()))
            {
                Console.WriteLine($"당신은 도적이 되었다");
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
