namespace ProjectRPG
{
    /// <summary>
    /// 직업을 상속한 상세 직업 클래스
    /// </summary>
    internal class Class_Clown : Class
    {
        /// <summary>
        /// 생성자
        /// </summary>
        public Class_Clown()
        {
            defaultStatus = new int[5];
            HP = 1;
            SP = 1;
            PHYSICAL = 1;
            MENTAL = 1;
            INITIATIVE = 2;
            skillSlot = new SkillSlot(null, 2);
            skillSlot.AddSkill(new Skill_Arcrobatics());
            skillSlot.AddSkill(new Skill_LuckyAttack());
        }
    }
}
