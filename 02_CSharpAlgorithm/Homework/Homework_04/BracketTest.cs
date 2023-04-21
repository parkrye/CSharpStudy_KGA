namespace Homework_04
{
    // 문제 2-1.

    /// <summary>
    /// 괄호 검사기
    /// </summary>
    internal class BracketTest
    {
        /// <summary>
        /// 검사를 시작한다
        /// </summary>
        public void StartTester()
        {
            // 테스트 케이스: true, false, true, false, false, true
            string[] problems = { "()[]", "([)]", "([]){}", "(((", ")))", "({}[]({}))" };
            foreach(string problem in problems)
            {
                Console.WriteLine($"문제 : {problem} : {Tester(problem)}");
            }
        }

        /// <summary>
        /// 검사 결과를 반환하는 검사기
        /// </summary>
        /// <param name="problem">검사 문자열</param>
        /// <returns>올바른 괄호형인지</returns>
        bool Tester(string problem)
        {
            // char 스택
            Stack<char> stack = new Stack<char>();
            foreach(char c in problem)
            {
                // 열린 괄호라면 push
                if (c.Equals('(') || c.Equals('[') || c.Equals('{'))
                {
                    stack.Push(c);
                }
                // 열린 괄호가 아닌데(닫힌 괄호인데) 스택이 비어있다면 false
                else if(stack.Count == 0)
                {
                    return false;
                }
                // 닫힌 괄호가 최근에 열린 괄호의 짝이 아니라면 false
                else
                {
                    char p = stack.Pop();
                    switch (c)
                    {
                        case ')':
                            if (!p.Equals('('))
                                return false;
                            break;
                        case ']':
                            if (!p.Equals('['))
                                return false;
                            break;
                        case '}':
                            if (!p.Equals('{'))
                                return false;
                            break;
                    }
                }
            }
            // 작업 후 스택이 남아있다면 false
            if (stack.Count > 0)
                return false;
            // 그 외에는 true
            return true;
        }
    }
}
