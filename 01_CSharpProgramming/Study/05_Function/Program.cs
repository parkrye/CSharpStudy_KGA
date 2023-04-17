namespace Function
{
    internal class Program
    {
        /*
           * 함수 (Function or Procedue)
           * 미리 정해진 동작을 수행하는 코드 블록
           * 어떤 처리를 미리 함수로 만들어두면 함수 호출로 재사용 가능
           */

        // <함수 수겅>
        // 반환형 함수 이름(매개변수들) {함수 내용}

        // <반환형> (Return Type)
        // 함수의 결과 데이터의 자료형
        // 함수의 결과 데이터가 없는 경우 반환형은 void
        // 함수 진행 중 return을 만날 경우 그 결과 데이터를 반환하고 함수를 즉시 종료

        // <매개변수> (Parameter)
        // 함수에 추가할 데이터의 자료형과 변수명
        // 같은 함수에서도 매개변수 입력이 다름에 따라 다른 처리가 가능

        static int Add(int x, int y)
        {
            return x + y;
        }

        static void PrintLine(String input)
        {
            Console.WriteLine(input);
        }

        // <함수 호출스택>
        // 함수는 호출(Call)되었을 때 해당 함수 블록으로 제어가 전송되어 전송된 함수가 완료된 후 원위치로 돌아옴
        // 이를 관리하기 위해 호출스택을 활용함
        // 함수가 순환구조로 무한히 호출되어 더이상 스택에 빈공간이 없는 경우 StackOverflow가 발생

        static void Func_1()
        {
            PrintLine("Func_1");
        }

        static void Func_2()
        {
            Func_1();
            PrintLine("Func_2_1");
            Func_1();
            PrintLine("Func_2_2");
        }

        static void Func_3()
        {
            Func_2();
            PrintLine("Func_3_1");
            Func_2();
            PrintLine("Func_3_2");
        }

        // <오버로딩>
        // 같은 이름의 함수를 매개변수를 달리하여 다른 함수로 재정의하는 기술

        static void PrintLine(double input)
        {
            Console.WriteLine(input);
        }

        // <함수 사용>
        // 작성한 함수의 이름에 괄호를 붙이고, 괄호 안에 매개변수의 값을 입력하여 사용

        static void Main(string[] args)
        {
            int n = Add(1, 2);
            PrintLine(n);
            Func_3();
        }
    }
}