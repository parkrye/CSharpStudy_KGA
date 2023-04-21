using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_04
{
    // 문데 3-2.

    /// <summary>
    /// 조세푸스 문제
    /// </summary>
    internal class Josephus
    {
        /// <summary>
        /// 문제 해결 메소드
        /// </summary>
        public void StartKilling()
        {
            Queue<int> people = new Queue<int>();   // 사람들
            Queue<int> oredr = new Queue<int>();    // 죽은 순서
            int n = 41;     // 인원
            int k = 3;      // 죽는 순서

            for(int i = 0; i < n; i++)
                people.Enqueue(i);

            int index = 0;
            while (people.COUNT >= k)   // 인원이 죽는 순서보다 작아지면 종료
            {
                if(index == k)  // 죽는 순서가 오면
                {
                    oredr.Enqueue(people.Dequeue());
                    index = 0;  // 죽고 순서 리셋
                }
                else
                {   // 순서가 아니라면 큐 끝으로
                    people.Enqueue(people.Dequeue());
                }
                index++;    // 순서 돔
            }

            // 출력부
            Console.Write("죽은 순서 : ");
            while (!oredr.IsEmpty())
            {
                Console.Write($"{oredr.Dequeue()}");
                if(!oredr.IsEmpty())
                    Console.Write(" => ");
            }
            Console.WriteLine();

            Console.Write("산 사람 : ");
            while (!people.IsEmpty())
            {
                Console.Write($"{people.Dequeue()} ");
            }
            Console.WriteLine();
        }
    }
}
