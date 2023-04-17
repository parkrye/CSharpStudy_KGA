namespace HomeWork_0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");         // 1.콘솔 프로그램을 이용하여 영어 문장을 출력하는 출력문
            Console.WriteLine("안녕하세요");            // 2.한글 문장도 출력이 가능한지 확인하기 위한 출력문
            Console.Write("ReadLine: ");                // 3-1.프로그램이 사용자의 문장 입력을 대기중임을 알려주기 위한 출력문
            Console.ReadLine();                         // 3-2.실질적으로 사용자의 입력
            int intValue = 10;                          // 4.정수형 int 변수를 선언하고 10의 값으로 초기화하는 문장
            Console.Write("ReadLine: ");                // 5-1.프로그램이 사용자의 문장 입력을 대기중임을 알려주기 위한 출력문
            string stringValue = Console.ReadLine();    // 5-2.문자형 string 변수를 선언하고 사용자가 입력한 값으로 초기화하는 문장 
            Console.WriteLine(stringValue);             // 6.5단계에서 저장한 변수를 출력하는 문장
        }
    }
}