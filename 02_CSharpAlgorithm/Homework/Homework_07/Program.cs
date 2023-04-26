namespace Homework_07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Item> items = new Dictionary<string, Item>();
            Item sword = new Item("검", 10);
            Item shield = new Item("방패", 10);
            Item arrow = new Item("화살", 1);
            Item bow = new Item("활", 15);

            items.Add(sword.name, sword);
            items.Add(shield.name, shield);
            items.Add(arrow.name, arrow);
            items.Add(bow.name, bow);

            if(items.Remove("방패"))
                Console.WriteLine("방패를 제거하였습니다");
            else
                Console.WriteLine("방패를 제거하지 못했습니다");

            if (items.ContainsKey("화살"))
                Console.WriteLine("화살이 존재합니다");
            else
                Console.WriteLine("화살이 존재하지 않습니다");

            Item newSword;
            if (items.TryGetValue("검", out newSword))
                Console.WriteLine("검이 존재합니다");
            else
                Console.WriteLine("검이 존재하지 않습니다");
            Console.WriteLine(newSword.name);
        }

        struct Item
        {
            public string name;
            public int price;

            public Item(string _name, int _price)
            {
                name = _name;
                price = _price;
            }
        }
    }
}