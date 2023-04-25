namespace ProjectRPG
{
    /// <summary>
    /// 직업을 상속한 상세 직업 클래스
    /// </summary>
    internal class Class_Hunter : Class
    {
        /// <summary>
        /// 생성자
        /// </summary>
        public Class_Hunter()
        {
            name = "엽사";
            defaultStatus = new int[5];
            HP = 1;
            SP = 1;
            PHYSICAL = 2;
            MENTAL = 1;
            INITIATIVE = 1;
            skillSlot = new SkillSlot(null, 3);

        }
    }
}
