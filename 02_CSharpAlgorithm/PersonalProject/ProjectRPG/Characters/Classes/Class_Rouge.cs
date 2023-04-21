namespace ProjectRPG
{
    /// <summary>
    /// 직업을 상속한 상세 직업 클래스
    /// </summary>
    internal class Class_Rouge : Class
    {
        /// <summary>
        /// 생성자
        /// </summary>
        public Class_Rouge()
        {
            name = "도적";
            defaultStatus = new int[4];
            HP = 2;
            SP = 1;
            PHYSICAL = 1;
            MENTAL = 1;
            skillSlot = new SkillSlot(null, 3);
            skillSlot.AddSkill(new Skill_Arcrobatics());
            skillSlot.AddSkill(new Skill_LuckyAttack());
            skillSlot.AddSkill(new Skill_ThrowDagger());
        }
    }
}
