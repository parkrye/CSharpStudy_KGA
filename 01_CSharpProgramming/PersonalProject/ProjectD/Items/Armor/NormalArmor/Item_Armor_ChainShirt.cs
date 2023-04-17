using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_ProjectD.Items.Armors.NormalArmor
{
    internal class Item_Armor_ChainShirt : Item_Armor
    {
        public Item_Armor_ChainShirt()
        {
            itemName = "체인 셔츠";
            itemPrice = 500000;
            itemWeight = 20;
            armorAC = 13;
            neededStrength = 0;
            armorType = ArmorType.평장갑옷;
            baseStatus = StatusType.민첩;
        }
    }
}
