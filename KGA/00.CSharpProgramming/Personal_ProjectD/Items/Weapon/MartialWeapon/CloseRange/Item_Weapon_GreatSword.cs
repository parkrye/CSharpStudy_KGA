using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_ProjectD.Items.Weapons.MartialWeapon.CloseRange
{
    internal class Item_Weapon_GreatSword : Item_Armor
    {
        public Item_Weapon_GreatSword()
        {
            itemName = "그레이트 소드";
            itemPrice = 500000;
            itemWeight = 6;
            weaponDice = 12;
            weaponRange = 1;
            weaponType = WeaponType.군용무기;
        }
    }
}
