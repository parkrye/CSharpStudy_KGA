using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_ProjectD.Items.Armors.HeavyArmor
{
    internal class Item_Armor_FullPlate : Item_Armor
    {
        public Item_Armor_FullPlate()
        {
            itemName = "풀 플레이트";
            itemPrice = 15000000;
            itemWeight = 65;
            armorAC = 18;
            neededStrength = 15;
            armorType = ArmorType.중장갑옷;
            baseStatus = StatusType.없음;
        }
    }
}
