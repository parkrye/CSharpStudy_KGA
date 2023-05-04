namespace ProjectTextRPG
{
    public class ConsPotion : Item
    {
        private int point = 10;

        public ConsPotion() : base()
        {
            name = "방어의 포션";
            description = $"플레이어의 방어를 {point} 증가시킵니다.";
            weight = 1;
        }

        public override void Use()
        {
            Console.WriteLine($"포션을 사용하여 플레이어의 방어를 {point} 증가시킵니다.");
            Thread.Sleep(1000);
            Data.player.AddStatus(2, point);
            Console.WriteLine($"플레이어의 방어가 {Data.player.DP}이 되었습니다.");
            Thread.Sleep(1000);
        }
    }
}
