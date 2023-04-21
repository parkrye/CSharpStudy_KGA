namespace ProjectRPG
{
    /// <summary>
    /// 스킬 슬롯에 대한 클래스
    /// </summary>
    internal class SkillSlot
    {
        Character character;    // 스킬 슬롯을 가진 캐릭터
        int size;               // 스킬 슬롯의 현재 크기
        Skill[] skills;         // 스킬 배열

        /// <summary>
        /// 스킬 슬롯 크기에 대한 프로퍼티
        /// </summary>
        public int SIZE
        {
            get { return size; }
            set { size = value; }
        }

        /// <summary>
        /// 스킬 배열에 대한 프로퍼티
        /// </summary>
        public Skill[] SKILLS
        {
            get { return skills; }
            set { skills = value; }
        }

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
                    skills[i] = skill;
                    if (skills[i].TYPE == SkillType.PASSIVE)    // 패시브 스킬이라면 캐릭터 이벤트를 구독한다
                        ((Skill_Passive)skills[i]).AddListener(character);
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

            skills[index] = null;
            return true;
        }

        /// <summary>
        /// 스킬 슬롯 크기를 변경하는 메소드
        /// </summary>
        /// <param name="count">크기 변동량</param>
        public void ResizeSlot(int count)
        {
            Skill[] newSkills;
            if (size + count <= 0)
                newSkills = new Skill[1];
            else
                newSkills = new Skill[size + count];
            Array.Copy(skills, newSkills, size);
            size += count;
        }

        /// <summary>
        /// 액티브 스킬 사용 메소드
        /// </summary>
        /// <param name="index">사용할 인덱스</param>
        /// <param name="hitable">스킬 대상</param>
        /// <param name="sp">현재 활력</param>
        /// <returns>스킬 사용 성공 여부</returns>
        public bool UseSkill(int index, ITargetable hitable, ref float sp)
        {
            if (index < 0 || index >= size)
                return false;
            if (skills[index] == null)
                return false;
            if (sp < skills[index].COST)
                return false;

            if (skills[index].TYPE == SkillType.ACTIVE)
            {
                if (sp < skills[index].COST)
                    return false;
                skills[index].SetTarget(hitable);       // 스킬 대상 지정
                if (skills[index].Active(sp))           // 스킬 사용
                {
                    skills[index].ResetTarget();        // 스킬 대상 해제
                    sp -= skills[index].COST;           // 활력 소모
                    return true;
                }
            }
            return false;
        }
    }
}
