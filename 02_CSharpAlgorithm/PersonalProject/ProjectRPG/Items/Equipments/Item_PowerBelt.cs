namespace ProjectRPG
{
    internal class Item_PowerBelt : Item_Equipment
    {
        public Item_PowerBelt()
        {
            name = "(E)힘의 벨트";
            price = 20;
        }

        public override void AddListener(Character character) { }

        public override void Equiped(int[,] param)
        {
            param[0, 2] += 2;
        }

        public override void Removed(int[,] param)
        {
            param[0, 2] -= 2;
        }
    }
}
