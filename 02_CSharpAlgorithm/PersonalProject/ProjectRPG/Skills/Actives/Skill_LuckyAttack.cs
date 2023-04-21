namespace ProjectRPG
{
    /// <summary>
    /// 액티브 스킬을 상속한 상세 스킬 클래스
    /// </summary>
    internal class Skill_LuckyAttack : Skill_Active, IAttackable
    {
        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="_level">스킬 레벨. 기본 1</param>
        /// <param name="_exp">스킬 경험치. 기본 0</param>
        public Skill_LuckyAttack(int _level = 1, int _exp = 0) : base()
        {
            name = "행운의 일격";
            level = _level;
            exp = _exp;
            value = 1f;
            cost = 1.5f;
        }

        /// <summary>
        /// 스킬 발동에 대한 메소드
        /// </summary>
        /// <param name="sp">현재 활력. 미사용</param>
        public override bool Active(params float[] param)
        {
            if (other != null)
            {
                return Attack(other);
            }
            return false;
        }

        /// <summary>
        /// 공격 메소드
        /// </summary>
        /// <param name="targetable">공격 대상</param>
        public bool Attack(ITargetable targetable)
        {
            if(targetable.Hit(new Random().Next((int)value * 2 + 1) * level))
            {
                GetEXP(1);
                return true;
            }
            return false;
        }
    }
}
