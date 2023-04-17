namespace HomeWork_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 문제 1.
            int n1 = 10;
            int n2 = 20;
            Console.WriteLine(n1 + "과 " + n2 + " 중 더 큰 수는 " + (n1 > n2 ? n1 : n2) + "입니다"); // 삼항연산자를 사용하여 큰 수를 출력하는 문장
            Console.WriteLine("");

            // 문제 2.
            Console.Write("시험 점수를 입력해주세요 : ");
            int score = int.Parse(Console.ReadLine());
            if (score < 60)                                     // 입력한 성적값이 60 미만인 경우
            {
                Console.WriteLine("당신은 F학점입니다");        // F학점임을 출력
            }
            else if (score < 70)                                // 이전 조건이 모두 false이며, 입력한 성적값이 70 미만인 경우
            {
                Console.WriteLine("당신은 D학점입니다");        // D학점임을 출력
            }
            else if (score < 80)                                // 이전 조건이 모두 false이며, 입력한 성적값이 80 미만인 경우
            {
                Console.WriteLine("당신은 C학점입니다");        // C학점임을 출력
            }
            else if (score < 90)                                // 이전 조건이 모두 false이며, 입력한 성적값이 90 미만인 경우
            {
                Console.WriteLine("당신은 B학점입니다");        // B학점임을 출력
            }
            else if (score < 100)                               // 이전 조건이 모두 false이며, 입력한 성적값이 100 미만인 경우
            {
                Console.WriteLine("당신은 A학점입니다");        // A학점임을 출력
            }
            else                                                // 이전 조건이 모두 false인 경우(100점을 초과하는 점수일 경우)
            {
                Console.WriteLine("당신은 F학점입니다");        // 성적 조작이므로 F학점임을 출력
            }
            Console.WriteLine("");

            // 문제 3.
            for (int baseNum = 2; baseNum < 10; baseNum++)                                          // for문을 이용하여 기반 숫자를 2에서부터 9까지 baseNum에 저장하는 문장
            {
                for(int multNum = 1; multNum < 10; multNum++)                                       // for문을 이용하여 곱할 숫자를 2에서부터 9까지 multNum에 저장하는 문장
                {
                    Console.Write( baseNum + " x " + multNum + " = " + baseNum * multNum + " ");    // 구구단 과정과 결과를 출력
                }
                Console.WriteLine("");
            }
            Console.WriteLine("");

            //문제 4.
            Console.Write("교환하실 금액을 입력해주세요 : ");
            int money = int.Parse(Console.ReadLine());
            int[] coins = new int[4];                               // 교환한 동전의 개수를 저장하기 위한 정수 배열
            while(money > 0)                                        // while문을 이용하여 교환할 금액이 0보다 크다면 교환 블록을 계속 반복한다
            {
                if(money >= 500)                                    // money가 500 이상인 경우
                {
                    money -= 500;                                   // 500원으로 교환
                    coins[0]++;
                }
                else if(money >= 100)                               // 이전 조건이 모두 false이며, money가 100 이상인 경우
                {
                    money -= 100;                                   // 100원으로 교환
                    coins[1]++;
                }
                else if (money >= 50)                               // 이전 조건이 모두 false이며, money가 50 이상인 경우
                {
                    money -= 50;                                    // 50원으로 교환
                    coins[2]++;
                }
                else if (money >= 10)                               // 이전 조건이 모두 false이며, money가 10 이상인 경우
                {
                    money -= 10;                                    // 10원으로 교환
                    coins[3]++;
                }
                else                                                // 이전 조건이 모두 false인 경우(money가 10 미만인 경우)
                {
                    Console.WriteLine("다음 금액은 교환할 수 없습니다 : " + money + "원");
                    break;                                          // 교환이 불가능하므로 while문을 탈출
                }
            }

            for(int i = 0; i < 4; i++)                                      // for문을 이용하여 교환 결과를 안내하는 문장
            {
                switch (i)                                                  // switch문을 이용하여 i번째 동전의 개수를 확인하는 문장
                {
                    case 0:                                                 // 현재 i가 0이라면 다음 블록에 진입
                        if (coins[i] > 0)                                   // i번째 동전의 개수가 0을 초과한다면
                        {
                            Console.Write("500원 : " + coins[i] + "개, ");  // 동전의 종류와 개수를 출력
                        }
                        break;                                              // 블록을 마치면 switch문을 탈출
                    case 1:                                                 // 현재 i가 1이라면 다음 블록에 진입
                        if (coins[i] > 0)                                   // i번째 동전의 개수가 0을 초과한다면
                        {
                            Console.Write("100원 : " + coins[i] + "개, ");  // 동전의 종류와 개수를 출력
                        }
                        break;                                              // 블록을 마치면 switch문을 탈출
                    case 2:                                                 // 현재 i가 2이라면 다음 블록에 진입
                        if (coins[i] > 0)                                   // i번째 동전의 개수가 0을 초과한다면
                        {
                            Console.Write("50원 : " + coins[i] + "개, ");   // 동전의 종류와 개수를 출력
                        }
                        break;                                              // 블록을 마치면 switch문을 탈출
                    case 3:                                                 // 현재 i가 3이라면 다음 블록에 진입
                        if (coins[i] > 0)                                   // i번째 동전의 개수가 0을 초과한다면
                        {
                            Console.Write("10원 : " + coins[i] + "개");     // 동전의 종류와 개수를 출력
                        }
                        break;                                              // 블록을 마치면 switch문을 탈출
                }
            }
            if (money > 0)                                                  // 잔여금이 있다면
            {
                Console.WriteLine("교환하지 못한 금액 : " + money + "원");  // 잔여금을 출력
            }
            Console.WriteLine("");
            Console.WriteLine("");

            // 문제 4-1.
            for (int i = 0; i < 5; i++)              // for문을 이용하여 줄 번호를 i에 저장
            {
                for (int j = 0; j < 5; j++)         // for문을 이용하여 칸 번호를 j에 저장
                {
                    if (j <= i)                     // 현재 칸 위치가 줄 위치 값 이하의 위치인 경우(n번째 줄이라면 n번째 칸까지)
                    {
                        Console.Write("*");         // *을 출력
                    }
                    else                            // 아니라면
                    {
                        Console.Write(" ");         // 공백(스페이스)을 출력
                    }
                }
                Console.WriteLine("");
            }
            Console.WriteLine("");

            // 문제 4-21.
            for (int i = 0; i < 5; i++)              // for문을 이용하여 줄 번호를 i에 저장
            {
                for (int j = 0; j < 5; j++)         // for문을 이용하여 칸 번호를 j에 저장
                {
                    if (j <= 4 - i)                 // 현재 칸 위치가 현재 줄 위치에 반비례한 값 이하의 위치인 경우(n번째 줄이라면 4 - n번째 칸까지)
                    {
                        Console.Write("*");         // *을 출력
                    }
                    else                            // 아니라면
                    {
                        Console.Write(" ");         // 공백(스페이스)을 출력
                    }
                }
                Console.WriteLine("");
            }
            Console.WriteLine("");

            // 문제 4-3.
            for (int i = 0; i < 5; i++)              // for문을 이용하여 줄 번호를 i에 저장
            {
                for (int j = 0; j < 5; j++)         // for문을 이용하여 칸 번호를 j에 저장
                {
                    if (j >= 4 - i)                 // 4-2와 반대로 현재 칸 위치가 현재 줄 위치에 반비례한 값 이상의 위치인 경우(n번째 줄이라면 4 - n번째 칸부터)
                    {
                        Console.Write("*");         // *을 출력
                    }
                    else                            // 아니라면
                    {
                        Console.Write(" ");         // 공백(스페이스)을 출력
                    }
                }
                Console.WriteLine("");
            }
            Console.WriteLine("");

            // ※숫자 야구 문제
            string code = "0329";                                               // 정답 숫자
            int life = 9;                                                       // 잔여 생명
            bool win = false;                                                   // 게임 결과
            Console.WriteLine("※☆★숫자 야구 게임★☆※");
            Console.WriteLine("[네 자리 숫자를 입력하여 정답을 맞춰보세요]");
            Console.WriteLine("[엔터만 입력할 경우 게임을 종료합니다]");
            while (life > 0)                                                    // 생명이 남아있는 한 반복
            {
                int s = 0;                                                      // 스트라이크 개수
                int b = 0;                                                      // 볼 개수
                int o = 0;                                                      // 아웃 개수
                string answer = "";

                Console.WriteLine("[남은 기회 : " + life + "]");
                Console.Write("정답 입력 : ");
                answer += Console.ReadLine();

                if (answer.Length != 4)                                         // 정답 길이가 4가 아닌 경우(잘못 입력한 경우)
                    continue;                                                   // 반복문 블록을 재실행
                if (answer == "")                                               // 공백을 입력한 경우
                    break;                                                      // 반복문 블록을 탈출(게임 종료)

                for (int i = 0; i < 4; i++)                                     // 입력한 정답을 각 글자마다 확인
                {
                    bool notOut = false;                                        // 이번 글자의 아웃 여부
                    for(int j = 0; j < 4; j++)                                  // 정답 코드를 각 글자마다 확인
                    {
                        if (answer[i] == code[j])                               // 입력 글자가 정답 글자와 일치한다면
                        {
                            notOut = true;                                      // 이 글자는 아웃이 아니다
                            if (i == j)                                         // 만약 일치한 위치가 같다면
                            {
                                s++;                                            // 스트라이크를 추가한다
                            }
                            else                                                // 일치한 위치가 다르다면
                            {
                                b++;                                            // 볼을 추가한다
                            }
                        }
                    }
                    if (!notOut)                                                // 만약 글자가 일치한 경우가 없었다면
                    {
                        o++;                                                    // 아웃을 추가한다
                    }
                }

                Console.Write("- 이번 라운드 결과 : ");                        // 라운드 결과 출력
                if (s > 0)
                    Console.Write(s + "S ");
                if (b > 0)
                    Console.Write(b + "B ");
                if (o > 0)
                    Console.Write(o + "O");
                Console.WriteLine("");

                if(s == 4)                                                      // 스트라이크가 4개라면
                {
                    win = true;                                                 // 게임 승리를 true로 수정하고
                    break;                                                      // 반복문 블록을 탈출한다
                }

                life--;                                                         // 라운드가 끝이 나면 생명을 1 감소시킨다
            }

                                                                                // 게임 반복문 블록이 종료한 뒤
            if (win)                                                            // 승리하였다면
            {
                Console.WriteLine("[축하합니다! 승리하였습니다!]");             // 승리 메시지를 출력한다
            }
            else                                                                // 패배하였다면
            {
                Console.WriteLine("[아쉽지만 패배했습니다...]");                // 패배 메시지를 출력한다
            }
        }
    }
}