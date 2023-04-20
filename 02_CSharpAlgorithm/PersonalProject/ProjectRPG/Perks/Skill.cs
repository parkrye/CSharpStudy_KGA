using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRPG
{
    internal abstract class Skill
    {
        protected ITargetable? self, other;

        protected string? name;
        protected int level, exp;
        protected SkillType type;

        protected float value, cost;

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

        public SkillType TYPE 
        { 
            get { return type; } 
            set { type = value; }
        }

        public float VALUE
        {
            get { return value; }
            set { this.value = value; }
        }

        public float COST
        {
            get { return cost; }
            set { cost = value; }
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

        public abstract void Active(float param);

        public void SetUser(ITargetable targetable)
        {
            self = targetable;
        }

        public void SetTarget(ITargetable targetable)
        {
            other = targetable;
        }

        public void ResetTarget()
        {
            other = null;
        }
    }
}
