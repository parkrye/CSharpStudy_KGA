namespace ProjectTextRPG
{
    public class Key : Item
    {
        public Key(int floor) : base(floor)
        {
            icon = '¶';
            name = "열쇠";
            description = $"다음 층으로의 문을 연다";
            weight = 1;
            price = 100;
        }

        public override bool Use()
        {
            Console.WriteLine($"이 아이템은 사용할 수 없다");
            Thread.Sleep(500);
            return false;
        }
    }
}
