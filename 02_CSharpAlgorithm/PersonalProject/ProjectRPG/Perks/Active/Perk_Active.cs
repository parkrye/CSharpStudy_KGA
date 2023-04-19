using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRPG
{
    internal abstract class Perk_Active : Perk
    {
        protected int value;
        protected int cost;

        public Perk_Active()
        {
            type = PerkType.ACTIVE;
        }

        public abstract override int Active(ITargetable targetable, params int[] values);
    }
}
