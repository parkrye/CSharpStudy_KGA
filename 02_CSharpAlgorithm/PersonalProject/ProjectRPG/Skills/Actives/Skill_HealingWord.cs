namespace ProjectRPG
{
    /// <summary>
    /// 액티브 스킬을 상속한 상세 스킬 클래스
    /// </summary>
    [Serializable]
    internal class Skill_HealingWord : Skill_Active, IHealable
    {
        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="_level">스킬 레벨. 기본 1</param>
        /// <param name="_exp">스킬 경험치. 기본 0</param>
        public Skill_HealingWord(int _level = 1, int _exp = 0) : base()
        {
            name = "(A)치유의 단어";
            level = _level;
            exp = _exp;
            value = 2;
            cost = 10;
            rank = 0;
        }

        public override bool Active(int[,] param1, params int[] param2)
        {
            if (other != null)
            {
                Heal(other, param1[1, 3]);
                return true;
            }
            return false;
        }

        public void Heal(Character target, params int[] param)
        {
            target.NOW_HP += param[0] * value + (level + rank * 10);
        }

        protected override void RankUp()
        {
            rank++;
            level -= 10;

            switch (rank)
            {
                case 1:
                    name = "(A)상처 회복";
                    value += 2;
                    cost += 3;
                    break;
                case 2:
                    name = "(A)대치유";
                    value += 2;
                    cost += 3;
                    break;
            }
        }
    }
}
