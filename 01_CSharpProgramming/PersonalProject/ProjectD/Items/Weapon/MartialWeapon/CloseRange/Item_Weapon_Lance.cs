using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_ProjectD.Items.Weapons.MartialWeapon.CloseRange
{
    internal class Item_Weapon_Lance : Item_Armor
    {
        public Item_Weapon_Lance()
        {
            itemName = "랜스";
            itemPrice = 100000;
            itemWeight = 6;
            weaponDice = 12;
            weaponRange = 2;
            weaponType = WeaponType.군용무기;
        }
    }
}
