namespace Personal_ProjectD.Items.Weapons.SimpleWeapon.FarRange
{
    internal class Item_Weapon_Sling : Item_Armor
    {
        public Item_Weapon_Sling()
        {
            itemName = "슬링";
            itemPrice = 100;
            itemWeight = 0;
            weaponDice = 4;
            weaponRange = 8;
            weaponType = WeaponType.단순무기;
        }
    }
}
