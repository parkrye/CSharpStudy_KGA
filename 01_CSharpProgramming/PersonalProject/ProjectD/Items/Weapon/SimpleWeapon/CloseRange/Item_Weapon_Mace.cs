using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_ProjectD.Items.Weapons.SimpleWeapon.CloseRange
{
    internal class Item_Weapon_Mace : Item_Armor
    {
        public Item_Weapon_Mace()
        {
            itemName = "철퇴";
            itemPrice = 50000;
            itemWeight = 4;
            weaponDice = 6;
            weaponRange = 1;
            weaponType = WeaponType.단순무기;
        }
    }
}
