namespace ProjectRPG
{
    /// <summary>
    /// 패시브 스킬인 숨 고르기에 대한 클래스
    /// </summary>
    internal class Skill_DeepBreath : Skill_Passive
    {
        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="_level">스킬 레벨. 기본 1</param>
        /// <param name="_exp">스킬 경험치. 기본 0</param>
        public Skill_DeepBreath(int _level = 1, int _exp = 0) : base()
        {
            name = "숨 고르기";
            level = _level;
            exp = _exp;
            value = 1.5f;
            cost = 1;
        }

        /// <summary>
        /// 캐릭터의 이벤트에 메소드를 구독하는 메소드
        /// </summary>
        /// <param name="character">캐릭터</param>
        public override void AddListener(Character character)
        {
            if (character is not null)
                character.AddListenerOnSPDecreased(Result);
        }

        /// <summary>
        /// 캐릭터의 이벤트를 구독할 메소드
        /// </summary>
        /// <param name="param">활력</param>
        /// <returns>회복할 활력</returns>
        public override float Result(float param)
        {
            if (param > 0)
                return 0;
            return value * level;
        }
    }
}
