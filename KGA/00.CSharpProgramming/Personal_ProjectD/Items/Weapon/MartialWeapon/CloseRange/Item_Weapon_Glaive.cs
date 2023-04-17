using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_ProjectD.Items.Weapons.MartialWeapon.CloseRange
{
    internal class Item_Weapon_Glaive : Item_Armor
    {
        public Item_Weapon_Glaive()
        {
            itemName = "글레이브";
            itemPrice = 200000;
            itemWeight = 6;
            weaponDice = 10;
            weaponRange = 1;
            weaponType = WeaponType.군용무기;
        }
    }
}
