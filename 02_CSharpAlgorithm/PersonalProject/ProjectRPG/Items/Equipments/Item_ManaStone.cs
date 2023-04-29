namespace ProjectRPG
{
    [Serializable]
    internal class Item_ManaStone : Item_Equipment
    {
        public Item_ManaStone()
        {
            name = "(E)마력석";
            price = 20;
        }

        public override void AddListener(Character character) { }

        public override void Equiped(int[,] param)
        {
            param[0, 1] += 1;
        }

        public override void Removed(int[,] param)
        {
            param[0, 1] -= 1;
        }
    }
}
