namespace ProjectRPG
{
    /// <summary>
    /// 캐릭터에 대한 클래스
    /// </summary>
    internal abstract class Character : ITargetable
    {
        protected string name;          // 캐릭터의 이름
        protected int[] status;         // 캐릭터의 능력치: hp, sp, physical, mental
        protected SkillSlot skillSlot;  // 캐릭터의 스킬
        protected ItemSlot itemSlot;    // 캐릭터의 아이템

        // 이벤트 호출을 위한 대리자
        // 패시브 스킬의 사용을 위해 사용
        // param1 : 능력치ㅡ param2 : 부가적인 데이터
        public delegate bool Action(int[] param1, params int[] param2);
        protected event Action? OnDamaged, OnHPDecreased, OnSPDecreased;

        /// <summary>
        /// 캐릭터 이름에 대한 프로퍼티
        /// </summary>
        public string NAME 
        { 
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// 캐릭터 체력에 대한 프로퍼티
        /// </summary>
        public int HP 
        { 
            get { return status[0]; } 
            set { status[0] = value; }
        }

        /// <summary>
        /// 캐릭터 활력에 대한 프로퍼티
        /// </summary>
        public int SP 
        { 
            get { return status[1]; } 
            set { status[1] = value; }
        }

        /// <summary>
        /// 캐릭터 신체능력에 대한 프로퍼티
        /// </summary>
        public int PHYSICSAL
        {
            get { return status[2]; }
            set { status[2] = value; }
        }

        /// <summary>
        /// 캐릭터 정신능력에 대한 프로퍼티
        /// </summary>
        public int MENTAL
        {
            get { return status[3]; }
            set { status[3] = value; }
        }

        /// <summary>
        /// 캐릭터 스킬에 대한 프로퍼티
        /// </summary>
        public SkillSlot SKILLSLOT
        {
            get {  return skillSlot; }
            set { skillSlot = value; }
        }

        /// <summary>
        /// 캐릭터 아이템에 대한 프로퍼티
        /// </summary>
        public ItemSlot ITEMSLOT
        {
            get { return itemSlot; }
            set { itemSlot = value; }
        }

        /// <summary>
        /// 액티브 스킬의 사용에 대한 함수
        /// </summary>
        /// <param name="index">사용할 스킬 번호</param>
        /// <param name="targetable">스킬 대상</param>
        public void UseSkill(int index, ITargetable targetable)
        {
            skillSlot.UseSkill(index, targetable, status);                  // 스킬 슬롯에서 해당 스킬을 시전하고, 소모 활력을 반환받는다
            OnSPDecreased?.Invoke(status);                                  // 활력 감소에 대한 패시브 스킬이 시전되고, 활력을 조정한다
        }

        /// <summary>
        /// 피격시 발생하는 이벤트
        /// </summary>
        /// <param name="damage">데미지</param>
        public bool Hit(int damage)
        {
            OnDamaged?.Invoke(status, damage);                   // 데미지 발생에 대한 패시브 스킬이 시전되고, 데미지를 조정한다

            status[0] -= damage;
            OnHPDecreased?.Invoke(status);                       // 체력 감소에 대한 패시프 스킬이 시전되고, 체력을 조정한다
            if (status[0] < 0)                                   // 체력이 0 이하라면 사망한다
            {
                status[0] = 0;
            }
            return true;
        }

        /// <summary>
        /// 데미지 발생에 대한 이벤트 구독
        /// </summary>
        /// <param name="action">(float, float)인 메소드</param>
        public void AddListenerOnDamaged(Action action)
        {
            OnDamaged += action;
        }

        /// <summary>
        /// 체력 감소에 대한 이벤트 구독
        /// </summary>
        /// <param name="action">(float, float)인 메소드</param>
        public void AddListenerOnHPDecreased(Action action)
        {
            OnHPDecreased += action;
        }


        /// <summary>
        /// 활력 감소에 대한 이벤트 구독
        /// </summary>
        /// <param name="action">(float, float)인 메소드</param>
        public void AddListenerOnSPDecreased(Action action)
        {
            OnSPDecreased += action;
        }
    }
}
