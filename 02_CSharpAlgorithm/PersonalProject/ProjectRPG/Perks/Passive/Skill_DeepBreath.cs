using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRPG
{
    internal class Skill_DeepBreath : Skill_Passive
    {
        public Skill_DeepBreath(int _level = 1, int _exp = 0) : base()
        {
            name = "숨 고르기";
            level = _level;
            exp = _exp;
            value = 1.5f;
            cost = 1;
        }

        public override void AddListener(Character character)
        {
            if (character is not null)
                character.AddListenerOnSPDecreased(Result);
        }

        public override float Result(float param)
        {
            if (param > 0)
                return 0;
            return value * level;
        }
    }
}
