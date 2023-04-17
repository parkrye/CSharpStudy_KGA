namespace HomeWork_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 문제 1.
            Console.Write("정수를 입력해주세요: ");                // 사용자 안내 출력문
            int intValue = int.Parse(Console.ReadLine());          // 사용자 입력 값을 정수형 변수에 저장
            Console.WriteLine("변환값: " + (intValue + 10));       // 저장된 입력값에 10을 더한 값을 따로 저장하지 않고 바로 출력
            Console.WriteLine("");                                 // 가독성을 위한 줄넘김

            // 문제 2.
            Console.Write("첫번째로 연산할 수를 입력해주세요: ");                   // 사용자 안내 출력문
            float valueA = float.Parse(Console.ReadLine());                         // 첫번째 피연산 값을 입력받고 저장
            Console.Write("두번째로 연산할 수를 입력해주세요: ");                   // 사용자 안내 출력문
            float valueB = float.Parse(Console.ReadLine());                         // 두번째 피연산 값을 입력받고 저장
            Console.WriteLine(valueA + " + " + valueB + " = " + (valueA + valueB)); // 더하기 연산 과정과 결과 출력
            Console.WriteLine(valueA + " - " + valueB + " = " + (valueA - valueB)); // 빼애기 연산 과정과 결과 출력
            Console.WriteLine(valueA + " * " + valueB + " = " + (valueA * valueB)); // 곱하기 연산 과정과 결과 출력
            Console.WriteLine(valueA + " / " + valueB + " = " + (valueA / valueB)); // 나누기 연산 과정과 결과 출력
            Console.WriteLine("");                                                  // 가독성을 위한 줄넘김

            // 문제 3.
            Console.Write("세자리 이상의 정수를 입력해주세요: ");              // 사용자 안내 출력문
            int bigValue = int.Parse(Console.ReadLine());                      // 사용자 입력 값을 정수형 변수에 저장
            Console.WriteLine("두번째 자리 숫자: " + (bigValue / 10) % 10);    // 입력된 정수의 뒤에서부터 두번째 숫자를 구하기 위해
                                                                               //   10으로 나누어 10의 자리 숫자를 1의 자리로 내리고
                                                                               //   10으로 나눈 나머지 값을 구해 출력
        }
    }
}