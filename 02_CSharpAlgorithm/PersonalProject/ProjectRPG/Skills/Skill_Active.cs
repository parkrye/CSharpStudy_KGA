namespace ProjectRPG
{
    /// <summary>
    /// 액티브 스킬에 대한 클래스
    /// </summary>
    internal abstract class Skill_Active : Skill
    {
        // 효과 지속 시간
        protected int duration;

        /// <summary>
        /// 스킬 타입을 결정하는 생성자
        /// </summary>
        public Skill_Active()
        {
            type = SkillType.ACTIVE;
        }

        public abstract override bool Active(int[,] param1, params int[] param2);
    }
}
