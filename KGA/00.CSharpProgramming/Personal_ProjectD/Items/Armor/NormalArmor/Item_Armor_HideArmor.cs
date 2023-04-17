using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_ProjectD.Items.Armors.NormalArmor
{
    internal class Item_Armor_HideArmor : Item_Armor
    {
        public Item_Armor_HideArmor()
        {
            itemName = "하이드 아머";
            itemPrice = 100000;
            itemWeight = 12;
            armorAC = 12;
            neededStrength = 0;
            armorType = ArmorType.평장갑옷;
            baseStatus = StatusType.민첩;
        }
    }
}
