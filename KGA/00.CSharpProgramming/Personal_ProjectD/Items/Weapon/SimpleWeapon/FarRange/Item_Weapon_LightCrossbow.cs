namespace Personal_ProjectD.Items.Weapons.SimpleWeapon.FarRange
{
    internal class Item_Weapon_LightCrossbow : Item_Armor
    {
        public Item_Weapon_LightCrossbow()
        {
            itemName = "라이트 크로스보우";
            itemPrice = 250000;
            itemWeight = 5;
            weaponDice = 8;
            weaponRange = 20;
            weaponType = WeaponType.단순무기;
        }
    }
}
