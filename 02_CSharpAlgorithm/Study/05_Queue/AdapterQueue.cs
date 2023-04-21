﻿namespace DataStructure
{
    /******************************************************
	 * 어댑터 패턴 (Adapter)
	 * 
	 * 한 클래스의 인터페이스를 사용하고자 하는 다른 인터페이스로 변환
	 ******************************************************/

    public class AdapterQueue<T>
    {
        private LinkedList<T> container;

        public AdapterQueue()
        {
            container = new LinkedList<T>();
        }

        public void Enqueue(T item)
        {
            container.AddLast(item);
        }

        public T Dequeue()
        {
            T value = container.First<T>();
            container.RemoveFirst();
            return value;
        }

        public T Peek()
        {
            return container.First<T>();
        }

        public int Count
        {
            get { return container.Count; }
        }
    }
}