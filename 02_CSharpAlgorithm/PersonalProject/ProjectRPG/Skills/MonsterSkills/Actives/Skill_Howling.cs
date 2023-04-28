namespace ProjectRPG
{
    /// <summary>
    /// 액티브 스킬을 상속한 상세 스킬 클래스
    /// </summary>
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
        }

        public override bool Active(int[,] param1, params int[] param2)
        {
            if (other != null)
            {
                Burf(self);
                Heal(self);
                return true;
            }
            return false;
        }

        public void Burf(Character target)
        {
            target.NOW_PHYSICSAL += target.MAX_PHYSICSAL / 10;
            target.NOW_MENTAL += target.MAX_MENTAL / 10;
            target.NOW_INITIATIVE += target.MAX_INITIATIVE / 10;
        }

        public void Heal(Character target)
        {
            target.NOW_HP += target.MAX_HP / 10;
        }

        protected override void RankUp()
        {
            rank++;
            level -= 10;
        }
    }
}
