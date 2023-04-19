using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRPG
{
    internal abstract class Skill_Passive : Skill
    {
        public Skill_Passive()
        {
            type = SkillType.PASSIVE;
        }

        public void AddEvent(Func<int, int> func)
        {
            func += Result;
        }

        public void Removevent(Func<int, int> func)
        {
            func -= Result;
        }

        public abstract override int Active(ITargetable targetable, params int[] values);

        public int Result(int values)
        {
            return values;
        }
    }
}
