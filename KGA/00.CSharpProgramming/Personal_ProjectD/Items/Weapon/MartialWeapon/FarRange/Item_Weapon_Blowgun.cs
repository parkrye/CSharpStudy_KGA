using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_ProjectD.Items.Weapons.MartialWeapon.FarRange
{
    internal class Item_Weapon_Blowgun : Item_Armor
    {
        public Item_Weapon_Blowgun()
        {
            itemName = "바람총";
            itemPrice = 100000;
            itemWeight = 1;
            weaponDice = 1;
            weaponRange = 7;
            weaponType = WeaponType.군용무기;
        }
    }
}
