namespace ProjectRPG
{
    /// <summary>
    /// 스킬 종류에 대한 열거형
    /// </summary>
    internal enum SkillType { PASSIVE, ACTIVE };

    /// <summary>
    /// 스킬에 대한 클래스
    /// </summary>
    [Serializable]
    internal abstract class Skill
    {

        protected Character self, other;  // 스킬 보유자, 지목한 대상

        protected string name;              // 스킬 이름
        protected int rank, level, exp;     // 스킬 랭크, 레벨, 경험치
        protected SkillType type;           // 스킬 유형

        protected int value, cost;          // 스킬 변수, 소모량

        /// <summary>
        /// 스킬 이름에 대한 프로퍼티
        /// </summary>
        public string NAME { get { return name; } }

        /// <summary>
        /// 스킬 유형에 대한 프로퍼티
        /// </summary>
        public SkillType TYPE { get { return type; } }

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
            while (exp >= level * (10 + rank))
                LevelUp();
        }

        /// <summary>
        /// 스킬 레벨업에 대한 메소드
        /// </summary>
        void LevelUp()
        {
            exp -= level * (10 + rank);
            level++;

            while (rank < 3 && level >= 10)
                RankUp();
        }

        protected abstract void RankUp();

        /// <summary>
        /// 스킬 발동에 대한 메소드
        /// </summary>
        /// <param name="param1">능력치 데이터</param>
        /// <param name="param2">부가 데이터</param>
        /// <returns>스킬 발동 성공 여부</returns>
        public abstract bool Active(int[,] param1, params int[] param2);

        /// <summary>
        /// 대상을 지정하는 메소드
        /// </summary>
        /// <param name="targetable">지정할 대상</param>
        public void SetTarget(Character character)
        {
            other = character;
        }

        /// <summary>
        /// 대상을 삭제하는 메소드
        /// </summary>
        public void ResetTarget()
        {
            other = null;
        }

        /// <summary>
        /// 스킬이 추가되었을 때 self를 설정하는 메소드
        /// </summary>
        /// <param name="character">스킬 보유 캐릭터</param>
        public void Added(Character character)
        {
            self = character;
        }
    }
}
