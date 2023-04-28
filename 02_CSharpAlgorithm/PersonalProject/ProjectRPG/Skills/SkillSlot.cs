namespace ProjectRPG
{
    /// <summary>
    /// 스킬 슬롯에 대한 클래스
    /// </summary>
    [Serializable]
    internal class SkillSlot
    {
        Character character;    // 스킬 슬롯을 가진 캐릭터
        int size;               // 스킬 슬롯의 현재 크기
        int quantity;           // 스킬 개수
        Skill[] skills;         // 스킬 배열


        /// <summary>
        /// 스킬 개수에 대한 프로퍼티
        /// </summary>
        public int QUANTITY { get { return quantity; } }

        /// <summary>
        /// 스킬 배열에 대한 프로퍼티
        /// </summary>
        public Skill[] SKILLS { get { return skills; } }

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="_character">소유 캐릭터</param>
        /// <param name="_size">현재 크기</param>
        public SkillSlot(Character _character, int _size)
        {
            character = _character;
            size = _size;
            skills = new Skill[size];
        }

        /// <summary>
        /// 스킬 추가 메소드
        /// </summary>
        /// <param name="skill">추가할 스킬</param>
        /// <returns>추가 성공 여부</returns>
        public bool AddSkill(Skill skill)
        {
            if (skill == null)
                return false;

            for(int i = 0; i < size; i++)
            {
                if (skills[i] == null)
                {
                    skill.Added(character);
                    skills[i] = skill;
                    if (skills[i].TYPE == SkillType.PASSIVE)    // 패시브 스킬이라면 캐릭터 이벤트를 구독한다
                    {
                        ((Skill_Passive)skills[i]).AddListener(character);
                    }
                    if (character != null)
                        character.DIFFICULTY++;
                    quantity++;
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 스킬 제거 메소드
        /// </summary>
        /// <param name="index">제거할 인덱스</param>
        /// <returns>제거 성공 여부</returns>
        public bool RemoveSkill(int index)
        {
            if (index < 0 || index >= size)
                return false;
            if (skills[index] == null)
                return false;

            for (int i = index; i < size - 1; i++)
            {
                skills[i] = skills[i + 1];
            }
            skills[size - 1] = null;
            if (character != null)
                character.DIFFICULTY--;
            quantity--;
            return true;
        }

        /// <summary>
        /// 액티브 스킬 사용 메소드
        /// </summary>
        /// <param name="index">사용할 인덱스</param>
        /// <param name="hitable">스킬 대상</param>
        /// <param name="param1">능력치 데이터</param>
        /// <param name="param2">부가 데이터</param>
        /// <returns>스킬 사용 성공 여부</returns>
        public bool UseSkill(int index, Character target, int[,] param1, params int[] param2)
        {
            if (index < 0 || index >= size)
                return false;
            if (skills[index] == null)
                return false;
            if (param1[1, 1] < skills[index].COST)
                return false;

            if (skills[index].TYPE == SkillType.ACTIVE)
            {
                if (param1[1, 1] < skills[index].COST)
                    return false;
                skills[index].SetTarget(target);           // 스킬 대상 지정
                if (skills[index].Active(param1, param2))   // 스킬 사용
                {
                    skills[index].ResetTarget();            // 스킬 대상 해제
                    param1[1, 1] -= skills[index].COST;        // 활력 소모
                    return true;
                }
            }
            return false;
        }
    }
}
