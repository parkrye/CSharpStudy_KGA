namespace ProjectRPG
{
    internal class Item_WoodenAculpture : Item_None
    {
        public Item_WoodenAculpture() 
        {
            name = "나무 조각품";
            price = 5;
        }

        public override bool Active(int[,] param, params ITargetable[] targets)
        {
            return false;
        }
    }
}
