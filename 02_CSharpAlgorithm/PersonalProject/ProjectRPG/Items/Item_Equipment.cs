namespace ProjectRPG
{
    /// <summary>
    /// 캐릭터에게 상시 적용되는 아이템에 대한 클래스
    /// </summary>
    internal abstract class Item_Equipment : Item
    {
        /// <summary>
        /// 생성자
        /// </summary>
        public Item_Equipment()
        {
            type = ItemType.PASSIVE;
        }
        public override bool Active(Character target) { return false; }
    }
}
