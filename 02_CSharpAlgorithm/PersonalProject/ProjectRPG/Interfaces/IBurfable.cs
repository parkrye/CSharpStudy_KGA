namespace ProjectRPG
{
    /// <summary>
    /// 버프 가능에 대한 인터페이스.
    /// 버프 스킬, 버프 아이템 등에 사용
    /// </summary>
    internal interface IBurfable
    {
        /// <summary>
        /// 대상을 버프한다
        /// </summary>
        /// <param name="target">대상</param>
        public void Burf(Character target);
    }
}
