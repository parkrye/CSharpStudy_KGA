using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_ProjectD.Items.Weapons.MartialWeapon.CloseRange
{
    internal class Item_Weapon_Pike : Item_Armor
    {
        public Item_Weapon_Pike()
        {
            itemName = "파이크";
            itemPrice = 50000;
            itemWeight = 18;
            weaponDice = 10;
            weaponRange = 2;
            weaponType = WeaponType.군용무기;
        }
    }
}
