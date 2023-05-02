namespace ProjectRPG
{
    /// <summary>
    /// 액티브 스킬을 상속한 상세 스킬 클래스
    /// </summary>
    [Serializable]
    internal class Skill_FireBreath : Skill_Active, IAttackable
    {
        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="_level">스킬 레벨. 기본 1</param>
        /// <param name="_exp">스킬 경험치. 기본 0</param>
        public Skill_FireBreath(int _level = 1, int _exp = 0) : base()
        {
            name = "(A)화염 방사";
            level = _level;
            exp = _exp;
            value = 0.8f;
            cost = 10;
            rank = 0;
            if (level >= 10)
                RankUp();
        }

        public override bool Active(int[,] param1, ref int param2)
        {
            if (other != null)
            {
                if(other is IHitable)
                    return Attack(other, param1[1, 3]);
                return false;
            }
            return false;
        }

        public bool Attack(IHitable hitable, params int[] param)
        {
            int damage = new Random().Next((int)(param[0] * value + (level + rank * 10)));
            if (hitable.Hit(damage))
            {
                GetEXP(1);
                return true;
            }
            return false;
        }

        protected override void RankUp()
        {
            rank++;
            level -= 10;

            switch (rank)
            {
                case 1:
                    name = "(A)화염 숨결";
                    break;
                case 2:
                    name = "(A)지옥의 숨결";
                    break;
            }
        }
    }
}
