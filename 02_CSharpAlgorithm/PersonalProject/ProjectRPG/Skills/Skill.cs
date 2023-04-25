namespace ProjectRPG
{
    /// <summary>
    /// 스킬 종류에 대한 열거형
    /// </summary>
    internal enum SkillType { PASSIVE, ACTIVE };

    /// <summary>
    /// 스킬에 대한 클래스
    /// </summary>
    internal abstract class Skill
    {

        protected ITargetable self, other;  // 스킬 보유자, 지목한 대상

        protected string name;              // 스킬 이름
        protected int level, exp;           // 스킬 레벨, 경험ㅁ치
        protected SkillType type;           // 스킬 유형

        protected int value, cost;          // 스킬 변수, 소모량

        /// <summary>
        /// 스킬 이름에 대한 프로퍼티
        /// </summary>
        public string NAME { get { return name; } }

        /// <summary>
        /// 스킬 레벨에 대한 프로퍼티
        /// </summary>
        public int LEVEL { get { return level; } }

        /// <summary>
        /// 스킬 유형에 대한 프로퍼티
        /// </summary>
        public SkillType TYPE { get { return type; } }

        /// <summary>
        /// 스킬 변수에 대한 프로퍼티
        /// </summary>
        public int VALUE { get { return value; } }

        /// <summary>
        /// 스킬 소모량에 대한 프로퍼티
        /// </summary>
        public int COST { get { return cost; } }

        /// <summary>
        /// 스킬 경험치 획득에 대한 메소드
        /// </summary>
        /// <param name="addEXP">획득한 경험치</param>
        protected void GetEXP(int addEXP)
        {
            exp += addEXP;
            while (level < 10 && exp >= level * 100)
                LevelUp();
        }

        /// <summary>
        /// 스킬 레벨업에 대한 메소드
        /// </summary>
        void LevelUp()
        {
            exp -= level * 100;
            level++;
        }

        /// <summary>
        /// 스킬 발동에 대한 메소드
        /// </summary>
        /// <param name="param1">능력치 데이터</param>
        /// <param name="param2">부가 데이터</param>
        /// <returns>스킬 발동 성공 여부</returns>
        public abstract bool Active(int[,] param1, params int[] param2);

        /// <summary>
        /// 사용자를 지정하는 메소드
        /// </summary>
        /// <param name="targetable">지정할 사용자</param>
        public void SetUser(ITargetable targetable)
        {
            self = targetable;
        }

        /// <summary>
        /// 대상을 지정하는 메소드
        /// </summary>
        /// <param name="targetable">지정할 대상</param>
        public void SetTarget(ITargetable targetable)
        {
            other = targetable;
        }

        /// <summary>
        /// 대상을 삭제하는 메소드
        /// </summary>
        public void ResetTarget()
        {
            other = null;
        }
    }
}
