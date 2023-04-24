namespace Homework_05
{
    internal class GetMidNum
    {
        public GetMidNum()
        {
            int[] arr = new int[99];
            arr = SetNums(arr);
            GetNums1(arr);
            GetNums2(arr);
        }

        /// <summary>
        /// 임의의 999개의 숫자를 입력할 준비를 하는 함수
        /// </summary>
        public int[] SetNums(int[] arr)
        {
            Random random = new Random();
            for (int i = 0; i < 99; i++)
                arr[i] = random.Next(10000) + 1;
            return arr;
        }

        /// <summary>
        /// 각 수를 입력받고 중앙값을 출력하는 함수
        /// </summary>
        public void GetNums1(int[] arr)
        {
            System.Collections.Generic.PriorityQueue<int, int> priorityQueue = new System.Collections.Generic.PriorityQueue<int, int>();

            // 입력부
            for (int i = 0; i < arr.Length; i++)
                priorityQueue.Enqueue(arr[i], arr[i]);

            int count = priorityQueue.Count / 2;                        // Dequeue할 때마다 삭제되는 원소는 우선도가 가장 낮은 원소이므로
            for (int i = 0; i < count; i++)                             // 절반을 제거하면 
                priorityQueue.Dequeue();                                // 다음으로 제거되는 숫자가 중앙값
            Console.WriteLine($"중앙값 : {priorityQueue.Dequeue()}");   // O(n / 2) = O(n)
        }


        /// <summary>
        /// 각 수를 입력받을 때마다 중앙값을 출력하는 함수
        /// 짝수번째라면 그중 작은 수를 출력한다
        /// </summary>
        public void GetNums2(int[] arr)
        {
            // 계속 중앙값을 찾아야하므로 함부로 Dequeue할 수 없음

            // 이전 중앙값보다 작은 큐, 큰 큐
            System.Collections.Generic.PriorityQueue<int, int> less = new System.Collections.Generic.PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b - a));
            System.Collections.Generic.PriorityQueue<int, int> over = new System.Collections.Generic.PriorityQueue<int, int>();

            int mid = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if(i == 0)                                              // 첫 입력은 작은 큐로
                {
                    less.Enqueue(arr[i], arr[i]);
                    mid = less.Peek();
                    Console.WriteLine($"현재 중앙값 : {mid}");
                }
                else
                {
                    if(arr[i] >= mid)                                   // 다음 입력이 이전 중앙값 이상이라면
                    {
                        over.Enqueue(arr[i], arr[i]);                   // 큰 쪽에 넣는다
                        if(over.Count == less.Count + 2)                // 이렇게 더해서가 차이가 2 이상이라면
                            less.Enqueue(over.Peek(), over.Dequeue());  // 하나를 옮긴다
                    }
                    else                                                // 다음 입력이 이전 중앙값 미만이라면
                    {
                        less.Enqueue(arr[i], arr[i]);                   // 작은 쪽에 넣는다
                        if (less.Count == over.Count + 2)               // 이렇게 더해서가 차이가 2 이상이라면
                            over.Enqueue(less.Peek(), less.Dequeue());  // 하나를 옮긴다
                    }

                    if(less.Count >= over.Count)                        // 크기가 같거나 작은 쪽이 크다면
                    {
                        mid = less.Peek();
                        Console.WriteLine($"현재 중앙값 : {mid}");      // 작은 쪽이 중앙값
                    }
                    else if (less.Count < over.Count)                   // 큰 쪽이 크기가 크다면
                    {
                        mid = over.Peek();
                        Console.WriteLine($"현재 중앙값 : {mid}");      // 큰 쪽이 중앙값
                    }
                }
            }
        }
    }
}
