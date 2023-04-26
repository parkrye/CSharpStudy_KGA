namespace ProjectRPG
{
    /// <summary>
    /// 너프 가능에 대한 인터페이스.
    /// 너프 스킬, 너프 아이템 등에 사용
    /// </summary>
    internal interface INurfable
    {
        /// <summary>
        /// 대상을 너프한다
        /// </summary>
        /// <param name="target">대상</param>
        public void Nurf(Character target);
    }
}
