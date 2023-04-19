using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRPG
{
    internal abstract class Character : ITargetable
    {
        protected string name;
        protected int hp, sp;
        protected PerkSlot perkSlot;

        public string NAME 
        { 
            get { return name; }
            set { name = value; }
        }

        public int HP 
        { 
            get { return hp; } 
            set { hp = value; }
        }

        public int SP 
        { 
            get { return sp; } 
            set { sp = value; }
        }

        public PerkSlot PerkSlot
        {
            get {  return perkSlot; }
            set { perkSlot = value; }
        }

        public void Hit(int damage)
        {
            
        }
    }
}
