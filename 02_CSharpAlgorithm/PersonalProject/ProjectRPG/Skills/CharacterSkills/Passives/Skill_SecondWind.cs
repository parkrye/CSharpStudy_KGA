namespace ProjectRPG
{
    /// <summary>
    /// 패시브 스킬을 상속한 상세 스킬 클래스
    /// </summary>
    internal class Skill_SecondWind : Skill_Passive
    {

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="_level">스킬 레벨. 기본 1</param>
        /// <param name="_exp">스킬 경험치. 기본 0</param>
        public Skill_SecondWind(int _level = 1, int _exp = 0) : base()
        {
            name = "(P)자연 치유";
            level = _level;
            exp = _exp;
            value = 15;
            cost = 0;
            coolTime = 10;
        }

        public override void AddListener(Character character)
        {
            if(character != null)
            {
                character.AddListenerOnHPDecreased(Active);
            }
        }

        public override bool Cast(int[,] param1, params int[] param2)
        {
            if (param1[1,0] > 0)
                return false;
            param1[1,0] += value * (level + rank * 10);
            used = true;
            return true;
        }

        protected override void RankUp()
        {
            rank++;
            level -= 10;

            switch (rank)
            {
                case 1:
                    name = "(A)재생력";
                    break;
                case 2:
                    name = "(A)재기의 바람";
                    break;
            }
        }
    }
}
