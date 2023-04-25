namespace ProjectRPG
{
    /// <summary>
    /// 직업을 상속한 상세 직업 클래스
    /// </summary>
    internal class Class_Figther : Class
    {
        /// <summary>
        /// 생성자
        /// </summary>
        public Class_Figther()
        {
            name = "장사";
            defaultStatus = new int[5];
            HP = 3;
            SP = 0;
            PHYSICAL = 3;
            MENTAL = 0;
            INITIATIVE = 0;
            skillSlot = new SkillSlot(null, 3);
            skillSlot.AddSkill(new Skill_DashAttack());
            skillSlot.AddSkill(new Skill_SecondWind());
            skillSlot.AddSkill(new Skill_RoughSkin());
        }
    }
}
