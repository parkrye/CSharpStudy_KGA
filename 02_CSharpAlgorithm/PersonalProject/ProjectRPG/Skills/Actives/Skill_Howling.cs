namespace ProjectRPG
{
    /// <summary>
    /// 액티브 스킬을 상속한 상세 스킬 클래스
    /// </summary>
    [Serializable]
    internal class Skill_Howling : Skill_Active, IBurfable, IHealable
    {
        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="_level">스킬 레벨. 기본 1</param>
        /// <param name="_exp">스킬 경험치. 기본 0</param>
        public Skill_Howling(int _level = 1, int _exp = 0) : base()
        {
            name = "(A)하울링";
            level = _level;
            exp = _exp;
            value = 1;
            cost = 10;
            rank = 0;
            if (level >= 10)
                RankUp();
        }

        public override bool Active(int[,] param1, ref int param2)
        {
            if (other != null)
            {
                Burf(self);
                Heal(self);
                return true;
            }
            return false;
        }

        public void Burf(Character target, params int[] param)
        {
            target.NOW_PHYSICSAL += target.MAX_PHYSICSAL / 10 + level + rank * 10;
            target.NOW_MENTAL += target.MAX_MENTAL / 10 + level + rank * 10;
            target.NOW_INITIATIVE += target.MAX_INITIATIVE / 10 + level + rank * 10;
        }

        public void Heal(Character target, params int[] param)
        {
            target.NOW_HP += target.MAX_HP / 10 + level + rank * 10;
        }

        protected override void RankUp()
        {
            rank++;
            level -= 10;

            switch (rank)
            {
                case 1:
                    name = "(A)각성";
                    break;
                case 2:
                    name = "(A)야성의 힘";
                    break;
            }
        }
    }
}
