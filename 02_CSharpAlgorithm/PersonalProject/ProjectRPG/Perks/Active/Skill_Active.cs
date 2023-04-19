using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRPG
{
    internal abstract class Skill_Active : Skill
    {
        public Skill_Active()
        {
            type = SkillType.ACTIVE;
        }

        public abstract override int Active(ITargetable targetable, params int[] values);
    }
}
