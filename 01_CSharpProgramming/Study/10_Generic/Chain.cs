using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Delegate
{
    public class Chain
    {
        public delegate void DelegateChain();

        public static void Func1() { Console.WriteLine("Func1"); }
        public static void Func2() { Console.WriteLine("Func2"); }
        public static void Func3() { Console.WriteLine("Func3"); }

        public static void Test()
        {
            // <델리게이트 체인>
            // 하나의 델리게이트 변수에 여러 개의 함수를 할당하는 것이 가능
            // +=, -= 연산자를 통해 할당을 추가하고 제거할 수 있음
            // = 연산자를 통해 할당할 경우 이전의 다른 함수들을 할당한 상황이 사라진

            DelegateChain delegateVar;
            delegateVar = Func2;
            delegateVar += Func1;
            delegateVar += Func3;
            delegateVar();
            delegateVar -= Func1;
            delegateVar -= Func1;
            delegateVar();
            delegateVar = Func1;
            delegateVar();

            // <예시>
            // 1. 플레이어 세팅
            // 2. 몬스터 세팅
            // 3. UI 세팅
            // 4. 시간 초기화
            // 위 절차를 델리게이트 체인으로 구현
        }
    }
}
