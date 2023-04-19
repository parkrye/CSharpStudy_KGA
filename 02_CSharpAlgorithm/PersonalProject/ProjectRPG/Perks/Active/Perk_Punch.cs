using ProjectRPG.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRPG
{
    internal class Perk_Punch : Perk_Active, IAttackable
    {
        public Perk_Punch(int _level = 1, int _exp = 0) : base()
        {
            name = "주먹질";
            level = _level;
            exp = _exp;
            value = 1;
            cost = 1;
        }

        public override int Active(int sp, ITargetable targetable)
        {
            return Attack(sp, targetable);
        }

        public int Attack(int sp, ITargetable targetable)
        {
            if (sp < cost)
                return 0;
            targetable.Hit(value * level);
            GetEXP(1);
            return cost;
        }
    }
}
