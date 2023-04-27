namespace Homework_08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine(Math.Pow(2, num) - 1);
            Hanoi(num, 1, 2, 3);

            string[] line = Console.ReadLine().Split(" ");
            string answer = "";
            NnM(int.Parse(line[0]), int.Parse(line[1]), answer);

            Lost(Console.ReadLine());

            Paper();

            Triangle();
        }

        /// <summary>
        /// 하노이 : 시간 초과
        /// </summary>
        /// <param name="count"></param>
        /// <param name="start"></param>
        /// <param name="mid"></param>
        /// <param name="end"></param>
        static void Hanoi(int count, int start, int mid, int end)
        {
            if (count == 0)
                return;

            Hanoi(count - 1, start, end, mid);
            Console.WriteLine($"{start} {end}");
            Hanoi(count - 1, mid, start, end);
        }

        /// <summary>
        /// N과 M : 시간 초과
        /// </summary>
        /// <param name="n"></param>
        /// <param name="m"></param>
        /// <param name="answer"></param>
        static void NnM(int n, int m, string answer)
        {
            if (answer.Length == m * 2)
            {
                Console.WriteLine(answer);
                return;
            }

            for (int i = 1; i <= n; i++)
            {
                NnM(i, m, answer + ($"{i} "));
            }
        }

        /// <summary>
        /// 잃어버린 괄호 : 괄호가 여러개인 경우를 고려하지 못함
        /// </summary>
        /// <param name="problem"></param>
        static void Lost(string problem)
        {
            List<int> numbers = new List<int>();
            List<bool> ops = new List<bool>();
            ops.Add(true);
            int num = 0;
            for (int i = 0; i < problem.Length; i++)
            {
                if (problem[i] < 48)
                {
                    numbers.Add(num);
                    if (problem[i] == '+')
                        ops.Add(true);
                    else
                        ops.Add(false);
                    num = 0;
                }
                else
                {
                    num *= 10;
                    num += problem[i] - '0';
                }
                if (i == problem.Length - 1)
                {
                    numbers.Add(num);
                }
            }

            int min = 0;
            for (int i = 0; i < numbers.Count; i++)
                if (ops[i])
                    min += numbers[i];
                else
                    min -= numbers[i];

            // 괄호의 개수
            for (int i = 2; i < numbers.Count; i++)
            {
                //괄호의 위치
                for (int j = 0; i + j - 1 < numbers.Count; j++)
                {
                    int sum = 0;
                    int pareNum = 0;
                    // 괄호 전 연산
                    for (int prev = 0; prev < j; prev++)
                    {
                        if (ops[prev])
                            sum += numbers[prev];
                        else
                            sum -= numbers[prev];
                    }
                    // 괄호 연산
                    for (int pare = j; pare < i + j; pare++)
                    {
                        if (pare == j)
                        {
                            pareNum += numbers[pare];
                        }
                        else
                        {
                            if (ops[pare])
                                pareNum += numbers[pare];
                            else
                                pareNum -= numbers[pare];
                        }
                    }
                    // 괄호 후 연산
                    for (int next = i + j; next < numbers.Count; next++)
                    {
                        if (ops[next])
                            sum += numbers[next];
                        else
                            sum -= numbers[next];
                    }
                    if (ops[j])
                        sum += pareNum;
                    else
                        sum -= pareNum;
                    if (sum < min)
                        min = sum;
                }
            }

            Console.WriteLine(min);
        }


        static void Paper()
        {

        }

        static void Triangle()
        {
            int height = int.Parse(Console.ReadLine());
            int[,] triangle = new int[height, height];
            int size = height;
            for (int i = 2; i < height; i++)
                size *= i;
            int[] answer = new int[size];

            for (int i = 0; i < height; i++)
            {
                string[] line = Console.ReadLine().Split(" ");
                for(int j = 0; j < height; j++)
                {
                    if(j <= i)
                    {
                        triangle[i, j] = int.Parse(line[j]);
                    }
                    else
                    {
                        triangle[i, j] = -1;
                    }
                }
            }
        }
    }
}