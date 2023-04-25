namespace ProjectRPG
{
    internal class Item_BronzeCoin : Item_None
    {
        public Item_BronzeCoin() 
        {
            name = "구리 동전";
            price = 3;
        }

        public override bool Active(int[,] param, params ITargetable[] targets)
        {
            return false;
        }
    }
}
