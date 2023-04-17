using System.Security.Cryptography;

namespace HomeWork_4
{
    internal class Program
    {
        // 열거형 자료 RSP
        enum RSP { 가위, 바위, 보 };

        // 문제 1.
        static void RSP1()
        {
            // 임의의 변수로 초기화
            RSP rsp = RSP.가위;
            Console.WriteLine(rsp);

            // 임의의 변수로 수정
            rsp = RSP.바위;
            Console.WriteLine(rsp);

            // 정수로 열거형 자료 변수 저장
            rsp = (RSP)2;
            Console.WriteLine(rsp);
            Console.WriteLine();
        }

        // 문제 2.
        static void RSP2()
        {
            // 임의의 변수로 초기화
            RSP user = RSP.가위;
            RSP computer = RSP.가위;
            bool wrong = true;

            // 이 함수에서 사용할 랜덤 클래스
            Random random = new Random();

            // 입력부. 입력값이 "가위", "바위", "보"가 아니라면 반복
            while (wrong)
            {
                Console.Write("가위, 바위 보 중 하나를 입력해주세요 : ");
                string input = Console.ReadLine();
                switch (input)
                {
                    // 입력값이 "가위", "바위", "보" 중 하나라면 user를 해당하는 값으로 수정
                    case "가위":
                        user = RSP.가위;
                        wrong = false;
                        break;
                    case "바위":
                        user = RSP.바위;
                        wrong = false;
                        break;
                    case "보":
                        user = RSP.보;
                        wrong = false;
                        break;
                    // 위의 세 경우가 아니라면 wrong이 수정되지 않으므로 반복문이 반복
                    default:
                        break;
                }
            }

            // 컴퓨터는 0 이상 3 미만의 정수를 무작위로 출력하여 출력값에 따라 가위, 바위, 보 중 하나의 값을 저장
            switch (random.Next(3))
            {
                default:
                case 0:
                    computer = RSP.가위;
                    break;
                case 1:
                    computer = RSP.바위;
                    break;
                case 2:
                    computer = RSP.보;
                    break;
            }

            // 플레이어와 컴퓨터의 선택을 출력
            Console.WriteLine("플레이어 : " + user);
            Console.WriteLine("컴퓨터 : " + computer);

            // 플레이어의 RSP와 컴퓨터의 RSP가 같다면 비긴다
            if (user == computer)
            {
                Console.WriteLine("비겼습니다");
            }
            else
            {
                // 가위(0), 바위(1), 보(2) 이므로 플레이어가 이기는 경우는 다음과 같다
                if (user == computer + 1 || user + 2 == computer)
                {
                    Console.WriteLine("플레이어가 이겼습니다!");
                }
                // 그 외의 경우에는 플레이어가 패배한다
                else
                {
                    Console.WriteLine("플레이어가 졌습니다...");
                }
            }
            Console.WriteLine();
        }

        // 문제 3.
        // 구조체 Student
        struct Student{
            // 학생 이름, 연령, {영어, 국어, 수학, 과학} 점수 정수 배열
            string name;
            int age;
            int[] scores = new int[4];

            // 점수를 배열로 초기화하는 경우
            public Student(string _name, int _age, int[] _scores)
            {
                name = _name;
                age = _age;
                for(int i = 0; i < 4; i++)
                    scores[i] = _scores[i];
            }

            // 점수를 정수로 초기화하는 경우
            public Student(string _name, int _age, int english, int korean, int math, int science)
            {
                name = _name;
                age = _age;
                scores[0] = english;
                scores[1] = korean;
                scores[2] = math;
                scores[3] = science;
            }

            // 문제 4.
            // 학생의 평균점수를 반환하는 함수
            public float GetAvgScore()
            {
                // 평균점수를 저장할 값
                float avgScore = 0;
                foreach(int score in scores)
                {
                    avgScore += score;
                }
                return avgScore / 4;
            }

            // 학생의 최고점수를 반환하는 함수
            public int GetHighScore()
            {
                // 최고점수를 저장할 값
                int highScore = scores[0];
                foreach (int score in scores)
                {
                    if(score > highScore)
                        highScore = score;
                }
                return highScore;
            }

            // 학생의 최저점수를 반환하는 함수
            public int GetLowScore()
            {
                // 최저점수를 저장할 값
                int lowScore = scores[0];
                foreach (int score in scores)
                {
                    if (lowScore > score)
                        lowScore = score;
                }
                return lowScore;
            }

            // 문제 5.
            // 학생의 요약 정보를 출력하는 함수
            public void Print()
            {
                Console.WriteLine(name + "(" + age + ") 평균점수 : " + GetAvgScore() + "점, 최대점수 : " + GetHighScore() + "점, 최저점수 : " + GetLowScore() + "점 입니다.");
            }
        }

        // 추가 문제.
        // 열거형 비트플래그로 카드 타입 구현
        // 0b_xxxx_yyyy : xxxx = 문양, yyyy = 숫자
        [Flags] enum Card
        {
            // 스페이드, 다이아몬드, 하트, 클로버
            스페이드 = 0b_0001_0000,
            다이아몬드 = 0b_0010_0000,
            하트 = 0b_0100_0000,
            클로버 = 0b_1000_0000,

            // 1 ~ 13
            i = 0b_0000_0001,
            ii = 0b_0000_0010,
            iii = 0b_0000_0011,
            iv = 0b_0000_0100,
            v = 0b_0000_0101,
            vi = 0b_0000_0110,
            vii = 0b_0000_0111,
            viii = 0b_0000_1000,
            ix = 0b_0000_1001,
            x = 0b_0000_1010,
            xi = 0b_0000_1011,
            xii = 0b_0000_1100,
            xiii = 0b_0000_1101
        }

        static void CardGame()
        {
            Random random = new Random();
            Card[] cards = new Card[5];

            bool loop = true;
            while (loop)
            {
                for (int j = 0; j < 5; j++)
                {
                    int cardType = 16;
                    for (int i = 0; i < random.Next(1, 5); i++)
                        cardType *= 2;
                    for (int i = 0; i < j; i++)
                        if (cards[i] == cards[j])
                            j--;
                    cards[j] = (Card)(cardType + random.Next(1, 14));
                }

                Console.Write("당신의 카드는 : | ");
                foreach (Card card in cards)
                {
                    Console.Write(card + " | ");
                }
                Console.WriteLine();

                int rank = 0;

                int high = 0, pair = 0, pair2 = 0, pattern = 0; ;

                // 원페어 : 1
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (i != j)
                            if ((int)cards[i] % 16 == (int)cards[j] % 16)
                            {
                                pair = (int)cards[i] % 16;
                                break;
                            }
                    }
                }
                if (pair > 0)
                {
                    if (rank < 1)
                        rank = 1;

                    if (pair > 0)
                    {
                        // 투페어 : 2
                        for (int i = 0; i < 5; i++)
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                if (i != j)
                                    if ((int)cards[i] % 16 == (int)cards[j] % 16 && pair != (int)cards[j] % 16)
                                    {
                                        pair2 = (int)cards[i] % 16;
                                        break;
                                    }
                            }
                        }
                        if (pair2 > 0)
                            if (rank < 2)
                                rank = 2;

                        // 트리플 : 3
                        // 포카드 : 7
                        int count = 0;
                        for (int i = 0; i < 5; i++)
                        {
                            if ((int)cards[i] % 16 == pair)
                            {
                                count++;
                                break;
                            }
                        }
                        if (count == 3)
                        {
                            if (rank < 3)
                                rank = 3;

                            // 풀하우스 : 6
                            pair2 = 0;
                            for (int i = 0; i < 5; i++)
                            {
                                for (int j = 0; j < 5; j++)
                                {
                                    if (i != j)
                                        if ((int)cards[i] % 16 == (int)cards[j] % 16 && pair != (int)cards[j] % 16)
                                        {
                                            pair2 = (int)cards[i] % 16;
                                            break;
                                        }
                                }
                            }
                            if (pair2 > 0)
                                if (rank < 6)
                                    rank = 6;
                        }
                        if (count == 4)
                        {
                            if (rank < 7)
                                rank = 7;
                        }
                    }
                }
                else
                {
                    // 하이카드 : 0
                    for (int i = 0; i < 5; i++)
                    {
                        if (high < (int)cards[i] % 16)
                            high = (int)cards[i] % 16;
                    }
                    if (rank < 0)
                        rank = 0;
                }

                // 플러쉬 : 5
                int tmpPattern = (int)cards[0] / 16;
                bool same = true;
                for (int i = 1; i < 5; i++)
                {
                    if ((int)cards[i] / 16 != tmpPattern)
                    {
                        same = false;
                        break;
                    }
                }
                if (same)
                {
                    pattern = tmpPattern;
                    if (rank < 5)
                        rank = 5;

                    // 스트레이트 플러시 : 8
                    // 로열 스트레이트 플러시 : 9
                    int total1 = 0;
                    int total2 = 0;
                    for (int i = 0; i < 5; i++)
                    {
                        if ((int)cards[i] % 16 != 1)
                        {
                            total1 += (int)cards[i] % 16;
                            if (high < (int)cards[i] % 16)
                                high = (int)cards[i] % 16;
                        }
                        else
                        {
                            total1 += (int)cards[i] % 16;
                            total2 += 14;
                            if (high < (int)cards[i] % 16)
                                high = 14;
                        }
                    }
                    for (int i = 0; i < 5; i++)
                    {
                        total1 = total1 - (high - i);
                        total2 = total2 - (high - i);
                    }
                    if (total1 == 0)
                        if (rank < 8)
                            rank = 8;
                    if (total2 == 0)
                        if (rank < 9)
                            rank = 9;
                }
                else
                {
                    // 스트레이트 : 4
                    int total1 = 0;
                    int total2 = 0;
                    for (int i = 0; i < 5; i++)
                    {
                        if ((int)cards[i] % 16 != 1)
                        {
                            total1 += (int)cards[i] % 16;
                            if (high < (int)cards[i] % 16)
                                high = (int)cards[i] % 16;
                        }
                        else
                        {
                            total1 += (int)cards[i] % 16;
                            total2 += 14;
                            if (high < (int)cards[i] % 16)
                                high = 14;
                        }
                    }
                    for (int i = 0; i < 5; i++)
                    {
                        total1 = total1 - (high - i);
                        total2 = total2 - (high - i);
                    }
                    if (total1 == 0 && total2 == 0)
                        if (rank < 4)
                            rank = 4;
                }

                // 결과 출력문
                switch (rank)
                {
                    case 0:
                        Console.WriteLine(high + " 하이카드 입니다");
                        break;
                    case 1:
                        Console.WriteLine(pair + " 페어 입니다");
                        break;
                    case 2:
                        Console.WriteLine(pair + ", " + pair2 + " 투페어 입니다");
                        break;
                    case 3:
                        Console.WriteLine(pair + " 트리플 입니다");
                        break;
                    case 4:
                        Console.WriteLine(high + " 스트레이트 입니다");
                        break;
                    case 5:
                        Console.WriteLine(pattern + " 플러시 입니다");
                        break;
                    case 6:
                        Console.WriteLine(pair + "(3),  " + pair2 + "(2) 풀하우스 입니다");
                        break;
                    case 7:
                        Console.WriteLine(pair + " 포카드 입니다");
                        break;
                    case 8:
                        Console.WriteLine(pattern + " 문양 " + high + " 스트레이트 플러시 입니다");
                        break;
                    case 9:
                        Console.WriteLine(pattern + " 문양 " + high + " 로열 스트레이트 플러시 입니다");
                        break;
                }

                Console.WriteLine();
                Console.WriteLine("카드를 추가로 받고 싶다면 아무 글자를 입력해주세요");
                Console.WriteLine("카드를 그만 받고 싶다면 공백을 입력해주세요");
                Console.Write("입력 : ");
                string input = "";
                input += Console.ReadLine();
                if (input == "")
                    loop = false;
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            RSP1();

            RSP2();

            Student student = new Student("박경륜", 25, 13, 29, 37, 47);
            Console.WriteLine("이 학생의 평균점수는 : " + student.GetAvgScore() + "입니다");
            Console.WriteLine("이 학생의 최고점수는 : " + student.GetHighScore() + "입니다");
            Console.WriteLine("이 학생의 최저점수는 : " + student.GetLowScore() + "입니다");
            Console.WriteLine();

            student.Print();
            Console.WriteLine();

            CardGame();
        }
    }
}