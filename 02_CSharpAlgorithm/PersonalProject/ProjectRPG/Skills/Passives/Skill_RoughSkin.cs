namespace ProjectRPG
{
    /// <summary>
    /// 패시브 스킬을 상속한 상세 스킬 클래스
    /// </summary>
    internal class Skill_RoughSkin : Skill_Passive
    {
        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="_level">스킬 레벨. 기본 1</param>
        /// <param name="_exp">스킬 경험치. 기본 0</param>
        public Skill_RoughSkin(int _level = 1, int _exp = 0) : base()
        {
            name = "질긴 피부";
            level = _level;
            exp = _exp;
            value = 1.5f;
            cost = 1;
        }

        /// <summary>
        /// 캐릭터의 이벤트에 메소드를 구독하는 메소드
        /// </summary>
        /// <param name="character">대상 캐릭터</param>
        public override void AddListener(Character character)
        {
            if (character != null)
                character.AddListenerOnDamaged(Active);
        }

        /// <summary>
        /// 캐릭터의 이벤트를 구독할 메소드
        /// </summary>
        /// <param name="param">체력, 활력, [데미지]</param>
        /// <returns>스킬 시전 성공 여부</returns>
        public override bool Cast(params float[] param)
        {
            if (param[2] > value * level)
                param[2] -= value * level;
            else
                param[2] = 1;
            return true;
        }
    }
}
