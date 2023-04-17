using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_ProjectD.Items.Weapons.MartialWeapon.FarRange
{
    internal class Item_Weapon_HandCrossbow : Item_Armor
    {
        public Item_Weapon_HandCrossbow()
        {
            itemName = "핸드 크로스보우";
            itemPrice = 750000;
            itemWeight = 3;
            weaponDice = 6;
            weaponRange = 8;
            weaponType = WeaponType.군용무기;
        }
    }
}
