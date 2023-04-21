using System.Diagnostics.CodeAnalysis;

namespace Homework_04
{
    // 문제 2-2.

    /// <summary>
    /// 계산기
    /// </summary>
    internal class Calculator
    {
        /// <summary>
        /// 계산을 시작한다
        /// </summary>
        public void StartCalculator()
        {
            // 테스트 케이스: 4, -2, 5
            string[] problems = { "1+2-3+4", "1-2+3-4", "5" };
            foreach (string problem in problems)
            {
                Console.WriteLine($"문제 : {problem} : {Calculate(problem)}");
            }
        }

        /// <summary>
        /// 계산 결과를 반환하는 계산기
        /// </summary>
        /// <param name="problem">계산식</param>
        /// <returns>계산 결과</returns>
        float Calculate(string problem)
        {
            Stack<float> nums = new Stack<float>();     // 숫자 스택
            Stack<char> ops = new Stack<char>();        // 연산자 스택
            bool calculate = false;

            for (int i = 0; i < problem.Length; i++)
            {
                // 짝수 번째는 숫자
                if (i % 2 == 0)
                {
                    nums.Push((problem[i] - '0'));
                    if (calculate)
                    {
                        calculate = false;
                        // 두 숫자를 연산하여
                        float temp = nums.Pop();
                        switch (ops.Pop())
                        {
                            case '*':
                                temp = nums.Pop() * temp;
                                break;
                            case '/':
                                temp = nums.Pop() / temp;
                                break;
                        }
                        // 다시 숫자 스택에 넣는다
                        nums.Push(temp);
                    }
                }
                // 홀수 번째는 연산자
                else
                {
                    if(problem[i].Equals('*') || problem[i].Equals('/'))
                    {
                        calculate = true;
                    }
                    ops.Push(problem[i]);
                }
            }

            //
            Stack<float> numQ = new Stack<float>();
            while (nums.Count > 0)
                numQ.Push(nums.Pop());
            Stack<char> opQ = new Stack<char>();
            while (ops.Count > 0)
                opQ.Push(ops.Pop());

            return nums.Pop();
        }
    }
}
