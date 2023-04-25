namespace ProjectRPG
{
    /// <summary>
    /// 플레이 가능한 캐릭터에 대한 클래스
    /// </summary>
    internal class PC : Character
    {
        /// <summary>
        /// PC 생성자
        /// </summary>
        /// <param name="c">캐릭터의 직업</param>
        public PC(Class c = null)
        {
            Random random = new Random();

            // 이름은 랜덤으로 생성
            name += (CharacterFirstName)random.Next(0, 50);
            name += (CharacterLastName)random.Next(0, 50);
            name += (CharacterLastName)random.Next(0, 50);

            // 능력치는 5~15 + 직업 기초 능력치
            status = new int[2, 5];
            MAX_HP = random.Next(5, 15);
            MAX_SP = random.Next(5, 15);
            MAX_PHYSICSAL = random.Next(5, 15);
            MAX_MENTAL = random.Next(5, 15);
            MAX_INITIATIVE = random.Next(5, 15);
            if (c != null)
            {
                MAX_HP += c.HP;
                MAX_SP += c.SP;
                MAX_PHYSICSAL += c.PHYSICAL;
                MAX_MENTAL += c.MENTAL;
                MAX_INITIATIVE += c.INITIATIVE;
            }
            StatusSetting(true);

            // 스킬 슬롯은 일반적으로 최대 3
            skillSlot = new SkillSlot(this, 3);
            skillSlot.AddSkill(new Skill_Punch());
            skillSlot.AddSkill(new Skill_Kick());
            if (c != null)
            {
                // 직업 스킬을 랜덤하게 획득
                int num = random.Next(c.SKILLSLOT.SKILLS.Length + 1);
                while (num < c.SKILLSLOT.SKILLS.Length && c.SKILLSLOT.SKILLS[num] != null)
                {
                    skillSlot.AddSkill(c.SKILLSLOT.SKILLS[num]);
                    c.SKILLSLOT.RemoveSkill(num);
                    num = random.Next(num + 1);
                }
            }

            // 아이템 슬롯은 일반적으로 최대 3
            itemSlot = new ItemSlot(this, 3);
            itemSlot.AddItem(new Item_HPPotion1());
        }
    }
}
