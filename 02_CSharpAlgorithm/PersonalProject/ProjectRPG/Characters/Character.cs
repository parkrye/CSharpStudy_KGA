namespace ProjectRPG
{
    /// <summary>
    /// 캐릭터에 대한 클래스
    /// </summary>
    internal abstract class Character : ITargetable
    {
        protected string name;          // 캐릭터의 이름
        protected float hp, sp;         // 캐릭터의 능력치
        protected SkillSlot skillSlot;  // 캐릭터의 스킬
        protected ItemSlot itemSlot;    // 캐릭터의 아이템

        // 이벤트 호출을 위한 대리자
        // 패시브 스킬의 사용을 위해 사용
        /*
         * 수정점 : 활력이 감소했을때 체력이 증가 등, 다른 변수에 영향을 주는 스킬!
         */
        public delegate bool Action(params float[] param);
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
        public float HP 
        { 
            get { return hp; } 
            set { hp = value; }
        }

        /// <summary>
        /// 캐릭터 활력에 대한 프로퍼티
        /// </summary>
        public float SP 
        { 
            get { return sp; } 
            set { sp = value; }
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
            skillSlot.UseSkill(index, targetable, ref sp);    // 스킬 슬롯에서 해당 스킬을 시전하고, 소모 활력을 반환받는다
            OnSPDecreased?.Invoke(hp, sp);                    // 활력 감소에 대한 패시브 스킬이 시전되고, 활력을 조정한다
        }

        /// <summary>
        /// 피격시 발생하는 이벤트
        /// </summary>
        /// <param name="damage">데미지</param>
        public bool Hit(float damage)
        {
            OnDamaged?.Invoke(hp, sp, damage);                   // 데미지 발생에 대한 패시브 스킬이 시전되고, 데미지를 조정한다

            hp -= damage;
            OnHPDecreased?.Invoke(hp, sp);                       // 체력 감소에 대한 패시프 스킬이 시전되고, 체력을 조정한다
            if (hp < 0)                                          // 체력이 0 이하라면 사망한다
            {
                hp = 0;
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
