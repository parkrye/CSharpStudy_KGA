using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_ProjectD.Items.Armors.HeavyArmor
{
    internal class Item_Armor_ChainMail : Item_Armor
    {
        public Item_Armor_ChainMail()
        {
            itemName = "체인 메일";
            itemPrice = 750000;
            itemWeight = 55;
            armorAC = 16;
            neededStrength = 13;
            armorType = ArmorType.중장갑옷;
            baseStatus = StatusType.없음;
        }
    }
}
