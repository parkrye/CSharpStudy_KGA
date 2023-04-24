using static ProjectRPG.Character;

namespace ProjectRPG
{
    /// <summary>
    /// 플레이어 파티에 대한 클래스
    /// </summary>
    internal class Party
    {
        PC[] party;     // 파티 구성원. 최대 넷
        int members;    // 파티 인원. 0~4

        /// <summary>
        /// 파티 구성원에 대한 프로퍼티
        /// </summary>
        public PC[] PCs { get { return party; } }

        /// <summary>
        /// 파티 인원에 대한 프로퍼티
        /// </summary>
        public int MEMBERS { get { return members; } }

        /// <summary>
        /// 파티 생성자. 최대 4
        /// </summary>
        public Party()
        {
            party = new PC[4];
        }

        /// <summary>
        /// 파티 추가 메소드
        /// </summary>
        /// <param name="pc">추가할 캐릭터</param>
        /// <returns>추가 성공 여부</returns>
        public bool AddPC(PC pc)
        {
            if (members == 4)
                return false;
            for(int i = 0; i < 4; i++)
            {
                if (party[i] == null)
                {
                    party[i] = pc;
                    members++;
                    return true;
                }
            }
            return true;
        }

        /// <summary>
        /// 파티 제외 메소드
        /// </summary>
        /// <param name="index">제외할 파티원 인덱스</param>
        /// <returns>제외 성공 여부</returns>
        public bool RemovePC(int index)
        {
            if (index < 0 || index >= 4)
                return false;
            if (party[index] != null)
            {
                party[index] = null;
                members--;
                return true;
            }
            return false;
        }

        /// <summary>
        /// 파티 인원이 비어있는지 반환하는 메소드
        /// </summary>
        /// <returns>파티가 비어있는지 여부</returns>
        public bool IsEmpty()
        {
            if (members > 0)
                return false;
            return true;
        }

        /// <summary>
        /// 파티의 특정 캐릭터를 반환하는 메소드
        /// </summary>
        /// <param name="index">반환할 인덱스</param>
        /// <returns>인덱스의 캐릭터. 없을 경우 null 반환</returns>
        public PC GetMember(int index)
        {
            if (index < 0 || index >= 4)
                return null;
            return party[index];
        }

        public void AddListenerOnTurnEnd(Action action)
        {
            if(members > 0)
            {
                foreach(PC pc in party)
                {
                    action += pc.TimeFlow;
                }
            }
        }

        public bool Contains(PC pc)
        {
            return party.Contains(pc);
        }
    }
}
