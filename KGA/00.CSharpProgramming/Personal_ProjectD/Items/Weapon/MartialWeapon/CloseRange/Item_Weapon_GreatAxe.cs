using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_ProjectD.Items.Weapons.MartialWeapon.CloseRange
{
    internal class Item_Weapon_GreatAxe : Item_Armor
    {
        public Item_Weapon_GreatAxe()
        {
            itemName = "그레이트 액스";
            itemPrice = 300000;
            itemWeight = 7;
            weaponDice = 12;
            weaponRange = 1;
            weaponType = WeaponType.군용무기;
        }
    }
}
