namespace ProjectRPG
{
    /// <summary>
    /// 패시브 스킬을 상속한 상세 스킬 클래스
    /// </summary>
    [Serializable]
    internal class Skill_Arcrobatics : Skill_Passive
    {
        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="_level">스킬 레벨. 기본 1</param>
        /// <param name="_exp">스킬 경험치. 기본 0</param>
        public Skill_Arcrobatics(int _level = 1, int _exp = 0) : base()
        {
            name = "(P)날렵한 몸놀림";
            level = _level;
            exp = _exp;
            value = 1;
            cost = 0;
            rank = 0;
        }

        public override void AddListener(Character character)
        {
            if (character != null)
                character.AddListenerOnDamaged(Cast);
        }

        protected override void RankUp()
        {
            rank++;
            level -= 10;

            switch (rank)
            {
                case 1:
                    name = "(A)곡예";
                    break;
                case 2:
                    name = "(A)회피술";
                    break;
            }
        }

        public override bool Cast(int[,] param1, ref int param2)
        {
            if (new Random().Next(10) < Math.Log(rank < 1 ? level : 9, 10) * 5)
            {
                param2 /= (int)value + rank;
                return true;
            }
            return true;
        }
    }
}
