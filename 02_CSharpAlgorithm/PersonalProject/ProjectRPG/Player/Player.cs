using System.Reflection.Metadata.Ecma335;

namespace ProjectRPG
{
    internal class Player
    {
        string name;             // 플레이어 이름
        int money;               // 플레이어 자금
        Party party;             // 현재 파티

        List<Item> inventory;    // 보유 아이템들
        List<PC> employed;       // 고용한 캐릭터들

        /// <summary>
        /// 플레이어 이름에 대한 프로퍼티
        /// </summary>
        public string NAME { get { return name; } }

        /// <summary>
        /// 플레이어 자금에 대한 프로퍼티
        /// </summary>
        public int MONEY { get { return money; } }

        /// <summary>
        /// 현재 파티에 대한 프로퍼티
        /// </summary>
        public Party PARTY { get { return party; } set { party = value; } }

        /// <summary>
        /// 보유 아이템들에 대한 프로퍼티
        /// </summary>
        public List<Item> INVENTORY { get { return inventory; } set { inventory = value; } }

        /// <summary>
        /// 고용한 캐릭터들에 대한 프로퍼티
        /// </summary>
        public List<PC> EMPLOYED { get { return employed; } set { employed = value; } }

        /// <summary>
        /// 생성자
        /// 초기 자금 100
        /// </summary>
        /// <param name="_name">플레이어 이름. 초기값 "플레이어"</param>
        public Player(string _name = "플레이어")
        {
            name = _name;
            money = 10;
            party = new Party();
            inventory = new List<Item>();
            employed = new List<PC>();
        }

        /// <summary>
        /// 돈을 추가하는 메소드
        /// </summary>
        /// <param name="add">추가할 금액</param>
        public void AddMoney(int add)
        {
            money += add;
        }

        /// <summary>
        /// 돈을 제거하는 메소드
        /// </summary>
        /// <param name="lost">제거할 금액</param>
        public bool LoseMoney(int lost)
        {
            if (HaveMoney(lost))
                money -= lost;
            else
                return false;
            return true;
        }

        /// <summary>
        /// 돔을 가지고 있는지 확인하는 메소드
        /// </summary>
        /// <param name="comparison">비교 대상</param>
        /// <returns>비교 대상 이상의 돈을 보유하고 있는지</returns>
        public bool HaveMoney(int comparison)
        {
            if (money >= comparison)
                return true;
            return false;
        }

        /// <summary>
        /// 아이템을 추가하는 메소드
        /// </summary>
        /// <param name="item">추가할 아이템</param>
        public void AddItem(Item item)
        {
            inventory.Add(item);
        }

        /// <summary>
        /// 아이템을 삭제하는 메소드
        /// </summary>
        /// <param name="index">삭제할 아이템 인덱스</param>
        /// <returns>삭제한 아이템</returns>
        public Item RemoveItem(int index)
        {
            if (index < 0 || index >= inventory.Count)
                return null;
            Item item = inventory[index];
            inventory.RemoveAt(index);
            return item;
        }

        /// <summary>
        /// 캐릭터를 고용하는 메소드
        /// </summary>
        /// <param name="character">고용할 캐릭터</param>
        public void EmployCharacter(PC character)
        {
            employed.Add(character);
        }

        /// <summary>
        /// 캐릭터를 삭제하는 메소드
        /// </summary>
        /// <param name="index">삭제할 캐릭터 인덱스</param>
        /// <returns>삭제한 캐릭터</returns>
        public PC FireCharacter(int index)
        {
            if (index < 0 || index >= employed.Count)
                return null;
            PC character = employed[index];
            employed.RemoveAt(index);
            return character;
        }

        /// <summary>
        /// 파티의 캐릭터를 고용풀로 옮기는 메소드
        /// </summary>
        /// <param name="index">파티에서 옮길 캐릭터 인덱스</param>
        /// <returns>이동 성공 여부</returns>
        public bool PartyToEmployed(int index)
        {
            if (index < 0 || index >= 4)
                return false;
            if (PARTY.PCs[index] == null)
                return false;
            EmployCharacter(party.PCs[index]);
            if (party.RemovePC(index))
                return true;
            FireCharacter(employed.Count - 1);
            return false;
        }

        /// <summary>
        /// 고용풀의 캐릭터를 파티로 옮기는 메소드
        /// </summary>
        /// <param name="index">고용풀에서 옮길 캐릭터 메소드</param>
        /// <returns>이동 성공 여부</returns>
        public bool EmployedToParty(int index)
        {
            if (index < 0 || index >= employed.Count)
                return false;
            if (party.MEMBERS == party.PCs.Length)
                return false;
            party.AddPC(FireCharacter(index));
            return true;
        }
    }
}
