namespace Personal_ProjectD.Items
{
    public abstract class Item
    {
        protected string itemName;
        protected int itemPrice;
        protected int itemWeight;

        public string GetItemName()
        {
            return itemName;
        }

        public int GetItemPrice()
        {
            return itemPrice;
        }

        public int GetItemWeight()
        {
            return itemWeight;
        }
    }
}
