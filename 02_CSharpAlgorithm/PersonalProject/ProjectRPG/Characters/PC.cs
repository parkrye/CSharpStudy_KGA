namespace ProjectRPG
{
    /// <summary>
    /// 플레이 가능한 캐릭터에 대한 클래스
    /// </summary>
    internal class PC : Character
    {
        /// <summary>
        /// 무직업 생성자
        /// </summary>
        public PC()
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
            StatusSetting(true);

            // 스킬 슬롯은 일반적으로 최대 3
            SKILLSLOT = new SkillSlot(this, 3);
            SKILLSLOT.AddSkill(new Skill_Punch());
            SKILLSLOT.AddSkill(new Skill_Kick());

            // 아이템 슬롯은 일반적으로 최대 3
            ITEMSLOT = new ItemSlot(this, 3);
            ITEMSLOT.AddItem(new Item_HPPotion1());
        }

        /// <summary>
        /// 직업 생성자
        /// </summary>
        /// <param name="c">캐릭터의 직업</param>
        public PC(Class c) : base()
        {
            Random random = new Random();

            // 직업 스테이터스 획득
            MAX_HP += c.HP;
            MAX_SP += c.SP;
            MAX_PHYSICSAL += c.PHYSICAL;
            MAX_MENTAL += c.MENTAL;
            MAX_INITIATIVE += c.INITIATIVE;

            StatusSetting(true);
            for (int i = 0; i < 5; i++)
                DIFFICULTY += status[0, i] / 10;

            // 직업 스킬을 랜덤하게 획득
            int num = random.Next(c.SKILLSLOT.SKILLS.Length + 1);
            while (num < c.SKILLSLOT.SKILLS.Length && c.SKILLSLOT.SKILLS[num] != null)
            {
                SKILLSLOT.AddSkill(c.SKILLSLOT.SKILLS[num]);
                c.SKILLSLOT.RemoveSkill(num);
                num = random.Next(num + 1);
                DIFFICULTY += 1;
            }
        }

        /// <summary>
        /// 직업 추가 메소드
        /// </summary>
        /// <param name="c">추가할 직업</param>
        public void SetClass(Class c)
        {
            Random random = new Random();

            // 직업 스테이터스 획득
            MAX_HP += c.HP;
            MAX_SP += c.SP;
            MAX_PHYSICSAL += c.PHYSICAL;
            MAX_MENTAL += c.MENTAL;
            MAX_INITIATIVE += c.INITIATIVE;

            StatusSetting(true);
            for (int i = 0; i < 5; i++)
                DIFFICULTY += status[0, i] / 10;

            // 직업 스킬을 랜덤하게 획득
            int num = random.Next(c.SKILLSLOT.SKILLS.Length + 1);
            while (num < c.SKILLSLOT.SKILLS.Length && c.SKILLSLOT.SKILLS[num] != null)
            {
                SKILLSLOT.AddSkill(c.SKILLSLOT.SKILLS[num]);
                c.SKILLSLOT.RemoveSkill(num);
                num = random.Next(num + 1);
                DIFFICULTY += 1;
            }
        }
    }
}
