using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_ProjectD.Items.Weapons.MartialWeapon.CloseRange
{
    internal class Item_Weapon_Rapier : Item_Armor
    {
        public Item_Weapon_Rapier()
        {
            itemName = "레이피어";
            itemPrice = 250000;
            itemWeight = 2;
            weaponDice = 8;
            weaponRange = 1;
            weaponType = WeaponType.군용무기;
        }
    }
}
