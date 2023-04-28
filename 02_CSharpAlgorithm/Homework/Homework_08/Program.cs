namespace Homework_08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hanoi();

            NnM();

            Lost();

            Paper();

            Triangle();
        }

        static void Hanoi()
        {
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine(Math.Pow(2, num) - 1);
            HanoiSolve(num, 1, 2, 3);
        }

        static void NnM()
        {
            string[] line = Console.ReadLine().Split(" ");
            string answer = "";
            NnMSolve(int.Parse(line[0]), int.Parse(line[1]), answer);
        }

        static void Lost()
        {
            string problem = Console.ReadLine();
            LostSolve(problem);
        }

        static void Paper()
        {
            int size = int.Parse(Console.ReadLine());
            int[,] paper = new int[size,size];
            for(int i = 0; i < size; i++)
            {
                string[] line = Console.ReadLine().Split(" ");
                for(int j = 0; j < line.Length; j++)
                {
                    paper[i,j] = int.Parse(line[j]);
                }
            }
            int blue = 0, white = 0;
            PaperSolve(paper, 0, 0, size, ref blue, ref white);
            Console.WriteLine(white);
            Console.WriteLine(blue);
        }

        static void Triangle()
        {
            int height = int.Parse(Console.ReadLine());

            int[,] triangle = new int[height, height];

            for (int i = 0; i < height; i++)
            {
                string[] line = Console.ReadLine().Split(" ");
                for (int j = 0; j < height; j++)
                {
                    if (j <= i)
                    {
                        triangle[i, j] = int.Parse(line[j]);
                    }
                    else
                    {
                        triangle[i, j] = -1;
                    }
                }
            }

            int max = int.MinValue;
            TriangleSolve(triangle, 0, 0, 0, ref max);
            Console.WriteLine(max);
        }

        /// <summary>
        /// 하노이 : 시간 초과
        /// </summary>
        /// <param name="count">옮겨야하는 개수</param>
        /// <param name="start">옮길 시작지</param>
        /// <param name="mid">중간 지점</param>
        /// <param name="end">옮길 목적지</param>
        static void HanoiSolve(int count, int start, int mid, int end)
        {
            if (count == 0)
                return;

            HanoiSolve(count - 1, start, end, mid);
            Console.WriteLine($"{start} {end}");
            HanoiSolve(count - 1, mid, start, end);
        }

        /// <summary>
        /// N과 M : 시간 초과
        /// </summary>
        /// <param name="n">N</param>
        /// <param name="m">M</param>
        /// <param name="answer">정답 출력</param>
        static void NnMSolve(int n, int m, string answer)
        {
            if (answer.Length == m * 2)
            {
                Console.WriteLine(answer);
                return;
            }

            for (int i = 1; i <= n; i++)
            {
                NnMSolve(i, m, answer + ($"{i} "));
            }
        }

        /// <summary>
        /// 잃어버린 괄호 : 괄호가 여러개인 경우를 고려하지 못함
        /// </summary>
        /// <param name="problem">연산 문자열</param>
        static void LostSolve(string problem)
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


        /// <summary>
        /// 색종이 자르기 : 통과
        /// </summary>
        /// <param name="paper">색종이</param>
        /// <param name="left">왼쪽</param>
        /// <param name="top">위</param>
        /// <param name="size">자른 크기</param>
        /// <param name="blue">파란 개수</param>
        /// <param name="white">하얀 개수</param>
        static void PaperSolve(int[,] paper, int left, int top, int size, ref int blue, ref int white)
        {
            bool isBlue = paper[top, left] == 1;
            for(int i = top; i < top + size; i++)
            {
                for(int j = left; j < left + size; j++)
                {
                    if(isBlue != (paper[i, j] == 1))
                    {
                        PaperSolve(paper, left, top, size/2, ref blue, ref white);
                        PaperSolve(paper, left + size / 2, top, size/2, ref blue, ref white);
                        PaperSolve(paper, left, top + size / 2, size/2, ref blue, ref white);
                        PaperSolve(paper, left + size / 2, top + size / 2, size/2, ref blue, ref white);
                        return;
                    }
                }
            }
            if (isBlue)
                blue++;
            else
                white++;
        }

        /// <summary>
        /// 삼각형 최대 경로 : 시간초과
        /// </summary>
        /// <param name="triangle">삼각형 배열</param>
        /// <param name="row">현재 가로줄</param>
        /// <param name="col">현재 세로줄</param>
        /// <param name="sum">현재 합</param>
        /// <param name="max">최대값</param>
        static void TriangleSolve(int[,] triangle, int row, int col, int sum, ref int max)
        {
            if(row == triangle.GetLength(0))
            {
                if (sum > max)
                    max = sum;
                return;
            }

            if(col > 0)
                TriangleSolve(triangle, row + 1, col - 1, sum + triangle[row, col], ref max);
            TriangleSolve(triangle, row + 1, col, sum + triangle[row, col], ref max);
            if(col < row)
                TriangleSolve(triangle, row + 1, col + 1, sum + triangle[row, col], ref max);
        }
    }
}