namespace DataStructure
{
    internal class Dictionary<TKey, TValue> where TKey : IEquatable<TKey>
    {
        const int DefaultCapacity = 1000;

        struct Entry
        {
            public enum State { None, Using, Deleted }

            public State state;
            public int hashCode;
            public TKey key;
            public TValue value;
        }

        Entry[] table;

        public Dictionary()
        {
            table = new Entry[DefaultCapacity];
        }

        public TValue this[TKey key] 
        { 
            get
            {
                // 1. key를 index로 해싱
                int index = Math.Abs(key.GetHashCode() % table.Length);

                // 2. 사용중인 index까지 이동
                while (table[index].state != Entry.State.None)
                {
                    // 2-1. 만약 이미 같은 키가 저장되어있다면 그 값 반환
                    if (key.Equals(table[index].key) && table[index].state != Entry.State.Deleted)
                    {
                        return table[index].value;
                    }
                    // 2-2. 다음 index로 이동
                    index = index < table.Length - 1 ? index + 1 : 0;
                }

                // 3. 찾지 못했다면 예외 발생
                throw new ArgumentException($"{key}");
            } 
            set
            {
                // 1. key를 index로 해싱
                int index = Math.Abs(key.GetHashCode() % table.Length);

                // 2. 사용중인 index까지 이동
                while (table[index].state != Entry.State.None)
                {
                    // 2-1. 만약 이미 같은 키가 저장되어있다면 값 수정
                    if (key.Equals(table[index].key))
                    {
                        table[index].value = value;
                    }
                    // 2-2. 다음 index로 이동
                    index = index < table.Length - 1 ? index + 1 : 0;
                }

                // 3. 찾지 못했다면 사용중이 아닌 index에 저장
                table[index].hashCode = key.GetHashCode();
                table[index].key = key;
                table[index].value = value;
                table[index].state = Entry.State.Using;
            } 
        }

        public void Add(TKey key, TValue value)
        {
            // 1. key를 index로 해싱
            int index = Math.Abs(key.GetHashCode() % table.Length);

            // 2. 사용중이 아닌 index까지 이동
            while (table[index].state != Entry.State.None)
            {
                // 2-1. 만약 이미 같은 키가 저장되어있다면 예외 발생
                if (key.Equals(table[index].key) && table[index].state != Entry.State.Deleted)
                {
                    throw new ArgumentException($"{key}");
                }
                // 2-2. 다음 index로 이동
                index = index < table.Length - 1 ? index + 1 : 0;
            }

            // 3. 사용중이 아닌 index에 저장
            table[index].hashCode = key.GetHashCode();
            table[index].key = key;
            table[index].value = value;
            table[index].state = Entry.State.Using;
        }

        public bool Remove(TKey key)
        {
            // 1. key를 index로 해싱
            int index = Math.Abs(key.GetHashCode() % table.Length);

            // 2. key값과 동일한 index까지 이동
            while (table[index].state != Entry.State.None)
            {
                // 2-1. 만약 이미 같은 키가 저장되어있다면 찾고 지움
                if (key.Equals(table[index].key) && table[index].state != Entry.State.Deleted)
                {
                    table[index].state = Entry.State.Deleted;
                    return true;
                }
                // 2-2. 다음 index로 이동
                index = index < table.Length - 1 ? index + 1 : 0;
            }
            return false;
        }

        public bool ContainsKey(TKey key)
        {
            // 1. key를 index로 해싱
            int index = Math.Abs(key.GetHashCode() % table.Length);

            // 2. key값과 동일한 index까지 이동
            while (table[index].state != Entry.State.None)
            {
                // 2-1. 만약 이미 같은 키가 저장되어있다면 찾고 true 반환
                if (key.Equals(table[index].key) && table[index].state != Entry.State.Deleted)
                {
                    return true;
                }
                // 2-2. 다음 index로 이동
                index = index < table.Length - 1 ? index + 1 : 0;
            }
            return false;
        }

        public bool TryGetValue(TKey key, out TValue outValue)
        {
            // 1. key를 index로 해싱
            int index = Math.Abs(key.GetHashCode() % table.Length);

            // 2. key값과 동일한 index까지 이동
            while (table[index].state != Entry.State.None)
            {
                // 2-1. 만약 이미 같은 키가 저장되어있다면 찾고 값을 내보내고 true 반환
                if (key.Equals(table[index].key) && table[index].state != Entry.State.Deleted)
                {
                    outValue = table[index].value;
                    return true;
                }
                // 2-2. 다음 index로 이동
                index = index < table.Length - 1 ? index + 1 : 0;
            }
            outValue = default(TValue);
            return false;
        }
    }
}
