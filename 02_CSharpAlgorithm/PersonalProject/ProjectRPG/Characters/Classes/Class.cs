using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRPG
{
    internal abstract class Class
    {
        protected string? name;
        protected SkillSlot? skillSlot;
        protected float defaultHP, defaultSP;

        public string? NAME
        {
            get { return name; }
            set { name = value; }
        }

        public SkillSlot? SKILLSLOT
        {
            get { return skillSlot; }
            set { skillSlot = value; }
        }

        public float HP
        {
            get { return defaultHP; }
            set { defaultHP = value; }
        }

        public float SP
        {
            get { return defaultSP; }
            set { defaultSP = value; }
        }
    }
}
