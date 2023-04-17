using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_ProjectD.Items.Armors.NormalArmor
{
    internal class Item_Armor_BreastPlate : Item_Armor
    {
        public Item_Armor_BreastPlate()
        {
            itemName = "브레스트 플레이트";
            itemPrice = 4000000;
            itemWeight = 20;
            armorAC = 14;
            neededStrength = 0;
            armorType = ArmorType.평장갑옷;
            baseStatus = StatusType.민첩;
        }
    }
}
