using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_ProjectD.Items.Weapons.MartialWeapon.FarRange
{
    internal class Item_Weapon_HeavyCrossbow : Item_Armor
    {
        public Item_Weapon_HeavyCrossbow()
        {
            itemName = "헤비 크로스보우";
            itemPrice = 500000;
            itemWeight = 18;
            weaponDice = 10;
            weaponRange = 25;
            weaponType = WeaponType.군용무기;
        }
    }
}
