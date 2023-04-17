namespace _03.Conditional
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * 조건문 (Conditional)
             * 조건에 따라 실행이 달라지게 할 때 사용하는 문장
             */

            // if 조건문
            // 조건식(논리형 자료)의 값에 따라 실행할 블록을 결정하는 조건문
            if (1 == 1)
            {
                Console.WriteLine("조건식이 ture일 때 출력되는 블록");
            }
            // else if 블록은 선택사항으로, 필요없을 경우 추가하지 않아도 됨 
            // else if 블록은 이전까지 조건식이 모두 false일 때 true라면 진입하는 블록
            else if (1 == 2)
            {
                Console.WriteLine("이전 조건식은 false이고 이번 조건식이 ture일 때 출력되는 블록");
            }
            // else 블록은 선택사항으로, 필요없을 경우 추가하지 않아도 됨 
            // else 블록은 이전까지 조건식이 모두 false일 때 진입하는 블록
            else
            {
                Console.WriteLine("조건식이 모두 false일 때 출력되는 블록");
            }


            /*
             * Switch 조건문
             * 조건값에 따라 실행할 시작지점을 결정하는 조건문
             */

            // <switch 조건문 기본>
            switch (0)
            {
                default:
                    Console.WriteLine("조건식이 다른 조건에 해당하지 않을 때 출력되는 블록");
                    break;
                case 0:     // 조건값이 일치하는 case 블록에 진입
                    Console.WriteLine("조건식이 0일 때 출력되는 블록");
                    break;  // break가 있는 지점에서 switch 블록을 빠져나감
                            // 만약 break가 없다면 다음 case 블록에 진입함
                case 1:
                    Console.WriteLine("조건식이 1일 때 출력되는 블록");
                    break;
            }


            /*
             * 삼항 연산자
             * 간단한 조건문을 빠르게 작성
             */

            // <삼항 연산자 기본>
            // 조건식 ? true일 경우 : false일 경우
            int a = 1, b = 2;
            int bigger = a > b ? a : b;
            Console.WriteLine("bigger : " + bigger);
        }
    }
}