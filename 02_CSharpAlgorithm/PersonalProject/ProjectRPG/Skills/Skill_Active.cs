namespace ProjectRPG
{
    /// <summary>
    /// 액티브 스킬에 대한 클래스
    /// </summary>
    [Serializable]
    internal abstract class Skill_Active : Skill
    {
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
