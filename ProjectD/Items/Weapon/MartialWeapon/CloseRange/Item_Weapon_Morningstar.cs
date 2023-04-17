using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_ProjectD.Items.Weapons.MartialWeapon.CloseRange
{
    internal class Item_Weapon_Morningstar : Item_Armor
    {
        public Item_Weapon_Morningstar()
        {
            itemName = "모닝스타";
            itemPrice = 150000;
            itemWeight = 4;
            weaponDice = 8;
            weaponRange = 1;
            weaponType = WeaponType.군용무기;
        }
    }
}
