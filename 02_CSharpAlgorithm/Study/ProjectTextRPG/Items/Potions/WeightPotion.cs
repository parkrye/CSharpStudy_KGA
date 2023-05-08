namespace ProjectTextRPG
{
    public class WeightPotion : Item
    {
        public int point;

        public WeightPotion(int floor) : base(floor)
        {
            point += floor;
            icon = '㎖';
            name = "중량 포션";
            description = $"한계 무게가 증가한다";
            weight = 1;
            point = 5;
            price = 10;
        }

        public override bool Use()
        {
            Console.WriteLine($"포션을 사용하였다");
            Thread.Sleep(500);
            Data.player.LimitWeight += point;
            description = $"한계 무게가 증가했다";
            Thread.Sleep(500);
            return true;
        }
    }
}
