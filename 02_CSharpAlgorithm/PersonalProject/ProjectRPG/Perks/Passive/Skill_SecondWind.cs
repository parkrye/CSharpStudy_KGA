using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRPG
{
    internal class Skill_SecondWind : Skill_Passive
    {
        public Skill_SecondWind(int _level = 1, int _exp = 0) : base()
        {
            name = "재생의 바람";
            level = _level;
            exp = _exp;
            value = 3;
            cost = 1;
        }

        public override int Active(ITargetable targetable, params int[] values)
        {
            return value * level;
        }
    }
}
