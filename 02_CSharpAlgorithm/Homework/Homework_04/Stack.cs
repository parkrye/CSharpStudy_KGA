namespace Homework_04
{
    // 문제 1.

    /// <summary>
    /// 어댑터로 구현한 스택
    /// </summary>
    /// <typeparam name="T">스택의 자료형</typeparam>
    internal class Stack<T>
    {
        List<T> list = new List<T>();   // 사용할 리스트

        /// <summary>
        /// 생성자
        /// </summary>
        public Stack()
        {
            list = new List<T>();
        }

        public int Count
        {
            get { return list.Count; }
        }

        /// <summary>
        /// 리스트의 마지막에 요소를 추가한다
        /// </summary>
        /// <param name="item">추가할 요소</param>
        public void Push(T item)
        {
            list.Add(item); // 리스트의 끝에 요소를 추가한다
        }

        /// <summary>
        /// 리스트의 마지막 요소를 반환하고 삭제한다
        /// </summary>
        /// <returns>리스트의 마지막 요소</returns>
        public T Pop()
        {
            T item = list.Last();           // 리스트의 마지막 요소를 별도의 변수에 저장하고
            list.RemoveAt(list.Count - 1);  // 리스트의 마지막 요소를 삭제하고
            return item;                    // 저장해둔 리스트의 마지막 요소를 반환한다
        }

        /// <summary>
        /// 리스트의 마지막 요소를 반환한다
        /// </summary>
        /// <returns>리스트의 마지막 요소</returns>
        public T Peek()
        {
            return list.Last<T>();
        }
    }
}
