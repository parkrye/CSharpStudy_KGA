using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_ProjectD.Items.Weapons.MartialWeapon.FarRange
{
    internal class Item_Weapon_LongBow : Item_Armor
    {
        public Item_Weapon_LongBow()
        {
            itemName = "롱보우";
            itemPrice = 500000;
            itemWeight = 2;
            weaponDice = 8;
            weaponRange = 32;
            weaponType = WeaponType.군용무기;
        }
    }
}
