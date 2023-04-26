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
        /// <param name="param">공격자 능력치</param>
        /// <returns>공격 성공 여부</returns>
        bool Attack(IHitable hitable, params int[] param);
    }
}
