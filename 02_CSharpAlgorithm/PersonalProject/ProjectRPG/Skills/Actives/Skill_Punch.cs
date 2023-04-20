namespace ProjectRPG
{
    /// <summary>
    /// 액티브 스킬 주먹질에 대한 클래스
    /// </summary>
    internal class Skill_Punch : Skill_Active, IAttackable
    {
        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="_level">스킬 레벨. 기본 1</param>
        /// <param name="_exp">스킬 경험치. 기본 0</param>
        public Skill_Punch(int _level = 1, int _exp = 0) : base()
        {
            name = "주먹질";
            level = _level;
            exp = _exp;
            value = 1;
            cost = 1;
        }

        /// <summary>
        /// 스킬 발동에 대한 메소드
        /// </summary>
        /// <param name="sp">현재 활력. 미사용</param>
        public override void Active(float sp)
        {
            if (other is not null)
            {
                Attack(other);
            }
        }

        /// <summary>
        /// 공격 메소드
        /// </summary>
        /// <param name="targetable">공격 대상</param>
        public void Attack(ITargetable targetable)
        {
            targetable.Hit(value * level);
            GetEXP(1);
        }
    }
}
