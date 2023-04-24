namespace ProjectRPG
{
    internal class Player
    {
        string name;
        int money;

        public string NAME { get { return name; } }

        public int MONEY { get { return money; } }

        public Player(string _name)
        {
            name = _name;
            money = 100;
        }
    }
}
