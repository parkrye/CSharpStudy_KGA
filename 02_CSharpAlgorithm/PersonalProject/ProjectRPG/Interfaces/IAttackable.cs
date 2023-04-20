namespace ProjectRPG
{
    /// <summary>
    /// 공격 가능에 대한 인터페이스.
    /// 공격 스킬, 공격 아이템 등에 사용
    /// </summary>
    internal interface IAttackable
    {
        /// <summary>
        /// 공격 메소드
        /// </summary>
        /// <param name="hitable">공격 대상</param>
        void Attack(ITargetable hitable);
    }
}
