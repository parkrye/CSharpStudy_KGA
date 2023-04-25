namespace ProjectRPG
{
    /// <summary>
    /// 패시브 스킬을 상속한 상세 스킬 클래스
    /// </summary>
    internal class Skill_SecondWind : Skill_Passive
    {

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="_level">스킬 레벨. 기본 1</param>
        /// <param name="_exp">스킬 경험치. 기본 0</param>
        public Skill_SecondWind(int _level = 1, int _exp = 0) : base()
        {
            name = "재생의 바람";
            level = _level;
            exp = _exp;
            value = 15;
            cost = 0;
            coolTime = 10;
        }

        /// <summary>
        /// 캐릭터의 이벤트에 메소드를 구독시키는 메소드
        /// </summary>
        /// <param name="character">대상 캐릭터</param>
        public override void AddListener(Character character)
        {
            if(character != null)
            {
                character.AddListenerOnHPDecreased(Active);
                character.AddListenerOnTurnEnd(TimeFlow);
            }
        }

        /// <summary>
        /// 캐릭터의 이벤트를 구독할 메소드
        /// </summary>
        /// <param name="param1">능력치 데이터</param>
        /// <param name="param2">부가 데이터 : X</param>
        /// <returns>스킬 시전 성공 여부</returns>
        public override bool Cast(int[,] param1, params int[] param2)
        {
            if (param1[1,0] > 0)
                return false;
            param1[1,0] += value * level;
            used = true;
            return true;
        }
    }
}
