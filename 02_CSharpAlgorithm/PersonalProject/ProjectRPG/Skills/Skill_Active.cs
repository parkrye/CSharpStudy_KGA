namespace ProjectRPG
{
    /// <summary>
    /// 액티브 스킬에 대한 클래스
    /// </summary>
    internal abstract class Skill_Active : Skill
    {
        /// <summary>
        /// 생성자
        /// </summary>
        public Skill_Active()
        {
            type = SkillType.ACTIVE;
        }

        /// <summary>
        /// 스킬 사용에 대한 메소드
        /// </summary>
        /// <param name="param1">능력치 데이터</param>
        /// <param name="param2">부가 데이터</param>
        /// <returns>스킬 발동 성공 여부</returns>
        public abstract override bool Active(int[] param1, params int[] param2);
    }
}
