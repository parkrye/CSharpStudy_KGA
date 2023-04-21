namespace ProjectRPG
{
    /// <summary>
    /// 캐릭터의 직업에 대한 클래스
    /// </summary>
    internal abstract class Class
    {
        protected string name;                  // 직업 이름
        protected SkillSlot skillSlot;          // 직업 스킬
        protected int[] defaultStatus;          // 직업 능력치

        /// <summary>
        /// 직업 이름에 대한 프로퍼티
        /// </summary>
        public string NAME
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// 직업 스킬에 대한 프로퍼티
        /// </summary>
        public SkillSlot SKILLSLOT
        {
            get { return skillSlot; }
            set { skillSlot = value; }
        }

        /// <summary>
        /// 직업 체력에 대한 프로퍼티
        /// </summary>
        public int HP
        {
            get { return defaultStatus[0]; }
            set { defaultStatus[1] = value; }
        }

        /// <summary>
        /// 직업 활력에 대한 프로퍼티
        /// </summary>
        public int SP
        {
            get { return defaultStatus[1]; }
            set { defaultStatus[1] = value; }
        }

        /// <summary>
        /// 직업 신체능력에 대한 프로퍼티
        /// </summary>
        public int PHYSICAL
        {
            get { return defaultStatus[2]; }
            set { defaultStatus[2] = value; }
        }

        /// <summary>
        /// 직업 정신능력에 대한 프로퍼티
        /// </summary>
        public int MENTAL
        {
            get { return defaultStatus[3]; }
            set { defaultStatus[3] = value; }
        }

        /// <summary>
        /// 직업 행동 우선도에 대한 프로퍼티
        /// </summary>
        public int INITIATIVE
        {
            get { return defaultStatus[4]; }
            set { defaultStatus[4] = value; }
        }
    }
}
