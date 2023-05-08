namespace ProjectTextRPG
{
    public class Potion : Item
    {
        private int point = 10;

        public Potion(int floor) : base(floor)
        {
            point += floor;
            icon = '㎖';
            name = "포션";
            description = $"체력을 {point} 회복시킨다";
            weight = 1;
            price = 5;
        }

        public override bool Use()
        {
            Console.WriteLine($"포션을 사용하였다");
            Thread.Sleep(500);
            Data.player.Heal(point);
            Console.WriteLine($"체력이 {Data.player.CurHp}이 되었다");
            Thread.Sleep(500);
            return true;
        }
    }
}
