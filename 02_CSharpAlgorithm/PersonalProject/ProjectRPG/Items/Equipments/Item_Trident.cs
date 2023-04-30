namespace ProjectRPG
{
    [Serializable]
    internal class Item_Trident : Item_Equipment
    {
        public Item_Trident()
        {
            name = "(E)삼지창";
            price = 50;
        }

        public override void AddListener(Character character) { }

        public override void Equiped(int[,] param)
        {
            param[0, 2] += 10;
            param[0, 4] += 10;
        }

        public override void Removed(int[,] param)
        {
            param[0, 2] -= 10;
            param[0, 4] -= 10;
        }
    }
}
