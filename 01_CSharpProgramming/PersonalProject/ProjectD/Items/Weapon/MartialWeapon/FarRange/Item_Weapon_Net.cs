using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_ProjectD.Items.Weapons.MartialWeapon.FarRange
{
    internal class Item_Weapon_Net : Item_Armor
    {
        public Item_Weapon_Net()
        {
            itemName = "그물";
            itemPrice = 10000;
            itemWeight = 3;
            weaponDice = 0;
            weaponRange = 2;
            weaponType = WeaponType.군용무기;
        }
    }
}
