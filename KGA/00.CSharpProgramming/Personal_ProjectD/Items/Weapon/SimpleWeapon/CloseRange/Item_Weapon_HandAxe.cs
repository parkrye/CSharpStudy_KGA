using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_ProjectD.Items.Weapons.SimpleWeapon.CloseRange
{
    internal class Item_Weapon_HandAxe : Item_Armor
    {
        public Item_Weapon_HandAxe()
        {
            itemName = "손도끼";
            itemPrice = 50000;
            itemWeight = 2;
            weaponDice = 6;
            weaponRange = 1;
            weaponType = WeaponType.단순무기;
        }
    }
}
