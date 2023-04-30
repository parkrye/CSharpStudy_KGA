namespace ProjectRPG
{
    /// <summary>
    /// 패시브 스킬을 상속한 상세 스킬 클래스
    /// </summary>
    [Serializable]
    internal class Skill_MagicShield : Skill_Passive
    {
        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="_level">스킬 레벨. 기본 1</param>
        /// <param name="_exp">스킬 경험치. 기본 0</param>
        public Skill_MagicShield(int _level = 1, int _exp = 0) : base()
        {
            name = "(P)마법 방패";
            level = _level;
            exp = _exp;
            value = 0;
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
            if (param2 <= param1[1, 1])
            {
                param1[1, 1] -= param2 * (4 - rank) / 4;
                param2 = 0;
            }
            return true;
        }

        protected override void RankUp()
        {
            rank++;
            level -= 10;

            switch (rank)
            {
                case 1:
                    name = "(P)마법 보호막";
                    break;
                case 2:
                    name = "(P)마력 장벽";
                    break;
            }
        }
    }
}
