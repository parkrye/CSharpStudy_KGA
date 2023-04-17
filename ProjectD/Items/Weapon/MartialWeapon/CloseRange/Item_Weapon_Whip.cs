using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_ProjectD.Items.Weapons.MartialWeapon.CloseRange
{
    internal class Item_Weapon_Whip : Item_Armor
    {
        public Item_Weapon_Whip()
        {
            itemName = "채찍";
            itemPrice = 20000;
            itemWeight = 3;
            weaponDice = 4;
            weaponRange = 2;
            weaponType = WeaponType.군용무기;
        }
    }
}
