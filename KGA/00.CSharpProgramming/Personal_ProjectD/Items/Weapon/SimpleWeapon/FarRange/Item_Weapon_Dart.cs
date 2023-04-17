namespace Personal_ProjectD.Items.Weapons.SimpleWeapon.FarRange
{
    internal class Item_Weapon_Dart : Item_Armor
    {
        public Item_Weapon_Dart()
        {
            itemName = "다트";
            itemPrice = 5;
            itemWeight = 1;
            weaponDice = 4;
            weaponRange = 6;
            weaponType = WeaponType.단순무기;
        }
    }
}
