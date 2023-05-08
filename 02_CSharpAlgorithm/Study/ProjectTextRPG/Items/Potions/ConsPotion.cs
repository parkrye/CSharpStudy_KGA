namespace ProjectTextRPG
{
    public class ConsPotion : Item
    {
        private int point = 1;

        public ConsPotion(int floor) : base(floor)
        {
            point += floor;
            icon = '㎖';
            name = "방어의 포션";
            description = $"방어를 {point} 증가시킨다";
            weight = 1;
            price = 10;
        }

        public override bool Use()
        {
            Console.WriteLine($"포션을 사용하였다");
            Thread.Sleep(500);
            Data.player.AddStatus(2, point);
            Console.WriteLine($"방어가 {Data.player.DP}이 되었다");
            Thread.Sleep(500);
            return true;
        }
    }
}
