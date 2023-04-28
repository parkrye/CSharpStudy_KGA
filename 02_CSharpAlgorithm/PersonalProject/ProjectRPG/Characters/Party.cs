using System.Drawing;
using System.Xml.Linq;
using static ProjectRPG.Character;

namespace ProjectRPG
{
    /// <summary>
    /// 플레이어 파티에 대한 클래스
    /// </summary>
    [Serializable]
    internal class Party
    {
        PC[] party;     // 파티 구성원. 최대 넷
        int members;    // 파티 인원. 0~4
        int size;       // 파티 최대 인원. 4

        /// <summary>
        /// 파티 구성원에 대한 프로퍼티
        /// </summary>
        public PC[] PCs { get { return party; } }

        /// <summary>
        /// 파티 인원에 대한 프로퍼티
        /// </summary>
        public int MEMBERS { get { return members; } }

        /// <summary>
        /// 살아있는 캐릭터 수에 대한 프로퍼티
        /// </summary>
        public int LIVES
        {
            get 
            { 
                int count = 0;
                for(int i = 0; i < members; i++)
                    if (PCs[i].NOW_HP > 0)
                        count++;
                return count;
            }
        }

        /// <summary>
        /// 파티 생성자. 최대 4
        /// </summary>
        public Party(int _size = 4)
        {
            size = _size;
            party = new PC[size];
        }

        public Party(SerializedParty serializedParty)
        {
            party = new PC[serializedParty.party.Length];
            for(int i = 0; i < serializedParty.party.Length && serializedParty.party[i] != null; i++)
            {
                PC pc = new PC(serializedParty.party[i]);
                party[i] = pc;
            }
            members = serializedParty.members;
            size = serializedParty.size;
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
            for(int i = 0; i < size; i++)
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
            if (index < 0 || index >= size)
                return false;
            if (party[index] != null)
            {
                for(int i = index; i < size - 1; i++)
                {
                    party[i] = party[i + 1];
                }
                party[size - 1] = null;
                members--;
                return true;
            }
            return false;
        }

        public bool Contains(PC pc)
        {
            return party.Contains(pc);
        }

        public SerializedParty GetSerialized()
        {
            return new SerializedParty(party, members, size);
        }
    }

    [Serializable]
    internal class SerializedParty
    {
        public SerializedPC[] party;     // 파티 구성원. 최대 넷
        public int members;    // 파티 인원. 0~4
        public int size;       // 파티 최대 인원. 4

        public SerializedParty(PC[] _party, int _members, int _size)
        {
            party = new SerializedPC[_party.Length];
            for(int i = 0; i < _party.Length && _party[i] != null; i++)
                party[i] = _party[i].GetSerialized();
            members = _members;
            size = _size;
        }
    }
}
