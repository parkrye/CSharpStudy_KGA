namespace Homework_04
{
    // 문제 1.

    /// <summary>
    /// 순환배열로 구현한 큐
    /// </summary>
    internal class Queue<T>
    {
        T[] list;                   // 사용할 배열

        const int defaultSize = 4;  // 기초 크기

        int head;                   // 출력 위치
        int tail;                   // 입력 위치

        /// <summary>
        /// 생성자
        /// </summary>
        public Queue()
        {
            list = new T[defaultSize];
            head = 0;
            tail = 0;
        }

        /// <summary>
        /// 큐의 마지막에 요소를 추가한다
        /// </summary>
        /// <param name="item">추가할 요소</param>
        public void Enqueue(T item)
        {
            if (IsFull())                   // 큐가 꽉 차있는 상태라면
                Grow();                     // 배열을 키운다
            else if (tail == list.Length)   // 그렇지 않고 입력 위치가 마지막 위치라면
                    tail = 0;               // 입력 위치를 0으로 옮긴다

            list[tail] = item;              // 입력 위치에 요소를 저장하고

            tail++;                         // 입력 위치를 하나 옮긴다
        }

        /// <summary>
        /// 큐의 가장 앞의 요소를 반환하고 삭제한다
        /// </summary>
        /// <returns>큐의 가장 앞의 요소</returns>
        /// <exception cref="InvalidOperationException">큐가 비어있다면 발생</exception>
        public T Dequeue()
        {
            if (IsEmpty())                              // 큐가 비어있다면
                throw new InvalidOperationException();  // 예외 발생

            T item = list[head];                        // 큐의 출력 위치의 값을 저장한다

            head++;                                     // 출력 위치를 하나 옮기고
            if (head == list.Length)                    // 출력 위치가 마지막 위치라면
                head = 0;                               // 출력 위치를 0으로 옮긴다

            return item;
        }

        /// <summary>
        /// 큐의 가장 앞의 요소를 반환한다
        /// </summary>
        /// <returns>큐의 가장 앞의 요소</returns>
        /// <exception cref="InvalidOperationException">큐가 비어있다면 발생</exception>
        public T Peek()
        {
            if (IsEmpty())                              // 큐가 비어있다면
                throw new InvalidOperationException();  // 예외 발생

            return list[head];
        }

        /// <summary>
        /// 배열의 크기를 증가시킨다
        /// </summary>
        void Grow()
        {
            if (head < tail)                                                // 출력 위치가 입력 위치보다 앞에 있다면
            {
                T[] newList = new T[list.Length * 2];                       // 기존 배열 2배 크기의 새 배열을 생성하고
                Array.Copy(list, newList, list.Length);                     // 기존 배열을 새 배열에 얕은 복사하고
                list = newList;                                             // 기존 배열이 새 배열을 참조하도록 한다
            }
            else if (head > tail)                                           // 입력 위치가 출력 위치보다 앞에 있다면
            {
                T[] newList = new T[list.Length * 2];                       // 기존 배열 2배 크기의 새 배열을 생성하고
                Array.Copy(list, head, newList, 0, list.Length - head);     // 기존 배열 출력 위치 ~ 마지막 요소를 새 배열의 0부터의 위치에 복사하고
                Array.Copy(list, 0, newList, list.Length - head, head - 1); // 기존 배열 0 ~ 입력 위치 전까지의 요소를 새 배열의 다음 위치에 복사하고
                list = newList;                                             // 기존 배열이 새 배열을 참조하도록 한다
                tail = head + tail + 1;                                     // 입력 위치는 새 배열의 복사된 위치 다음으로 옮기고
                head = 0;                                                   // 출력 위치는 0으로 옮긴다
            }
        }

        /// <summary>
        /// 큐가 가득 찼는지 반환한다
        /// </summary>
        /// <returns>큐가 가득 찼는지 여부</returns>
        public bool IsFull()
        {
            if (head < tail)                                    // 출력 위치가 입력 위치보다 앞에 있다면
            {
                return head == 0 && tail == list.Length - 1;    // 출력 위치가 입력 위치 다음이라면(환형 구조이므로) 가득 찬 것이다
            }
            else if (head > tail)                               // 입력 위치가 출력 위치보다 앞에 있다면
            {
                return head == tail + 1;                        // 출력 위치가 입력 위치 다음이라면 가득 찬 것이다
            }
            return false;                                       // 그 외에는 가득 차지 않은 것이다
        }

        /// <summary>
        /// 큐가 비어있는지 반환한다
        /// </summary>
        /// <returns>큐가 비어있는지 여부</returns>
        public bool IsEmpty()
        {
            return head == tail;    // 출력 위치와 입력 위치가 같다면 비어있는 것이다
        }
    }
}
