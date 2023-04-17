using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_ProjectD.Items.Armors.LightArmor
{
    internal class Item_Armor_PaddedArmor : Item_Armor
    {
        public Item_Armor_PaddedArmor()
        {
            itemName = "패디드 아머";
            itemPrice = 50000;
            itemWeight = 8;
            armorAC = 11;
            neededStrength = 0;
            armorType = ArmorType.경장갑옷;
            baseStatus = StatusType.민첩;
        }
    }
}
