namespace _02_Operator
{
    internal class Program
    {
        static void OperatorMain()
        {
            bool bValue;
            int iValue;
            float fValue;

            /*
             * 연산자 (Operator)
             * 프로그래밍에서 지원되는 일반적인 수학 연산과 유사한 연산자들
             */

            /*
             * 산술 연산자
             */

            // <이진 연산자>
            iValue = 1 + 2;     // 더하기 연산
            iValue = 3 - 1;     // 빼기 연산
            iValue = 4 * 2;     // 곱하기 연산
            iValue = 5 / 3;     // 나누기 연산
            fValue = 5 / 3;     // ㄴ 정수 나누기 결과를 저장하므로 소수점 버림
            fValue = 5f / 3f;   // ㄴ 부동소수 나누기 결과를 저장하므로 소수점 저장
            iValue = 13 % 3;    // 나머지 연산

            // <단항 연산자>
            iValue = +iValue;   // 양수 단항연산자: 값을 그대로 반환 (의미 없음)
            iValue = -iValue;   // 음수 반항연산자: 값을 음수로 반환

            // <전위 연산자>: 연산을 하고 값을 반환
            ++iValue;           // 전위증가연산자: 값을 1 증가
            --iValue;           // 전위감소연산자: 값을 1 감소
            // <후위 연산자>: 값을 반환한 후에 연산
            iValue++;           // 후위증가연산자: 값을 1 증가
            iValue--;           // 후위감소연산자: 값을 1 감소

            // <대입(할당) 연산자>
            iValue = 10;        // 우변 값을 좌변 변수에 대입

            // <복합 대입 연산자>
            // 이진 연산자(op)의 경우, x op= y 는 x = x op y와 동일
            // (iValue += 10) 는 (iValue = iValue + 10)과 같다

            // <비교 연산자>
            // 좌변의 변수와 우변의 변수의 값을 비교하여 논리형 변수를 반환한다
            bValue = 3 > 1;     // 피연산자가 더 클 경우 true 반환
            bValue = 3 < 1;     // 피연산자가 더 작을 경우 true 반환
            bValue = 3 >= 1;    // 피연산자가 더 크거나 같을 경우 true 반환
            bValue = 3 <= 1;    // 피연산자가 더 작거나 같을 경우 true 반환
            bValue = 3 == 1;    // 두 피연산자가 같을 경우 true 반환
            bValue = 3 != 1;    // 두 피연산자가 다를 경우 true 반환

            // <논리 연산자>
            bValue = !false;        // Not 연산자: 피연산자의 논리 부정을 반환
            bValue = true && false; // And 연산자: 두 피연산자가 둘 다 true일 때 true 반환
            bValue = true || false; // Or 연산자: 두 피연산자 중 하나라도 true일 때 true 반환
            bValue = true ^ false;  // Xrr 연산자: 두 피연산자이 값이 다를 때 true 반환
            // ※빠른 연산을 위해 (a && b)인 경우 a가 false라면 b는 접근하지 않고 바로 false를 반환함

            /*
             * <비트 연산자>
             * RayCast에서 통과, 충돌 판정을 할 때 사용됨
             */

            // <단항 연산자>
            iValue = ~0x3E;         // 비트 보수: 데이터를 비트 단위로 보수 연산
                                    // = 피연산자에서 0을 1로, 1을 0으로 한 값 반환

            // <이진 연산자>
            iValue = 0x11 & 0x83;  // And: 데이터를 비트 단위로 And 연산한 값 반환
            iValue = 0x11 | 0x83;  // Or: 데이터를 비트 단위로 OR 연산한 값 반환
            iValue = 0x11 ^ 0x83;  // Xor: 데이터를 비트 단위로 Xor 연산한 값 반환

            // <비트 시프트 연산자>
            iValue = 0x20 << 2;    // 왼쪽 피연산자를 오른쪽 피연산자만큼 왼쪽 이동
            iValue = 0x20 >> 2;    // 왼쪽 피연산자를 오른쪽 피연산자만큼 오른쪽 이동
        }
    }
}