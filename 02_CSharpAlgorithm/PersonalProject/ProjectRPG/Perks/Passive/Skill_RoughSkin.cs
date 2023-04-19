using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRPG
{
    internal class Skill_RoughSkin : Skill_Passive
    {
        public Skill_RoughSkin(int _level = 1, int _exp = 0) : base()
        {
            name = "질긴 피부";
            level = _level;
            exp = _exp;
            value = 1;
            cost = 1;
        }

        public override int Active(ITargetable targetable, params int[] values)
        {
            return Result(value * level);
        }
    }
}
