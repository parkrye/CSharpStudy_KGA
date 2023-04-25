namespace ProjectRPG
{
    /// <summary>
    /// 직업을 상속한 상세 직업 클래스
    /// </summary>
    internal class Class_Soccerer : Class
    {
        /// <summary>
        /// 생성자
        /// </summary>
        public Class_Soccerer()
        {
            name = "도사";
            defaultStatus = new int[5];
            HP = 0;
            SP = 3;
            PHYSICAL = 0;
            MENTAL = 3;
            INITIATIVE = 0;
            skillSlot = new SkillSlot(null, 3);

        }
    }
}
