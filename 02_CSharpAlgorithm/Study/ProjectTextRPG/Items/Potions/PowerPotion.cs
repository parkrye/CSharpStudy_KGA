namespace ProjectTextRPG
{
    public class PowerPotion : Item
    {
        private int point = 1;

        public PowerPotion(int floor) : base(floor)
        {
            point += floor;
            icon = '㎖';
            name = "힘의 포션";
            description = $"플레이어의 힘을 {point} 증가시킨다";
            weight = 1;
            price = 10;
        }

        public override bool Use()
        {
            Console.WriteLine($"포션을 사용하였다");
            Thread.Sleep(500);
            Data.player.AddStatus(1, point);
            Console.WriteLine($"힘이 {Data.player.AP}이 되었다");
            Thread.Sleep(500);
            return true;
        }
    }
}
