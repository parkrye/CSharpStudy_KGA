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

        /// <summary>
        /// 아이템 사용에 대한 메소드
        /// </summary>
        /// <param name="param">능력치 데이터</param>
        /// <param name="targets">사용 대상. 0: 자신 1:추가 대상</param>
        /// <returns>아이템 사용 성공 여부</returns>
        public abstract bool Active(int[] param, params ITargetable[] targets);
    }
}
