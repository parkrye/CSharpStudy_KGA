namespace Homework_03
{
    internal class Program
    {
        /// <summary>
        /// 비교를 위한 대리자
        /// </summary>
        /// <typeparam name="T">비교할 값의 형식</typeparam>
        /// <param name="left">값 1</param>
        /// <param name="right">값 2</param>
        /// <returns>비교 결과</returns>
        public delegate bool MyComparer<T>(T left, T right) where T : IComparable;

        /// <summary>
        /// 오름차순
        /// </summary>
        /// <typeparam name="T">비교할 값의 형식</typeparam>
        /// <param name="left">값 1</param>
        /// <param name="right">값 2</param>
        /// <returns>값 1이 클 경우 true, 작거나 같을 경우 false</returns>
        public static bool Ascending<T>(T left, T right) where T : IComparable
        {
            if (left.CompareTo(right) > 0)
                return true;
            return false;
        }

        /// <summary>
        /// 내림차순
        /// </summary>
        /// <typeparam name="T">비교할 값의 형식</typeparam>
        /// <param name="left">값 1</param>
        /// <param name="right">값 2</param>
        /// <returns>값 1이 클 경우 false, 작거나 같을 경우 true</returns>
        public static bool Descending<T>(T left, T right) where T : IComparable
        {
            if (left.CompareTo(right) <= 0)
                return true;
            return false;
        }

        /// <summary>
        /// 정렬 메소드
        /// </summary>
        /// <typeparam name="T">비교할 값의 형식</typeparam>
        /// <param name="values">IList 인터페이스를 포함하는 형식</param>
        /// <param name="comparer">비교를 위한 대리자</param>
        public static void Sort<T>(IList<T> values, MyComparer<T> comparer) where T : IComparable
        {
            for(int i = 0; i < values.Count; i++)
            {
                for(int j = i + 1; j < values.Count; j++)
                {
                    if (comparer(values[i], values[j]))
                    {
                        T temp = values[i];
                        values[i] = values[j];
                        values[j] = temp;
                    }
                }
            }
        }

        /// <summary>
        /// 정수 값을 갖는 IEnumerable의 평균 값을 구하는 메소드
        /// </summary>
        /// <param name="values">정수 값을 갖는 IEnumerable</param>
        /// <returns>평균 값</returns>
        public static int Average(IEnumerable<int> values)
        {
            int result = 0;
            IEnumerator<int> enumerator = values.GetEnumerator();
            while (enumerator.MoveNext()){
                result += enumerator.Current;
            }
            return result;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("문제 1~2.");
            List<int> list = new List<int>();
            for (int i = 10; i > 0; i--) list.Add(i);

            Console.Write("List / foreach : ");
            foreach (int i in list) Console.Write($"{i} ");
            Console.WriteLine();

            Console.Write("List / enumerator : ");
            IEnumerator<int> listIter = list.GetEnumerator();
            while (listIter.MoveNext()) Console.Write($"{listIter.Current} ");
            Console.WriteLine();

            LinkedList<int> linkedList = new LinkedList<int>();
            for (int i = 10; i > 0; i--) linkedList.AddLast(i);

            Console.Write("LinkedList / foreach : ");
            foreach (int i in linkedList) Console.Write($"{i} ");
            Console.WriteLine();

            Console.Write("LinkedList / enumerator : ");
            IEnumerator<int> linkedListIter = linkedList.GetEnumerator();
            while (linkedListIter.MoveNext()) Console.Write($"{linkedListIter.Current} ");
            Console.WriteLine();
            Console.WriteLine();


            Console.WriteLine("문제 0.");
            MyComparer<int> ascender = Ascending;
            int[] arr = new int[10];
            for (int i = 10; i > 0; i--) arr[10 - i] = i;

            Console.Write("Array / foreach : ");
            foreach (int i in arr) Console.Write($"{i} ");
            Console.WriteLine();

            Sort(arr, ascender);
            Console.Write("Array / foreach / ascend : ");
            foreach (int i in arr) Console.Write($"{i} ");
            Console.WriteLine();

            MyComparer<int> descender = Descending;
            System.Collections.Generic.List<int> list2 = new System.Collections.Generic.List<int>();
            for (int i = 0; i < 10; i++) list2.Add(i);

            Console.Write("List / foreach : ");
            foreach (int i in list2) Console.Write($"{i} ");
            Console.WriteLine();

            Sort(list2, descender);
            Console.Write("List / foreach / descend : ");
            foreach (int i in list2) Console.Write($"{i} ");
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("문제 1.");
            Console.Write("Array / Average : ");
            Console.WriteLine(Average(arr));
            Console.Write("List / Average : ");
            Console.WriteLine(Average(list2));
        }
    }
}