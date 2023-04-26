namespace ProjectRPG
{
    /// <summary>
    /// 회복 가능에 대한 인터페이스.
    /// 회복 스킬, 회복 아이템 등에 사용
    /// </summary>
    internal interface IHealable
    {
        /// <summary>
        /// 대상을 회복시킨다
        /// </summary>
        /// <param name="target">대상</param>
        public void Heal(Character target);
    }
}
