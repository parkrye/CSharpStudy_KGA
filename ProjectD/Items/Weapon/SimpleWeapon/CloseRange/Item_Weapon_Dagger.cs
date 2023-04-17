using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_ProjectD.Items.Weapons.SimpleWeapon.CloseRange
{
    internal class Item_Weapon_Dagger : Item_Armor
    {
        public Item_Weapon_Dagger()
        {
            itemName = "대거";
            itemPrice = 20000;
            itemWeight = 1;
            weaponDice = 4;
            weaponRange = 1;
            weaponType = WeaponType.단순무기;
        }
    }
}
