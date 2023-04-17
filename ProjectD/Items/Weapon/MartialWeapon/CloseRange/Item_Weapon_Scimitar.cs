using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_ProjectD.Items.Weapons.MartialWeapon.CloseRange
{
    internal class Item_Weapon_Scimitar : Item_Armor
    {
        public Item_Weapon_Scimitar()
        {
            itemName = "시미터";
            itemPrice = 250000;
            itemWeight = 3;
            weaponDice = 6;
            weaponRange = 1;
            weaponType = WeaponType.군용무기;
        }
    }
}
