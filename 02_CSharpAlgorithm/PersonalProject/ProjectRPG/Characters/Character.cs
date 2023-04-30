namespace ProjectRPG
{
    /// <summary>
    /// 캐릭터 성에 대한 열거형
    /// </summary>
    internal enum CharacterFirstName { 김, 이, 박, 최, 정, 강, 조, 윤, 장, 임, 한, 오, 서, 신, 권, 황, 인, 송, 류, 전, 홍, 고, 문, 양, 손, 배, 백, 허, 유, 남, 심, 노, 하, 곽, 성, 차, 주, 우, 구, 라, 민, 진, 지, 채, 원, 천, 방, 공, 현, 함 };

    /// <summary>
    /// 캐릭터 이름에 대한 열거형
    /// </summary>
    internal enum CharacterLastName { 만, 종, 동, 용, 우, 주, 훈, 건, 구, 원, 봉, 범, 윤, 지, 희, 명, 남, 필, 석, 백, 영, 형, 하, 행, 연, 수, 성, 의, 재, 무, 반, 국, 기, 홍, 강, 광, 렴, 경, 유, 도, 장, 신, 택, 상, 달, 정, 각, 치, 계, 규 };

    /// <summary>
    /// 캐릭터에 대한 클래스
    /// </summary>
    [Serializable]
    internal abstract class Character : IHitable
    {

        protected string name;          // 캐릭터의 이름
        protected int[,] status;        // 캐릭터의 최대 능력치, 현재 능력치: hp, sp, physical, mental, initiative
        protected SkillSlot skillSlot;  // 캐릭터의 스킬
        protected ItemSlot itemSlot;    // 캐릭터의 아이템
        protected int difficulty;       // 캐릭터 위험도(적일때 이용)
        protected int level;
        protected int exp;              // 캐릭터 성장도
        int dummy = 0;

        // 이벤트 호출을 위한 대리자
        // 패시브 스킬, 아이템의 사용을 위해 사용
        // param1 : 능력치ㅡ param2 : 부가적인 데이터
        public delegate bool PlayerDelegate(int[,] param1, ref int param2);
        [field: NonSerialized]
        protected event PlayerDelegate? OnDamaged, OnHPDecreased, OnSPDecreased;

        /// <summary>
        /// 캐릭터 이름에 대한 프로퍼티
        /// </summary>
        public string NAME { get { return name; } set { name = value; } }

        /// <summary>
        /// 캐릭터 스테이터스에 대한 프로퍼티
        /// </summary>
        public int[,] STATUS { get { return status; } set { status = value; } }

        /// <summary>
        /// 캐릭터 체력에 대한 프로퍼티
        /// </summary>
        public int MAX_HP { get { return status[0, 0]; } set { status[0, 0] = value; } }
        public int NOW_HP { get { return status[1, 0]; } set { if(value <= MAX_HP) status[1, 0] = value; } }

        /// <summary>
        /// 캐릭터 활력에 대한 프로퍼티
        /// </summary>
        public int MAX_SP { get { return status[0, 1]; } set { status[0, 1] = value; } }
        public int NOW_SP { get { return status[1, 1]; } set { if (value <= MAX_SP) status[1, 1] = value; } }

        /// <summary>
        /// 캐릭터 신체능력에 대한 프로퍼티
        /// </summary>
        public int MAX_PHYSICSAL { get { return status[0, 2]; } set { status[0, 2] = value; } }
        public int NOW_PHYSICSAL { get { return status[1, 2]; } set { status[1, 2] = value; } }

        /// <summary>
        /// 캐릭터 정신능력에 대한 프로퍼티
        /// </summary>
        public int MAX_MENTAL { get { return status[0, 3]; } set { status[0, 3] = value; } }
        public int NOW_MENTAL { get { return status[1, 3]; } set { status[1, 3] = value; } }

        /// <summary>
        /// 캐릭터 행동 우선도에 대한 프로퍼티
        /// </summary>
        public int MAX_INITIATIVE { get { return status[0, 4]; } set { status[0, 4] = value; } }
        public int NOW_INITIATIVE { get { return status[1, 4]; } set { status[1, 4] = value; } }

        /// <summary>
        /// 위험도에 대한 프로퍼티
        /// </summary>
        public int DIFFICULTY { get { return difficulty; } set { difficulty = value; } }

        /// <summary>
        /// 캐릭터 스킬에 대한 프로퍼티
        /// </summary>
        public SkillSlot SKILLSLOT { get {  return skillSlot; } set { skillSlot = value; } }

        /// <summary>
        /// 캐릭터 아이템에 대한 프로퍼티
        /// </summary>
        public ItemSlot ITEMSLOT { get { return itemSlot; } set { itemSlot = value; } }

        /// <summary>
        /// 캐릭터 성장에 대한 프로퍼티
        /// </summary>
        public int EXP 
        { 
            get 
            { 
                return exp; 
            } 
            set 
            { 
                exp = value; 
                while (exp > 50 * (level + 1)) 
                { 
                    exp -= 50 * (level + 1);
                    level++;
                    MAX_HP += level * 2;
                    MAX_SP += level * 2;
                    MAX_PHYSICSAL += level;
                    MAX_MENTAL += level;
                    MAX_INITIATIVE += level;
                    StatusSetting(true);
                }  
            } 
        }

        /// <summary>
        /// 현재 스테이터스를 최대 스테이터스로 설정하는 메소드
        /// <param name="reset">초기화 여부. true: 체력과 활력도 설정</param>
        /// </summary>
        public void StatusSetting(bool reset = false)
        {
            if (reset)
            {
                NOW_HP = MAX_HP;
                NOW_SP = MAX_SP;
            }
            NOW_PHYSICSAL = MAX_PHYSICSAL;
            NOW_MENTAL = MAX_MENTAL;
            NOW_INITIATIVE = MAX_INITIATIVE;
        }

        /// <summary>
        /// 액티브 스킬의 사용에 대한 함수
        /// </summary>
        /// <param name="index">사용할 스킬 번호</param>
        /// <param name="targetable">스킬 대상</param>
        public bool UseSkill(int index, Character target)
        {
            bool result = skillSlot.UseSkill(index, target, status, ref dummy);                  // 스킬 슬롯에서 해당 스킬을 시전하고, 소모 활력을 반환받는다
            OnSPDecreased?.Invoke(status, ref dummy);                                  // 활력 감소에 대한 패시브 스킬이 시전되고, 활력을 조정한다
            return result;
        }

        /// <summary>
        /// 피격시 발생하는 이벤트
        /// </summary>
        /// <param name="damage">데미지 변수</param>
        public bool Hit(int damage)
        {
            OnDamaged?.Invoke(status, ref damage);                   // 데미지 발생에 대한 패시브 스킬이 시전되고, 데미지를 조정한다

            NOW_HP -= damage;
            OnHPDecreased?.Invoke(status, ref dummy);                       // 체력 감소에 대한 패시프 스킬이 시전되고, 체력을 조정한다
            if (NOW_HP < 0)                                   // 체력이 0 이하라면 사망한다
            {
                NOW_HP = 0;
            }
            return true;
        }

        /// <summary>
        /// 데미지 발생에 대한 이벤트 구독
        /// </summary>
        /// <param name="player">(float, float)인 메소드</param>
        public void AddListenerOnDamaged(PlayerDelegate player)
        {
            OnDamaged += player;
        }

        /// <summary>
        /// 체력 감소에 대한 이벤트 구독
        /// </summary>
        /// <param name="player">(float, float)인 메소드</param>
        public void AddListenerOnHPDecreased(PlayerDelegate player)
        {
            OnHPDecreased += player;
        }


        /// <summary>
        /// 활력 감소에 대한 이벤트 구독
        /// </summary>
        /// <param name="player">(float, float)인 메소드</param>
        public void AddListenerOnSPDecreased(PlayerDelegate player)
        {
            OnSPDecreased += player;
        }
    }
}
