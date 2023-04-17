using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_ProjectD.Items.Weapons.MartialWeapon.CloseRange
{
    internal class Item_Weapon_LongSword : Item_Armor
    {
        public Item_Weapon_LongSword()
        {
            itemName = "롱소드";
            itemPrice = 150000;
            itemWeight = 3;
            weaponDice = 8;
            weaponRange = 1;
            weaponType = WeaponType.군용무기;
        }
    }
}
