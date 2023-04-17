using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_ProjectD.Items.Armors.LightArmor
{
    internal class Item_Armor_LeatherArmor : Item_Armor
    {
        public Item_Armor_LeatherArmor()
        {
            itemName = "레더 아머";
            itemPrice = 100000;
            itemWeight = 10;
            armorAC = 11;
            neededStrength = 0;
            armorType = ArmorType.경장갑옷;
            baseStatus = StatusType.민첩;
        }
    }
}
