namespace ProjectRPG
{
    internal class Item_WindBoots : Item_Equipment
    {
        public Item_WindBoots()
        {
            name = "(E)바람 신발";
            price = 20;
        }

        public override void AddListener(Character character) { }

        public override void Equiped(int[,] param)
        {
            param[0, 4] += 3;
        }

        public override void Removed(int[,] param)
        {
            param[0, 4] -= 3;
        }
    }
}
