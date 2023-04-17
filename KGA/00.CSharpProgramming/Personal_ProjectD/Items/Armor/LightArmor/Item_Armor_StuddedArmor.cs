using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_ProjectD.Items.Armors.LightArmor
{
    internal class Item_Armor_StuddedArmor : Item_Armor
    {
        public Item_Armor_StuddedArmor()
        {
            itemName = "스터디드 아머";
            itemPrice = 450000;
            itemWeight = 13;
            armorAC = 12;
            neededStrength = 0;
            armorType = ArmorType.경장갑옷;
            baseStatus = StatusType.민첩;
        }
    }
}
