namespace ProjectRPG
{
    [Serializable]
    internal class Item_WoodenClub : Item_Equipment
    {
        public Item_WoodenClub()
        {
            name = "(E)나무 몽둥이";
            price = 15;
        }

        public override void AddListener(Character character) { }

        public override void Equiped(int[,] param)
        {
            param[0, 2] += 1;
        }

        public override void Removed(int[,] param)
        {
            param[0, 2] -= 1;
        }
    }
}
