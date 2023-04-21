﻿namespace DataStructure
{
    public class Queue<T>
    {
        private const int DefaultCapacity = 4;

        private T[] array;
        private int head;
        private int tail;

        /// <summary>
        /// 환형 구성
        /// </summary>
        public Queue()
        {
            array = new T[DefaultCapacity + 1];
            head = 0;
            tail = 0;
        }

        public int Count
        {
            get
            {
                if (head <= tail)
                    return tail - head;
                else
                    return tail + (array.Length - head);
            }
        }

        public void Clear()
        {
            array = new T[DefaultCapacity + 1];
            head = 0;
            tail = 0;
        }

        public void Enqueue(T item)
        {
            if (IsFull())
            {
                Grow();
            }

            array[tail] = item;
            MoveNext(ref tail);
        }

        public T Dequeue()
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            T result = array[head];
            MoveNext(ref head);
            return result;
        }

        public bool TryDequeue(out T result)
        {
            if (IsEmpty())
            {
                result = default(T);
                return false;
            }

            result = array[head];
            MoveNext(ref head);
            return true;
        }

        public T Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            return array[head];
        }

        public bool TryPeek(out T result)
        {
            if (IsEmpty())
            {
                result = default(T);
                return false;
            }

            result = array[head];
            return true;
        }

        /// <summary>
        /// 큐는 현재 길이 + 1 크기로 생성하여 전단, 후단의 위치 차이를 생성
        /// </summary>
        private void Grow()
        {
            int newCapacity = array.Length * 2;
            T[] newArray = new T[newCapacity + 1];
            if (!IsEmpty())
            {
                if (head < tail)
                {
                    Array.Copy(array, head, newArray, 0, tail);
                }
                else
                {
                    Array.Copy(array, head, newArray, 0, array.Length - head);
                    Array.Copy(array, 0, newArray, array.Length - head, tail);
                }
            }

            array = newArray;
            tail = Count;
            head = 0;
        }

        /// <summary>
        /// TH라면 true, 환형이므로 H(시작) ~ T(끝)도 TH이므로 true
        /// </summary>
        /// <returns></returns>
        private bool IsFull()
        {
            if (head > tail)
            {
                return head == tail + 1;
            }
            else
            {
                return head == 0 && tail == array.Length - 1;
            }
        }

        private bool IsEmpty()
        {
            return head == tail;
        }

        /// <summary>
        /// head + 1, 환형이므로 끝이면 0으로
        /// </summary>
        /// <param name="index"></param>
        private void MoveNext(ref int index)
        {
            index = (index == array.Length - 1) ? 0 : index + 1;
        }
    }
}