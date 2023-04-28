namespace ProjectRPG
{
    /// <summary>
    /// 액티브 스킬을 상속한 상세 스킬 클래스
    /// </summary>
    internal class Skill_Blessing : Skill_Active, IBurfable
    {
        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="_level">스킬 레벨. 기본 1</param>
        /// <param name="_exp">스킬 경험치. 기본 0</param>
        public Skill_Blessing(int _level = 1, int _exp = 0) : base()
        {
            name = "(A)축성";
            level = _level;
            exp = _exp;
            value = 1;
            cost = 10;
            rank = 0;
        }

        public override bool Active(int[,] param1, params int[] param2)
        {
            if (other != null)
            {
                Burf(other);
                return true;
            }
            return false;
        }

        public void Burf(Character target)
        {
            target.NOW_PHYSICSAL += value + (level + rank * 10) / 10;
            target.NOW_MENTAL += value + (level + rank * 10) / 10;
            target.NOW_INITIATIVE += value + (level + rank * 10) / 10;
        }

        protected override void RankUp()
        {
            rank++;
            level -= 10;

            switch (rank)
            {
                case 1:
                    name = "(A)축복";
                    value += 2;
                    cost += 3;
                    break;
                case 2:
                    name = "(A)대축복";
                    value += 2;
                    cost += 3;
                    break;
            }
        }
    }
}
