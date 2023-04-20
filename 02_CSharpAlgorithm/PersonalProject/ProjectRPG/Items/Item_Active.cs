namespace ProjectRPG
{
    /// <summary>
    /// 특수한 효과를 발동하는 아이템에 대한 클래스
    /// </summary>
    internal abstract class Item_Active : Item
    {
        /// <summary>
        /// 생성자
        /// </summary>
        public Item_Active()
        {
            type = ItemType.ACTIVE;
        }

        /// <summary>
        /// 아이템 사용에 대한 메소드
        /// </summary>
        /// <param name="param">주어지는 변수</param>
        public abstract void Active(float param);
    }
}
