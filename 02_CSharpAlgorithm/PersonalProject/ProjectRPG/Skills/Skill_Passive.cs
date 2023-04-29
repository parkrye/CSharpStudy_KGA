namespace ProjectRPG
{
    /// <summary>
    /// 패시브 스킬에 대한 메소드
    /// </summary>
    [Serializable]
    internal abstract class Skill_Passive : Skill
    {
        protected bool used;     // 사용 여부

        /// <summary>
        /// 스킬 타입을 결정하는 생성자
        /// </summary>
        public Skill_Passive()
        {
            type = SkillType.PASSIVE;
            used = false;
        }

        /// <summary>
        /// 캐릭터의 이벤트에 메소드를 구독시키는 메소드
        /// </summary>
        /// <param name="character">대상 캐릭터</param>
        public abstract void AddListener(Character character);

        public override bool Active(int[,] param1, params int[] param2)
        {
            if (!used)
            {
                if (Cast(param1, param2))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 스킬 시전 메소드
        /// </summary>
        /// <param name="param1">능력치 데이터</param>
        /// <param name="param2">부가 데이터</param>
        /// <returns>변수에 대한 반환값</returns>
        public abstract bool Cast(int[,] param1, params int[] param2);

        /// <summary>
        /// 사용 여부를 초기화하는 메소드
        /// </summary>
        public void Restore()
        {
            used = false;
        }
    }
}
