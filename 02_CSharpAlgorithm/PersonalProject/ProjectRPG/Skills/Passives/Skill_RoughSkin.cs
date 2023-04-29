namespace ProjectRPG
{
    /// <summary>
    /// 패시브 스킬을 상속한 상세 스킬 클래스
    /// </summary>
    [Serializable]
    internal class Skill_RoughSkin : Skill_Passive
    {
        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="_level">스킬 레벨. 기본 1</param>
        /// <param name="_exp">스킬 경험치. 기본 0</param>
        public Skill_RoughSkin(int _level = 1, int _exp = 0) : base()
        {
            name = "(P)질긴 피부";
            level = _level;
            exp = _exp;
            value = 3;
            cost = 0;
            rank = 0;
        }

        public override void AddListener(Character character)
        {
            if (character != null)
                character.AddListenerOnDamaged(Cast);
        }

        public override bool Cast(int[,] param1, ref int param2)
        {
            if (param2 > value * (level + rank * 10))
                param2 -= value * (level + rank * 10);
            else
                param2 = 1;
            return true;
        }

        protected override void RankUp()
        {
            rank++;
            level -= 10;
        }
    }
}
