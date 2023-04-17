namespace Personal_ProjectD.Items.Armors
{
    internal class Item_Armor_Shield : Item_Armor
    {
        public Item_Armor_Shield()
        {
            itemName = "방패";
            itemPrice = 100000;
            itemWeight = 6;
            armorAC = 2;
            neededStrength = 0;
            armorType = ArmorType.방패;
            baseStatus = StatusType.없음;
        }
    }
}
