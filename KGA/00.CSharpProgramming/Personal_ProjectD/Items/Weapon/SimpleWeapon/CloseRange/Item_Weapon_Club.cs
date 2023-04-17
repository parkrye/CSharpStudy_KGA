using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_ProjectD.Items.Weapons.SimpleWeapon.CloseRange
{
    internal class Item_Weapon_Club : Item_Armor
    {
        public Item_Weapon_Club()
        {
            itemName = "곤봉";
            itemPrice = 100;
            itemWeight = 2;
            weaponDice = 4;
            weaponRange = 1;
            weaponType = WeaponType.단순무기;
        }
    }
}
