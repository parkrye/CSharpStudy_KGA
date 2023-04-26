namespace ProjectRPG
{
    /// <summary>
    /// 패시브 스킬을 상속한 상세 스킬 클래스
    /// </summary>
    internal class Skill_Arcrobatics : Skill_Passive
    {
        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="_level">스킬 레벨. 기본 1</param>
        /// <param name="_exp">스킬 경험치. 기본 0</param>
        public Skill_Arcrobatics(int _level = 1, int _exp = 0) : base()
        {
            name = "(P)곡예";
            level = _level;
            exp = _exp;
            value = 1;
            cost = 0;
        }

        public override void AddListener(Character character)
        {
            if (character != null)
                character.AddListenerOnDamaged(Active);
        }

        public override bool Cast(int[,] param1, params int[] param2)
        {
            if(new Random().Next(10) < Math.Log(level, 10) * 10)
            {
                param2[0] /= 2;
                return true;
            }
            return true;
        }
    }
}
