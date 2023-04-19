using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRPG
{
    internal abstract class Perk
    {
        protected string name;
        protected int level, exp;
        protected PerkType type;

        public string NAME 
        { 
            get { return name; } 
            set { name = value; }
        }

        public int LEVEL 
        { 
            get { return level; } 
            set { level = value; }
        }

        public PerkType TYPE 
        { 
            get { return type; } 
            set { type = value; }
        }

        protected void GetEXP(int addEXP)
        {
            exp += addEXP;
            while (exp >= level * 100)
                LevelUp();
        }

        void LevelUp()
        {
            exp -= level * 100;
            level++;
        }

        public abstract int Active(ITargetable targetable, params int[] values);
    }
}
