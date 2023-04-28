namespace ProjectRPG
{
    /// <summary>
    /// 아이템 종류에 대한 열거형
    /// </summary>
    internal enum ItemType { NONE, EQUIPMENT, ACTIVE };


    /// <summary>
    /// 아이템에 대한 클래스
    /// </summary>
    [Serializable]
    internal abstract class Item
    {    

        protected string name;      // 아이템 이름
        protected int price;        // 아이템 가치
        protected ItemType type;    // 아이템 종류
        protected bool haveEvent;   // 이벤트 보유 여부

        /// <summary>
        /// 아이템 이름에 대한 프로퍼티
        /// </summary>
        public string NAME { get { return name; } }

        /// <summary>
        /// 아이템 가치에 대한 프로퍼티
        /// </summary>
        public int PRICE { get { return price; } }

        /// <summary>
        /// 아이템 종류에 대한 프로퍼티
        /// </summary>
        public ItemType TYPE { get { return type; } }

        /// <summary>
        /// 이벤트 보유 여부에 대한 프로퍼티
        /// </summary>
        public bool HAVEEVENT { get { return haveEvent; } }

        /// <summary>
        /// 삭제시 호출하는 메소드
        /// </summary>
        public abstract void Removed(int[,] param);

        /// <summary>
        /// 장착시 호출하는 메소드
        /// </summary>
        public abstract void Equiped(int[,] param);

        /// <summary>
        /// 캐릭터의 이벤트에 메소드를 구독시키는 메소드
        /// </summary>
        /// <param name="character">대상 캐릭터</param>
        public abstract void AddListener(Character character);


        /// <summary>
        /// 아이템 사용에 대한 메소드
        /// </summary>
        /// <param name="target">사용 대상</param>
        /// <returns>아이템 소모 여부</returns>
        public abstract bool Active(Character targets);
    }
}
