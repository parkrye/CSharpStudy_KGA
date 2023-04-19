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
        Skill[] skills;

        public int SIZE
        {
            get { return size; }
            set { size = value; }
        }
        public Skill[] SKILLS
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
                if (skills[i] == null)
                {
                    skills[i] = skill;
                    
                    return true;
                }
            }

            return false;
        }

        public bool RemoveSkill(int index)
        {
            if (index < 0 || index >= size)
                return false;
            if (skills[index] == null)
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

        public int UseSkill(int index, ITargetable hitable, int sp)
        {
            if (index < 0 || index >= size)
                return 0;
            if (skills[index] == null)
                return 0;
            if (sp < skills[index].COST)
                return 0;

            if (skills[index] is Skill_Active)
                return ((Skill_Active)skills[index]).Active(hitable);
            else
                return 0;
        }
    }
}
