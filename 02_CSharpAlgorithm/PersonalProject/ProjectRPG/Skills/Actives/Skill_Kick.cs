namespace ProjectRPG
{
    /// <summary>
    /// 액티브 스킬을 상속한 상세 스킬 클래스
    /// </summary>
    [Serializable]
    internal class Skill_Kick : Skill_Active, IAttackable
    {
        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="_level">스킬 레벨. 기본 1</param>
        /// <param name="_exp">스킬 경험치. 기본 0</param>
        public Skill_Kick(int _level = 1, int _exp = 0) : base()
        {
            name = "(A)발차기";
            level = _level;
            exp = _exp;
            value = 1;
            cost = 0;
            rank = 0;
        }

        public override bool Active(int[,] param1, ref int param2)
        {
            if (other != null)
            {
                if (other is IHitable)
                    return Attack(other, param1[1, 2]);
                return false;
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

            switch (rank)
            {
                case 1:
                    name = "(A)하이킥";
                    value += 1;
                    break;
                case 2:
                    name = "(A)섬머솔트 킥";
                    value += 1;
                    break;
            }
        }
    }
}
