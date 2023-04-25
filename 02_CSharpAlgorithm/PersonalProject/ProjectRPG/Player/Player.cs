namespace ProjectRPG
{
    internal class Player
    {
        string name;
        int money;
        List<Item> inventory;

        public string NAME { get { return name; } }

        public int MONEY { get { return money; } }

        public List<Item> INVENTORY { get { return inventory; } }

        public Player(string _name)
        {
            name = _name;
            money = 100;
            inventory = new List<Item>();
        }

        public void GetMonsy(int add)
        {
            money += add;
        }

        public void LoseMoney(int lost)
        {
            if (HaveMoney(lost))
                money -= lost;
            money = 0;
        }

        public bool HaveMoney(int comparison)
        {
            if (money >= comparison)
                return true;
            return false;
        }

        public void AddItem(Item item)
        {
            inventory.Add(item);
        }

        public Item RemoveItem(int index)
        {
            Item item = inventory[index];
            inventory.RemoveAt(index);
            return item;
        }
    }
}
