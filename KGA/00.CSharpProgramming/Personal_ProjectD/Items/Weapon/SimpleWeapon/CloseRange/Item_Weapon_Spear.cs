using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_ProjectD.Items.Weapons.SimpleWeapon.CloseRange
{
    internal class Item_Weapon_Spear : Item_Armor
    {
        public Item_Weapon_Spear()
        {
            itemName = "창";
            itemPrice = 10000;
            itemWeight = 3;
            weaponDice = 6;
            weaponRange = 1;
            weaponType = WeaponType.단순무기;
        }
    }
}
