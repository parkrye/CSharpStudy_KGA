namespace ProjectTextRPG
{
    public class PowerPotion : Item
    {
        private int point = 10;

        public PowerPotion() : base()
        {
            name = "힘의 포션";
            description = $"플레이어의 힘을 {point} 증가시킵니다.";
            weight = 1;
        }

        public override void Use()
        {
            Console.WriteLine($"포션을 사용하여 플레이어의 힘을 {point} 증가시킵니다.");
            Thread.Sleep(1000);
            Data.player.AddStatus(1, point);
            Console.WriteLine($"플레이어의 힘이 {Data.player.AP}이 되었습니다.");
            Thread.Sleep(1000);
        }
    }
}
