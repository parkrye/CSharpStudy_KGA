using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_ProjectD.Items.Armors.HeavyArmor
{
    internal class Item_Armor_RingMail : Item_Armor
    {
        public Item_Armor_RingMail()
        {
            itemName = "링 메일";
            itemPrice = 300000;
            itemWeight = 40;
            armorAC = 14;
            neededStrength = 0;
            armorType = ArmorType.중장갑옷;
            baseStatus = StatusType.없음;
        }
    }
}
