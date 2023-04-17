namespace Personal_ProjectD.Items.Weapons.SimpleWeapon.FarRange
{
    internal class Item_Weapon_ShortBow : Item_Armor
    {
        public Item_Weapon_ShortBow()
        {
            itemName = "숏보우";
            itemPrice = 250000;
            itemWeight = 2;
            weaponDice = 6;
            weaponRange = 20;
            weaponType = WeaponType.단순무기;
        }
    }
}
