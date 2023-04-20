namespace ProjectRPG
{
    internal class PC : Character
    {
        public PC(Class c = null)
        {
            Random random = new Random();
            name += (CharacterFirstName)random.Next(0, 50);
            name += (CharacterLastName)random.Next(0, 50);
            name += (CharacterLastName)random.Next(0, 50);

            hp = random.Next(5, 15) + c.HP;
            sp = random.Next(5, 15) + c.SP;

            skillSlot = new SkillSlot(this, 6);
            skillSlot.AddSkill(new Skill_Punch());
            skillSlot.AddSkill(new Skill_Kick());
            if (c != null)
            {
                int num = random.Next(c.SKILLSLOT.SKILLS.Length + 1);
                while (num < c.SKILLSLOT.SKILLS.Length && c.SKILLSLOT.SKILLS[num] != null)
                {
                    skillSlot.AddSkill(c.SKILLSLOT.SKILLS[num]);
                    c.SKILLSLOT.SKILLS[num] = null;
                    num = random.Next(num + 1);
                }
            }
        }
    }
}
