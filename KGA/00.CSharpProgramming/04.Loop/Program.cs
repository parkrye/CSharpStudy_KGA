namespace _04.Loop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n;
            /*
             * 반복문 (Iteration)
             * 블록을 반복적으로 실행하는 문장
             */

            // while 반복문
            // 조건식의 true, false에 따라 블록을 반복하는 반복문
            n = 0;
            while (n < 5)
            {
                Console.WriteLine("while 반복 횟수 : " + n);
                n++;
            }

            // do while 반복문
            // 블록을 한 번 실행 후 조건식의 true, false에 따라 블록을 반복하는 반복문
            n = 0;
            do
            {
                Console.WriteLine("do while 반복 횟수 : " + n);
                n++;
            } while (n < 5);

            // for 반복문
            // 초기화, 조건식, 증감 연산으로 구성된 반복문
            for(int i = 0; i < 5; i++)
            {
                Console.WriteLine("for 반복 횟수 : " + n);
            }

            // foreach 반복문
            // 반복가능한 데이터 집합을 처음부터 끝까지 반복
            int[] array = { 1, 2, 3, 4, 5 };
            foreach(int i in array)
            {
                Console.WriteLine("foreach 반복 횟수 : " + i);
            }

            /*
             * <break>
             * 가장 가까운 바깥쪽 반복문 또는 switch 조건문을 종료
             */
            for(int j = 10; j < 20; j++)
            {
                for (int i = 2; i < j; i++)
                {
                    if (j % i == 0)
                    {
                        Console.WriteLine(j + " 는 소수가 아님");
                        break;
                    }
                }
            }

            /*
             * <continue> : 생략, 건너뛰기
             * 가장 가까운 반복문의 처음으로 이동
             */
            for(int i = 0; i < 10; i++)
            {
                if(i % 2 == 0)
                {
                    Console.WriteLine(i + "는 홀수가 아님");
                    continue;
                }
                // 홀수만 할 작업
                Console.WriteLine(i + "는 홀수임");
            }
        }
    }
}