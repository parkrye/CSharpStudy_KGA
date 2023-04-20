namespace ProjectRPG
{
    /// <summary>
    /// 아이템에 대한 클래스
    /// </summary>
    internal abstract class Item
    {
        protected string name;      // 아이템 이름
        protected int price;        // 아이템 가치
        protected ItemType type;    // 아이템 종류

        /// <summary>
        /// 아이템 이름에 대한 프로퍼티
        /// </summary>
        public string NAME
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// 아이템 가치에 대한 프로퍼티
        /// </summary>
        public int PRICE
        {
            get { return price; }
            set { price = value; }
        }

        /// <summary>
        /// 아이템 종류에 대한 프로퍼티
        /// </summary>
        public ItemType TYPE
        {
            get { return type; }
            set { type = value; }
        }
    }
}
