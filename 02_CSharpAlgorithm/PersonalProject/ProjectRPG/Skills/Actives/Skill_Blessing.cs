namespace ProjectRPG
{
    /// <summary>
    /// 액티브 스킬을 상속한 상세 스킬 클래스
    /// </summary>
    [Serializable]
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
            value = 0.5f;
            cost = 10;
            rank = 0;
            if (level >= 10)
                RankUp();
        }

        public override bool Active(int[,] param1, ref int param2)
        {
            if (other != null)
            {
                Burf(other, param1[1,3]);
                return true;
            }
            return false;
        }

        public void Burf(Character target, params int[] param)
        {
            target.NOW_PHYSICSAL += (int)(param[0] * value + (level + rank * 10) / 10);
            target.NOW_MENTAL += (int)(param[0] * value + (level + rank * 10) / 10);
            target.NOW_INITIATIVE += (int)(param[0] * value + (level + rank * 10) / 10);
        }

        protected override void RankUp()
        {
            rank++;
            level -= 10;

            switch (rank)
            {
                case 1:
                    name = "(A)축복";
                    break;
                case 2:
                    name = "(A)대축복";
                    break;
            }
        }
    }
}
