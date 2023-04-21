namespace ProjectRPG
{
    /// <summary>
    /// 특수한 효과를 발동하는 아이템에 대한 클래스
    /// </summary>
    internal abstract class Item_Active : Item
    {
        bool consumable;    // 소모 여부

        /// <summary>
        /// 소모성에 대한 프로퍼티
        /// </summary>
        public bool CONSUMABLE
        {
            get { return consumable; }
            set { consumable = value; }
        }

        /// <summary>
        /// 생성자
        /// </summary>
        public Item_Active()
        {
            type = ItemType.ACTIVE;
        }
    }
}
