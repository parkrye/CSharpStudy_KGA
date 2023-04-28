namespace ProjectRPG
{
    /// <summary>
    /// 액티브 스킬을 상속한 상세 스킬 클래스
    /// </summary>
    internal class Skill_LuckyAttack : Skill_Active, IAttackable
    {
        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="_level">스킬 레벨. 기본 1</param>
        /// <param name="_exp">스킬 경험치. 기본 0</param>
        public Skill_LuckyAttack(int _level = 1, int _exp = 0) : base()
        {
            name = "(A)행운의 일격";
            level = _level;
            exp = _exp;
            value = 1;
            cost = 5;
        }

        public override bool Active(int[,] param1, params int[] param2)
        {
            if (other != null)
            {
                return Attack(other, param1[1, 2]);
            }
            return false;
        }

        public bool Attack(IHitable hitable, params int[] param)
        {
            if(hitable.Hit(new Random().Next(value * 2 + 1) * param[0] / 2 * level))
            {
                GetEXP(1);
                return true;
            }
            return false;
        }
    }
}
