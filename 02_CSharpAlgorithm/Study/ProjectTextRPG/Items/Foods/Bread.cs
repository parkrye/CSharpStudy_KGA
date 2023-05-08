namespace ProjectTextRPG
{
    public class Bread : Item
    {
        private int point = 10;

        public Bread(int floor) : base(floor)
        {
            point += floor;
            icon = 'Ｆ';
            name = "빵";
            description = $"굶주림을 {point} 해소시킨다";
            weight = 1;
            price = 2;
        }

        public override bool Use()
        {
            Console.WriteLine($"굶주림을 {point} 해소시킨다");
            Thread.Sleep(500);
            Data.player.Eat(point);
            if (Data.player.Hunger < 20)
                Console.WriteLine($"죽다 살았다!");
            else if (Data.player.Hunger < 60)
                Console.WriteLine($"정말 배고팠는데!");
            else if (Data.player.Hunger < 100)
                Console.WriteLine($"맛있다!");
            else if (Data.player.Hunger < 140)
                Console.WriteLine($"배가 부르다..");
            else if (Data.player.Hunger < 180)
                Console.WriteLine($"배가 터지겠다..");
            Thread.Sleep(500);
            return true;
        }
    }
}
