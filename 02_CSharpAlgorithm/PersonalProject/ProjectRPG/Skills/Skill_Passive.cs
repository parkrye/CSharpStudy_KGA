namespace ProjectRPG
{
    /// <summary>
    /// 패시브 스킬에 대한 메소드
    /// </summary>
    internal abstract class Skill_Passive : Skill
    {
        protected bool used;    // 사용 여부

        /// <summary>
        /// 생성자
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

        /// <summary>
        /// 스킬 발동 메소드
        /// </summary>
        /// <param name="param">주어지는 변수</param>
        /// <returns>스킬 발동 성공 여부</returns>
        public override bool Active(params float[] param)
        {
            if (!used)
            {
                if (Cast(param))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 스킬 시전 메소드
        /// </summary>
        /// <param name="param">주어지는 변수</param>
        /// <returns>변수에 대한 반환값</returns>
        public abstract bool Cast(params float[] param);

        /// <summary>
        /// 사용 여부를 초기화하는 메소드
        /// </summary>
        public void Restore()
        {
            used = false;
        }
    }
}
