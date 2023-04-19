using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRPG
{
    internal class Class_Figther : Class
    {
        public Class_Figther()
        {
            name = "전사";
            defaultHP = 3;
            defaultSP = 3;
            skillSlot = new SkillSlot(null, 2);
            skillSlot.AddSkill(new Skill_SecondWind());
            skillSlot.AddSkill(new Skill_RoughSkin());
        }
    }
}
