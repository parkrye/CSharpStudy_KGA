using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_ProjectD.Items.Weapons.MartialWeapon.CloseRange
{
    internal class Item_Weapon_Maul : Item_Armor
    {
        public Item_Weapon_Maul()
        {
            itemName = "거대 망치";
            itemPrice = 100000;
            itemWeight = 10;
            weaponDice = 12;
            weaponRange = 1;
            weaponType = WeaponType.군용무기;
        }
    }
}
