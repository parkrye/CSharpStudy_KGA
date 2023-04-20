using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRPG
{
    internal class SkillSlot
    {
        Character character;
        int size;
        Skill[]? skills;

        public int SIZE
        {
            get { return size; }
            set { size = value; }
        }
        public Skill[]? SKILLS
        {
            get { return skills; }
            set { skills = value; }
        }

        public SkillSlot(Character _character, int _size)
        {
            character = _character;
            size = _size;
            skills = new Skill[size];
        }

        public bool AddSkill(Skill skill)
        {
            if (skill == null)
                return false;

            for(int i = 0; i < size; i++)
            {
                if (skills is not null && skills[i] == null)
                {
                    skills[i] = skill;
                    if (skills[i] is Skill_Passive)
                    {
                        character.AddListener(skills[i].Active);
                    }
                    return true;
                }
            }

            return false;
        }

        public bool RemoveSkill(int index)
        {
            if (index < 0 || index >= size)
                return false;
            if (skills is null || skills[index] == null)
                return false;

            skills[index] = null;
            return true;
        }

        public void ResizeSlot(int count)
        {
            Skill[] newSkills;
            if (size <= 0)
                newSkills = new Skill[1];
            else
                newSkills = new Skill[size + count];
            Array.Copy(skills, newSkills, size);
            size += count;
        }

        public void UseSkill(int index, ITargetable hitable, ref int sp)
        {
            if (index < 0 || index >= size)
                return;
            if (skills[index] == null)
                return;
            if (sp < skills[index].COST)
                return;

            if (skills[index] is Skill_Active)
            {
                if (sp < skills[index].COST)
                    return;
                skills[index].SetTarget(hitable);
                skills[index].Active(ref sp);
                skills[index].ResetTarget();
            }
        }
    }
}
