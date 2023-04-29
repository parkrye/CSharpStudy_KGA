namespace ProjectRPG
{
    /// <summary>
    /// 액티브 스킬을 상속한 상세 스킬 클래스
    /// </summary>
    [Serializable]
    internal class Skill_Scratch : Skill_Active, IAttackable
    {
        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="_level">스킬 레벨. 기본 1</param>
        /// <param name="_exp">스킬 경험치. 기본 0</param>
        public Skill_Scratch(int _level = 1, int _exp = 0) : base()
        {
            name = "(A)햘퀴기";
            level = _level;
            exp = _exp;
            value = 1;
            cost = 0;
            rank = 0;
        }

        public override bool Active(int[,] param1, params int[] param2)
        {
            if (other != null)
            {
                return Attack(other, param1[1, 1]);
            }
            return false;
        }

        public bool Attack(IHitable hitable, params int[] param)
        {
            if(hitable.Hit(param[0] * value + (level + rank * 10)))
            {
                GetEXP(1);
                return true;
            }
            return false;
        }

        protected override void RankUp()
        {
            rank++;
            level -= 10;
        }
    }
}
