using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_ProjectD.Items.Weapons.MartialWeapon.CloseRange
{
    internal class Item_Weapon_Halberd : Item_Armor
    {
        public Item_Weapon_Halberd()
        {
            itemName = "할버드";
            itemPrice = 200000;
            itemWeight = 6;
            weaponDice = 10;
            weaponRange = 2;
            weaponType = WeaponType.군용무기;
        }
    }
}
