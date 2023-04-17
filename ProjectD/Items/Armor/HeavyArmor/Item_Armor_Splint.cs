using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_ProjectD.Items.Armors.HeavyArmor
{
    internal class Item_Armor_Splint : Item_Armor
    {
        public Item_Armor_Splint()
        {
            itemName = "스플린트";
            itemPrice = 2000000;
            itemWeight = 60;
            armorAC = 17;
            neededStrength = 15;
            armorType = ArmorType.중장갑옷;
            baseStatus = StatusType.없음;
        }
    }
}
