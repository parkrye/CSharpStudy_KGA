namespace ProjectRPG
{
    internal class Player
    {
        string name;
        int money;

        public string NAME
        {
            get { return name; }
            set { name = value; }
        }

        public int MONEY
        {
            get { return money; }
            set { money = value; }
        }

        public Player(string _name)
        {
            name = _name;
            money = 100;
        }
    }
}
