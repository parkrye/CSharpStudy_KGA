using ProjectRPG.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRPG
{
    internal class Skill_Punch : Skill_Active, IAttackable
    {
        public Skill_Punch(int _level = 1, int _exp = 0) : base()
        {
            name = "주먹질";
            level = _level;
            exp = _exp;
            value = 1;
            cost = 1;
        }

        public override void Active(ref int sp)
        {
            if (other is not null)
            {
                sp -= cost;
                Attack(other);
            }
        }

        public int Attack(ITargetable targetable)
        {
            targetable.Hit(value * level);
            GetEXP(1);
            return cost;
        }
    }
}
