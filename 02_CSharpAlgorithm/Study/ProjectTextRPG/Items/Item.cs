namespace ProjectTextRPG
{
    public abstract class Item
    {
        public string name;
        public string description;
        public char icon = '★';
        public Position position;
        public int weight;

        public Item() 
        {
            while (true)
            {
                int y = Data.random.Next(Data.map.GetLength(0));
                int x = Data.random.Next(Data.map.GetLength(1));

                if (Data.map[y, x])
                {
                    position = new Position(x, y);
                    return;
                }
            }
        }

        public abstract void Use();
    }
}
