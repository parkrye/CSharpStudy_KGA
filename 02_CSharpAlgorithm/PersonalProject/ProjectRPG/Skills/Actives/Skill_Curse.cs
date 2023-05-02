using Newtonsoft.Json.Linq;

namespace ProjectRPG
{
    /// <summary>
    /// 액티브 스킬을 상속한 상세 스킬 클래스
    /// </summary>
    [Serializable]
    internal class Skill_Curse : Skill_Active, IAttackable
    {
        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="_level">스킬 레벨. 기본 1</param>
        /// <param name="_exp">스킬 경험치. 기본 0</param>
        public Skill_Curse(int _level = 1, int _exp = 0) : base()
        {
            name = "(A)원한";
            level = _level > 1 ? _level : 1;
            exp = _exp;
            value = 0.9f;
            cost = 10;
            rank = 0;
            if (level >= 10)
                RankUp();
        }

        public override bool Active(int[,] param1, ref int param2)
        {
            if (other != null)
            {
                Attack(other, 0);
                return true;
            }
            return false;
        }

        public bool Attack(IHitable hitable, params int[] param)
        {
            other.NOW_PHYSICSAL = (int)(param[0] * value);
            other.NOW_MENTAL = (int)(param[0] * value);
            other.NOW_INITIATIVE = (int)(param[0] * value);
            return true;
        }

        protected override void RankUp()
        {
            rank++;
            level -= 10;

            switch (rank)
            {
                case 1:
                    name = "(A)저주";
                    value = 0.8f;
                    break;
                case 2:
                    name = "(A)오염";
                    value = 0.7f;
                    break;
            }
        }
    }
}
