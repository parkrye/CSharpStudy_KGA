namespace ProjectRPG
{
    /// <summary>
    /// 직업을 상속한 상세 직업 클래스
    /// </summary>
    internal class Class_Figther : Class
    {
        /// <summary>
        /// 전사 생성자
        /// </summary>
        public Class_Figther()
        {
            name = "전사";
            defaultHP = 3;
            defaultSP = 3;
            skillSlot = new SkillSlot(null, 3);
            skillSlot.AddSkill(new Skill_SecondWind());
            skillSlot.AddSkill(new Skill_RoughSkin());
            skillSlot.AddSkill(new Skill_DeepBreath());
        }
    }
}
