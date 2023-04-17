namespace _01._DataType
{
    internal class Program
    {
        static void DataTypeMain()
        {
            /*
             * 자료형 (Data Type)
             * 데이터가 메모리에 저장되는 형태와 처리되는 방식을 명시하는 역할
             */

            // <논리형>      : 0 = false, 0 != true
            // bool    = (1byte 논리형 자료)        : true, false

            // <정수형>      : 2의 보수 체계의 2진수로 처리
            // byte   = (1byte 부호 없는 정수: 0 ~ 255)
            // int    = (4byte 부호 있는 정수: -2^31 ~ 2^31 - 1)
            // uint   = (4byte 부호 없는 정수: 0 ~ 2^32 - 1)
            // long   = (8byte 부호 있는 정수: -2^63 ~ 2^63 - 1)
            // ulong  = (8byte 부호 없는 정수: 0 ~ 2^64 - 1)
            // ※ 오버플로우: 저장 범위를 초과하는 값이 저장될 경우 최소값이 저장되는 현상

            // <부동소수형>  : 부호(1) + 정수부(15) + 소수부(16)로 비트를 나누어 처리 ( 3.14 => + 314 e-3)
            // float  = (4byte 부동소수      : +-1.5e-45 ~ 3.4e38)
            // double = (8byte 부동소수      : +-5.0e-324 ~ 1.7e308)
            // ※ 정수부 범위를 초과하는 값을 처리할 경우 값을 잘라서 사용하며 오차가 생길 수 있음
            // ※ 위 문제에 이어서 소수 표기를 근사값으료 표현하는 특성 상 연산에 오차가 발생하게 됨

            // <문자형>      : 
            // char   = (2byte 유니코드      : 'a', '1', '한')
            // string = (유니코드 문자열     : "abcd", "123", "한국")


            /*
             * 변수 (Variable)
             * 데이터를 저장하기 위해 프로그램에 의헤 이름을 할당받은 메모리 공간
             */

            // <변수 선언 및 초기화>
            // 자료형 입력 후 빈칸 뒤에 변수명을 작성하여 선언
            // 초기화는 변수 선언 후 처음으로 데이터를 보관하는 작업
            // ※ 예약어, 숫자로 시작하는 변수명, 같은 이름의 변수명은 사용 불가
            int intValue = 10;
            float floatValue = 10.3f;
            double doubleValue = 10.3d;

            // <변수에 데이터 저장 / 변수의 데이터 불러오기>
            // 변수를 좌측값으로 배치 / 변수를 우측값이나 필요한 곳에 배치
            intValue = 5;
            floatValue = 5.3f;
            doubleValue = 5.3d;
            Console.WriteLine(intValue + floatValue + doubleValue);


            /*
             * 상수 (Constant)
             * 프로그램이 실행되는 동안 변경할 수 없는 데이터
             */

            // <산수 선언 및 초기화>
            // 상수는 초기화 없이 사용 불가
            const int MAX = 200;
            Console.WriteLine(MAX);

            /*
             * 형변환 (Casting)
             * 데이터를 선언한 자료형에 맞는 형태로 변환하는 작업
             * 변환 과정에서 보관할 수 없는 데이터는 버려짐
             */

            // <형변환 진행>
            // 변환할 데이터의 앞에 변환할 자료형을 괄호안에 넣어 진행
            int iValue = (int)166.666f;
            Console.WriteLine(iValue);

            // <자동 형변환>
            // 명시적으로 변환이 가능한 경우 자동으로 형변환이 진행됨 (큰 범위 자료형에 작은 범위 자료형 값 입력)
            // 일반적으로 변수의 형변환 같은 경우 자동으로 형변환이 진행되더라도 명시적으로 표기하는 편이 좋음
            float fValue = 3;
            double dValue = fValue;
            Console.WriteLine(fValue);

            // <문자열 변환>
            // 각 자료형의 Parse를 이용하여 문자열에서 다른 자료형으로 변환
            // Parse를 이용하여 변환이 불가능한 경우 예외처리 발생
            int iage = int.Parse("142");
            float fage = float.Parse("142");
            double dage = double.Parse("142");
            Console.WriteLine(iage + ", " + fage + ", " + dage);
            // ※ iValue = int.Parse("abc") => iValue = int.TryParse("abc", out iValue)
            bool success = int.TryParse("abc", out iValue);
            int value = (int)'한';

            /*
             * 배열 (Array)
             * 동일한 자료형의 요소들로 구성된 데이터 집합
             * 인덱스를 통해 각 배열요소(Element)에 접근할 수 있음
             * 배열의 첫 인덱스는 0부터 시작함
             */

            // <배열의 선언 및 초기화>
            // 자료형 뒤에 []를 추가하여 선언하고, new 자료형[크기]로 초기화
            int[] intArray;
            float[] floatArray = new float[100];
            floatArray[19] = 20f;
            string[] stringArray = { "a", "b", "c" };

            // <다차원 배열>
            // []에 추가하는 차원수만큼 ,을 추가하여 선언
            int[,] board = new int[5, 5];
            int[,,] cube = new int[3, 3, 3];

            Program program = new();
            program.Play();
        }

        private int count, turn;

        private void Play()
        {
            count = 0; turn = 1;
            int[,] board = new int[5, 5];
            board[1, 2] = 1; board[2, 3] = 2; board[4, 4] = 3; board[3, 1] = 4;

            string input = "w";
            while(input != "")
            {
                if(count < 2)
                {
                    Draw(board);
                    Console.Write("Input Key(w, a, s, d): ");
                    input = "" + Console.ReadLine();
                    Move(board, input);
                    Console.WriteLine("");
                    turn++;
                }
                else
                {
                    Console.Write("Game Clear in " + turn + " Turns");
                    break;
                }
            }
        }

        private void Move(int[, ] board, string dir)
        {
            switch (dir)
            {
                case "w" or "W":
                    for (int i = 1; i < 5; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            int ball = board[i, j];
                            if (ball == 1 || ball == 2)
                            {
                                for(int k = i - 1; k >= 0; k--)
                                {
                                    if (board[k, j] == 0)
                                    {
                                        board[k, j] = ball;
                                        board[k + 1, j] = 0;
                                    }
                                    else if (board[k, j] == ball + 2)
                                    {
                                        board[k + 1, j] = 0;
                                        count++;
                                        return;
                                    }
                                    else break;
                                }
                            }
                        }
                    }
                    break;
                case "s" or "S":
                    for (int i = 3; i >= 0; i--)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            int ball = board[i, j];
                            if (ball == 1 || ball == 2)
                            {
                                for (int k = i + 1; k < 5; k++)
                                {
                                    if (board[k, j] == 0)
                                    {
                                        board[k, j] = ball;
                                        board[k - 1, j] = 0;
                                    }
                                    else if (board[k, j] == ball + 2)
                                    {
                                        board[k - 1, j] = 0;
                                        count++;
                                        return;
                                    }
                                    else break;
                                }
                            }
                        }
                    }
                    break;
                case "a" or "A":
                    for (int i = 1; i < 5; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            int ball = board[j, i];
                            if (ball == 1 || ball == 2)
                            {
                                for (int k = i - 1; k >= 0; k--)
                                {
                                    if (board[j, k] == 0)
                                    {
                                        board[j, k] = ball;
                                        board[j, k + 1] = 0;
                                    }
                                    else if (board[j, k] == ball + 2)
                                    {
                                        board[j, k + 1] = 0;
                                        count++;
                                        return;
                                    }
                                    else break;
                                }
                            }
                        }
                    }
                    break;
                case "d" or "D":
                    for (int i = 3; i >= 0; i--)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            int ball = board[j, i];
                            if (ball == 1 || ball == 2)
                            {
                                for (int k = i + 1; k < 5; k++)
                                {
                                    if (board[j, k] == 0)
                                    {
                                        board[j, k] = ball;
                                        board[j, k - 1] = 0;
                                    }
                                    else if (board[j, k] == ball + 2)
                                    {
                                        board[j, k - 1] = 0;
                                        count++;
                                        return;
                                    }
                                    else break;
                                }
                            }
                        }
                    }
                    break;
            }
        }

        private void Draw(int[,] board)
        {
            Console.WriteLine("Turn " + turn);
            for (int i = 0; i < 5; i++)
            {
                for(int j = 0; j < 5; j++)
                {
                    if (board[i, j] == 0) Console.Write("□");
                    if (board[i, j] == 1) Console.Write("○");
                    if (board[i, j] == 2) Console.Write("☆");
                    if (board[i, j] == 3) Console.Write("●");
                    if (board[i, j] == 4) Console.Write("★");
                }
                Console.WriteLine("");
            }
        }
    }
}