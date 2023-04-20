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

        public abstract void AddListener(Character character);

        public override void Active(ref int param)
        {
            Result(ref param);
        }

        public abstract void Result(ref int param);
    }
}
