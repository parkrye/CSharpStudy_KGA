using System.ComponentModel;

namespace ProjectRPG
{
    /// <summary>
    /// 아이템 슬롯에 대한 클래스
    /// </summary>
    internal class ItemSlot
    {
        Character character;    // 아이템 슬롯을 가진 캐릭터
        int size;               // 아이템 슬롯 크기
        Item[] items;           // 아이템 배열

        /// <summary>
        /// 아이템 슬롯 크기에 대한 프로퍼티
        /// </summary>
        public int SIZE { get { return size; } }

        /// <summary>
        /// 아이템 배열에 대한 프로퍼티
        /// </summary>
        public Item[] ITEMS { get { return items; } }

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="_character">아이템 슬롯을 가진 캐릭터</param>
        /// <param name="_size">아이템 슬롯의 크기</param>
        public ItemSlot(Character _character, int _size)
        {
            character = _character;
            size = _size;
            items = new Item[size];
        }

        /// <summary>
        /// 아이템을 추가하는 메소드
        /// </summary>
        /// <param name="item">추가할 아이템</param>
        /// <returns>추가 성공 여부</returns>
        public bool AddItem(Item item)
        {
            if (item == null)
                return false;

            for(int i = 0; i < size; i++)
            {
                if (items[i] == null)
                {
                    items[i] = item;
                    if (items[i].TYPE == ItemType.PASSIVE)
                    {
                        // 패시브라면 장착/해제 이벤트 설정
                    }
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 아이템을 제거하는 메소드
        /// </summary>
        /// <param name="index">제거할 인덱스</param>
        /// <returns>제거 성공 여부</returns>
        public bool RemoveItem(int index)
        {
            if (index < 0 || index >= size)
                return false;
            if (items[index] == null)
                return false;

            items[index] = null;
            return true;
        }

        /// <summary>
        /// 아이템 슬롯 크기를 재설정하는 메소드
        /// </summary>
        /// <param name="count">변경값</param>
        public void ResizeSlot(int count)
        {
            Item[] newSkills;
            if (size + count <= 0)
                newSkills = new Item[1];
            else
                newSkills = new Item[size + count];
            Array.Copy(items, newSkills, size);
            size += count;
        }

        /// <summary>
        /// 액티브 아이템을 사용하는 메소드
        /// </summary>
        /// <param name="index">사용할 아이템의 인덱스</param>
        /// <param name="param">능력치 데이터</param>
        /// <param name="targets">사용 대상. 0: 자신 1:추가 대상</param>
        /// <returns>아이템 소모 여부</returns>
        public bool UseItem(int index, int[,] param, params ITargetable[] targets)
        {
            if (index < 0 || index >= size)
                return false;
            if (items[index] == null)
                return false;
            if (items[index].TYPE != ItemType.ACTIVE)
                return false;

            if(items[index].Active(param, targets))
                RemoveItem(index);

            return true;
        }
    }
}
