namespace ProjectTextRPG
{
    public class WarriorPotion : Item
    {
        private int point = 10;

        public WarriorPotion() : base()
        {
            name = "전사의 포션";
            description = "플레이어는 전사로 전직합니다.";
            weight = 1;
        }

        public override void Use()
        {
            Console.WriteLine($"포션을 사용하여 플레이어는 전사로 전직합니다.");
            Thread.Sleep(1000);
            new Warrior().AddJob();
            Console.WriteLine($"플레이어가 전사가 되었습니다.");
            Thread.Sleep(1000);
        }
    }
}
