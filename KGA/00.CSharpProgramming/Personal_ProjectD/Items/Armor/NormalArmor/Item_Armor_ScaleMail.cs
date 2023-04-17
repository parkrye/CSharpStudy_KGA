using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_ProjectD.Items.Armors.NormalArmor
{
    internal class Item_Armor_ScaleMail : Item_Armor
    {
        public Item_Armor_ScaleMail()
        {
            itemName = "스케일 메일";
            itemPrice = 500000;
            itemWeight = 45;
            armorAC = 14;
            neededStrength = 0;
            armorType = ArmorType.평장갑옷;
            baseStatus = StatusType.민첩;
        }
    }
}
