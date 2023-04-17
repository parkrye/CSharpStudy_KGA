using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_ProjectD.Items.Armors.NormalArmor
{
    internal class Item_Armor_HalfPlate : Item_Armor
    {
        public Item_Armor_HalfPlate()
        {
            itemName = "하프 플레이트";
            itemPrice = 7500000;
            itemWeight = 40;
            armorAC = 15;
            neededStrength = 0;
            armorType = ArmorType.평장갑옷;
            baseStatus = StatusType.민첩;
        }
    }
}
