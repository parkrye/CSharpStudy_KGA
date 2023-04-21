namespace ProjectRPG
{
    /// <summary>
    /// 공격 대상이 될 수 있느냐는 인터페이스.
    /// 모든 캐릭터, 일부 공격할 수 있는 구조물 등에 사용
    /// </summary>
    internal interface ITargetable
    {
        /// <summary>
        /// 피격 메소드
        /// </summary>
        /// <param name="damage">가한 데미지</param>
        /// <returns>피격 성공 여부</returns>
        bool Hit(int damage);
    }
}
