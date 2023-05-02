namespace ProjectRPG
{
    /// <summary>
    /// 패시브 스킬을 상속한 상세 스킬 클래스
    /// </summary>
    [Serializable]
    internal class Skill_PainRefactor : Skill_Passive
    {
        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="_level">스킬 레벨. 기본 1</param>
        /// <param name="_exp">스킬 경험치. 기본 0</param>
        public Skill_PainRefactor(int _level = 1, int _exp = 0) : base()
        {
            name = "(P)고통 전환";
            level = _level;
            exp = _exp;
            value = 0.5f;
            cost = 0;
            rank = 0;
            if (level >= 10)
                RankUp();
        }

        public override void AddListener(Character character)
        {
            if (character != null)
                character.AddListenerOnDamaged(Cast);
        }

        public override bool Cast(int[,] param1, ref int param2)
        {
            param1[1, 1] += (int)(param2 * value * (level + rank * 10));
            return true;
        }

        protected override void RankUp()
        {
            rank++;
            level -= 10;

            switch (rank)
            {
                case 1:
                    name = "(P)생명 전환";
                    break;
                case 2:
                    name = "(P)마력 순환";
                    break;
            }
        }
    }
}
