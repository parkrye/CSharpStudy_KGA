using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_ProjectD.Items.Weapons.MartialWeapon.CloseRange
{
    internal class Item_Weapon_Trident : Item_Armor
    {
        public Item_Weapon_Trident()
        {
            itemName = "삼지창";
            itemPrice = 50000;
            itemWeight = 4;
            weaponDice = 6;
            weaponRange = 1;
            weaponType = WeaponType.군용무기;
        }
    }
}
