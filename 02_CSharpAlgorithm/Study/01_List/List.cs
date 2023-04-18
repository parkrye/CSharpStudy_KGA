using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    internal class List<T>
    {
        T[] items;
        public T this[int index]
        {
            get { return items[index]; }
            set { items[index] = value; }
        }

        int count;
        public int COUNT 
        { 
            get { return count; }
            set { count = value; } 
        }

        int capacity;
        public int CAPACITY
        {
            get { return capacity; }
            set { capacity = value; }
        }

        public List() 
        {
            count = 0;
            capacity = 10;
            items = new T[capacity];
        }

        public void Add(T value)
        {
            items[count++] = value;
            if(count == capacity)
                Grow();
        }

        void Grow()
        {
            capacity *= 2;
            T[] newItems = new T[capacity];
            for (int i = 0; i < count; i++)
                newItems[i] = items[i];
            items = newItems;
        }

        public void Remove(T value)
        {
            if(count == 0)
                throw new Exception("List is Empty");
            for (int i = 0; i < count; i++)
            {
                if (items[i].Equals(value))
                {
                    for(int j = i; j < count - 1; j++)
                        items[j] = items[j + 1];
                    count--;
                    return;
                }
            }
            throw new Exception($"{value} is Not in List");
        }

        public void Clear()
        {
            count = 0;
            capacity = 10;
            items = new T[capacity];
        }

        public int IndexOf(T value)
        {
            for (int i = 0; i < count; i++)
                if (items[i].Equals(value))
                    return i;
            return -1;
        }

        public string SpreadElements()
        {
            string result = "";
            for(int i = 0; i < count; i++)
                result += items[i].ToString();
            return result;
        }
    }
}
