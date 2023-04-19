using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRPG
{
    internal abstract class Class
    {
        protected string name;
        protected SkillSlot skillSlot;
        protected int defaultHP, defaultSP;

        public string NAME
        {
            get { return name; }
            set { name = value; }
        }

        public SkillSlot SKILLSLOT
        {
            get { return skillSlot; }
            set { skillSlot = value; }
        }

        public int HP
        {
            get { return defaultHP; }
            set { defaultHP = value; }
        }

        public int SP
        {
            get { return defaultSP; }
            set { defaultSP = value; }
        }
    }
}
