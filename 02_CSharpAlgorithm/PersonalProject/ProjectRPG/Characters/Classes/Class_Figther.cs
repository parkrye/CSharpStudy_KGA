using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRPG
{
    internal class Class_Figther : Class
    {
        public Class_Figther()
        {
            name = "전사";
            perks = new PerkSlot(10);
            perks.AddPerk(new Perk_Punch());
            perks.AddPerk(new Perk_Kick());
        }
    }
}
