namespace HomeWork_3
{
    internal class Program
    {
        // 문제 1.
        // 두 정수 left, right를 매개변수로 받아 더 큰 값을 반환하는 함수
        static int Bigger(int left, int right)
        {
            // 삼항연산자를 이용하여 더 큰 수를 반환
            return left > right ? left : right;
        }

        // 문제 2.
        // 배열 arr을 매개변수로 받아 배열에서 가장 큰 값을 반환하는 함수
        static int HighValue(int[] arr)
        {
            // 최대값을 배열의 첫번째 값으로 초기화
            int high = arr[0];
            // 배열을 순회하여
            for(int i = 0; i < arr.Length; i++)
            {
                // 만약 배열의 현재 값이 최대값보다 크다면
                if (arr[i] > high)
                {
                    // 최대값을 현재 값으로 한다
                    high = arr[i];
                }
            }
            // 최대값을 반환
            return high;
        }

        // 문제 3.
        // 두 정수 n1, n2를 매개변수로 받아 최대공약수를 반환하는 함수
        static int GetGCD(int n1, int n2)
        {
            // 최대공약수를 저장할 변수
            int gcd = 0;
            // n1 < n2를 가정하고 작성한 코드이므로, 대소가 반대일 경우 값을 수정
            if(n2 < n1)
            {
                int tmp = n1;
                n1 = n2;
                n2 = tmp;
            }

            // 1부터 작은 값(n1)까지 순회하며
            for(int i = 1; i <= n1; i++)
            {
                // 만약 현재 값이 n1, n2의 약수라면
                if((n1 % i == 0) && (n2 % i == 0))
                {
                    // 현재까지의 공약수 중 최대값으로 저장한다
                    gcd = i;
                }
            }

            // 저장된 가장 큰 공약수(최대공약수)를 반환
            return gcd;
        }

        // 문제 4.
        // 두 정수 n1, n2를 매개변수로 받아 최소공배수를 반환하는 함수 
        static int GetLCM(int n1, int n2)
        {
            // 최소공배수를 저장할 변수
            int lcm = 0;
            // 최대공약수를 구하여 저장
            int gcd = GetGCD(n1, n2);

            // 최대공약수의 배수로 순회하여
            for(int i = 1; i * gcd <= n1 * n2; i++)
            {
                // n1, n2가 현재 최대공약수의 약수라면
                lcm = i * gcd;
                if(lcm % n1 == 0 && lcm % n2 == 0)
                {
                    // 현재 값이 최소공배수이므로 반환
                    return lcm;
                }
            }

            // 만약 최소공배수를 발견할 수 없었다면 -1을 반환
            return -1;
        }

        // 문제 5-1.
        //두 실수 n1, n2를 매개변수로 받아 n1이 더 크다면 true를 반환하는 함수
        static bool Bigger(float n1, float n2)
        {
            return n1 > n2;
        }

        // 문제 5-2.
        // 두 배열 arr1, arr2을 매개변수로 받아 arr1의 평균이 더 클 경우 true를 반환하는 함수
        static bool BiggerArray(int[] arr1, int[] arr2)
        {
            // 각 배열의 평균을 저장할 변수
            float avg1 = 0;
            float avg2 = 0;

            // 각 배열을 순회하여 변수에 배열 요소 값을 저장
            for (int i = 0; i < arr1.Length; i++)
                avg1 += arr1[i];
            for (int i = 0; i < arr2.Length; i++)
                avg2 += arr2[i];

            // 저장한 배열 요소 값의 합을 배열의 크기로 나눈다
            avg1 /= arr1.Length;
            avg2 /= arr2.Length;

            // 두 변수의 크기를 비교하여 bool 값으로 반환
            return Bigger(avg1, avg2);
        }

        // 추가 문제
        // 규칙 출력 함수
        static void PrintHelp()
        {
            PrintLine("※☆★숫자 야구 게임★☆※");
            PrintLine("[게임 규칙 안내]");
            PrintLine("[매 라운드마다 네 자리 숫자를 입력합니다]");
            PrintLine("[정답 숫자와 같은 자리에 같은 숫자가 포함되어있다면 스트라이크! (S)]");
            PrintLine("[정답 숫자와 다른 자리에 같은 숫자가 포함되어있다면 볼! (B)]");
            PrintLine("[전혀 엉뚱한 숫자가 포함되어있다면 아웃! (O)]");
            PrintLine("[엔터를 입력할 경우 게임을 종료합니다]");
            PrintLine();
        }

        // 정답 확인 함수
        // 입력 문자열과 정답 문자열을 비교하여 정수형 배열에 결과를 반환하는 함수
        static int[] AnswerCheck(string answer, string code)
        {
            int[] result = new int[3];
            for (int i = 0; i < 4; i++)                                     // 입력한 정답을 각 글자마다 확인
            {
                bool notOut = false;                                        // 이번 글자의 아웃 여부
                for (int j = 0; j < 4; j++)                                 // 정답 코드를 각 글자마다 확인
                {
                    if (answer[i] == code[j])                               // 입력 글자가 정답 글자와 일치한다면
                    {
                        notOut = true;                                      // 이 글자는 아웃이 아니다
                        if (i == j)                                         // 만약 일치한 위치가 같다면
                        {
                            result[0]++;                                    // 스트라이크를 추가한다
                        }
                        else                                                // 일치한 위치가 다르다면
                        {
                            result[1]++;                                    // 볼을 추가한다
                        }
                    }
                }
                if (!notOut)                                                // 만약 글자가 일치한 경우가 없었다면
                {
                    result[2]++;                                            // 아웃을 추가한다
                }
            }
            return result;
        }

        // 숫자 야구 문제
        // 문자열 정답 코드, 정수형 라운드 수를 매개번수로 받아 숫자 야구 게임을 실행하는 함수
        static void BaseBallGame(string _code, int _maxRound)
        {
            string code = _code;                                                // 정답 숫자
            int maxRound = _maxRound;                                           // 최대 라운드
            int nowRound = 1;                                                   // 현재 라운드
            bool win = false;                                                   // 게임 결과

            PrintHelp();

            while (nowRound <= maxRound)                                        // 마지막 라운드까지 진행
            {
                int[] result = new int[3];                                      // 라운드 결과
                string answer = "";

                PrintLine("[현재 라운드 : " + nowRound + " / " + maxRound + "]");
                Print("- 정답 입력 : ");
                answer += Console.ReadLine();

                if (answer.Length != 4)                                         // 정답 길이가 4가 아닌 경우(잘못 입력한 경우)
                {
                    PrintLine("[제대로 입력해주세요]");
                    continue;                                                   // 반복문 블록을 재실행
                }
                if (answer == "")                                               // 공백을 입력한 경우
                {
                    PrintLine("[게임을 종료합니다]");
                    break;                                                      // 반복문 블록을 탈출(게임 종료)
                }

                result = AnswerCheck(answer, code);                            // 라운드 결과 확인

                Print("[이번 라운드 결과 : ");                                 // 라운드 결과 출력
                if (result[0] > 0)
                    Print(result[0] + "S ");
                if (result[1] > 0)
                    Print(result[1] + "B ");
                if (result[2] > 0)
                    Print(result[2] + "O");
                PrintLine("]");
                PrintLine();

                if (result[0] == 4)                                             // 스트라이크가 4개라면
                {
                    win = true;                                                 // 게임 승리를 true로 수정하고
                    break;                                                      // 반복문 블록을 탈출한다
                }

                nowRound++;                                                     // 라운드 진행
            }

            // 게임 반복문 블록이 종료한 뒤
            if (win)                                                            // 승리하였다면
            {
                PrintLine("[축하합니다! 승리하였습니다!]");                     // 승리 메시지를 출력한다
            }
            else                                                                // 패배하였다면
            {
                PrintLine("[아쉽지만 패배했습니다...]");                        // 패배 메시지를 출력한다
            }
        }

        // 빈 줄을 출력하는 함수
        static void PrintLine()
        {
            Console.WriteLine("");
        }

        // 매개변수로 받은 문자열을 출력하고 줄바꿈을 하는 함수
        static void PrintLine(string text)
        {
            Console.WriteLine(text);
        }
        
        // 매개변수로 받은 문자열을 출력하고 줄바꿈은 하지 않는 함수
        static void Print(string text)
        {
            Console.Write(text);
        }

        static void Main(string[] args)
        {
            PrintLine("1번 문제");
            int result1 = Bigger(10, 50);
            PrintLine("10과 50중 더 큰 숫자는 " + result1 + "입니다");
            PrintLine();

            PrintLine("2번 문제");
            int result2 = HighValue(new int[] { 1, 0, 5, 3, 2 });
            PrintLine("정수 배열 { 1, 0, 5, 3, 2 } 에서 가장 큰 값은 " + result2 + "입니다");
            PrintLine();

            PrintLine("3번 문제");
            int result3 = GetGCD(12, 18);
            PrintLine("두 정수 12, 18의 최대공약수는 " + result3 + "입니다");
            PrintLine();

            PrintLine("4번 문제");
            int result4 = GetLCM(12, 18);
            PrintLine("두 정수 12, 18의 최소공배수는 " + result4 + "입니다");
            PrintLine();

            PrintLine("5번 문제");
            Print("두 배열 { -1, -2, 3, 4 }, { 5, 8, 11 } 에서 평균값이 더 큰 배열은 ");
            bool result5 = BiggerArray(new int[] { -1, -2, 3, 4 }, new int[] { 5, 8, 11 });
            if (result5)
            {
                PrintLine("{ -1, -2, 3, 4 } 입니다");
            }
            else
            {
                PrintLine("{ 5, 8, 11 } 입니다");
            }
            PrintLine();

            PrintLine("추가 문제");
            BaseBallGame("2468", 9);
        }
    }
}