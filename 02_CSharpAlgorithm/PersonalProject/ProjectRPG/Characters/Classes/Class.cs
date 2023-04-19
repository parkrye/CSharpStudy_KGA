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
        protected PerkSlot perks;

        public string NAME
        {
            get { return name; }
            set { name = value; }
        }

        public PerkSlot PERKS
        {
            get { return perks; }
            set { perks = value; }
        }
    }
}
