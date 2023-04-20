using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Iterator
{
    internal class List<T> : IEnumerable<T>
    {
        T[] items;
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= size)
                    throw new IndexOutOfRangeException();
                return items[index];
            }
            set
            {
                if (index < 0 || index >= size)
                    throw new IndexOutOfRangeException();
                items[index] = value;
            }
        }

        int size;
        public int Count
        {
            get { return size; }
        }

        const int defaultCapacity = 10;
        public int Capacity
        {
            get { return items.Length; }
        }

        public List()
        {
            size = 0;
            items = new T[defaultCapacity];
        }

        public void Add(T value)
        {
            if (size == Capacity)
                Grow();
            items[size++] = value;
        }

        void Grow()
        {
            T[] newItems = new T[Capacity * 2];
            Array.Copy(items, 0, newItems, 0, size);
            items = newItems;
        }

        public bool Remove(T value)
        {
            int index = IndexOf(value);
            if (index < 0)
                return false;
            else
            {
                RemoveAt(index);
                return true;
            }
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= size)
                throw new IndexOutOfRangeException();
            size--;
            Array.Copy(items, index + 1, items, index, size - index);
        }

        public void Clear()
        {
            size = 0;
            items = new T[defaultCapacity];
        }

        public int IndexOf(T value)
        {
            return Array.IndexOf(items, value);
        }

        public T? Find(Predicate<T> match)
        {
            if (match == null)
                throw new ArgumentNullException("match");
            foreach (T item in items)
                if (match(item))
                    return item;
            return default(T);
        }

        public int? FindIndex(Predicate<T> match)
        {
            if (match == null)
                throw new ArgumentNullException("match");
            for (int i = 0; i < size; i++)
                if (match(items[i]))
                    return i;
            return -1;
        }

        public string PrintElements()
        {
            if (size == 0)
                return "Empty List";
            string result = "[";
            for (int i = 0; i < size; i++)
                result += items[i] + ",";
            result += "]";
            return result;
        }

        public struct Enumerator : IEnumerator<T>
        {
            List<T> list;
            int index;
            T current;

            public T Current { get { return current; } }

            public Enumerator(List<T> _list)
            {
                list = _list;
                index = 0;
                current = default(T);
            }

            object IEnumerator.Current { get { return current; } }

            public void Dispose()
            {
                // throw new NotImplementedException();
            }

            public bool MoveNext()
            {
                if(index < list.Count)
                {
                    current = list[index];
                    index++;
                    return true;
                }
                return false;
            }

            public void Reset()
            {
                current = default(T);
                index = 0;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(this);
        }
    }
}
