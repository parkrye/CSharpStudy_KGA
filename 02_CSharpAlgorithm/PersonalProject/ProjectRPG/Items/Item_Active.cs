namespace ProjectRPG
{
    /// <summary>
    /// 특수한 효과를 발동하는 아이템에 대한 클래스
    /// </summary>
    internal abstract class Item_Active : Item
    {
        protected bool consumable;    // 소모 여부

        /// <summary>
        /// 아이템 타입을 설정하는 생성자
        /// </summary>
        public Item_Active()
        {
            type = ItemType.ACTIVE;
        }

        public override void AddListener(Character character) { }

        public override void Removed(int[,] param) { }

        public override void Equiped(int[,] param) { }
    }
}
