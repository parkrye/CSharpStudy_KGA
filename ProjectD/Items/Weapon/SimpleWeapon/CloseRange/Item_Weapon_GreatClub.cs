using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_ProjectD.Items.Weapons.SimpleWeapon.CloseRange
{
    internal class Item_Weapon_GreatClub : Item_Armor
    {
        public Item_Weapon_GreatClub()
        {
            itemName = "그레이트 클럽";
            itemPrice = 200;
            itemWeight = 10;
            weaponDice = 8;
            weaponRange = 1;
            weaponType = WeaponType.단순무기;
        }
    }
}
