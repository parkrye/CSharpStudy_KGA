﻿using static _11.Delegate.Program.Delegate;

namespace _11.Delegate
{
    internal class Program
    {
        /*
         * 대리자 (Delegate)
         * 특정 매개 변수 목록 및 반환 형식이 있는 함수에 대한 참조
         * 대리자 인스턴스를 통해 함수를 호출할 수 있음
         */
        internal class Delegate
        {
            // <델리게이트 정의>
            // delegate 반환형 델리게이트이름(매개변수들);
            public delegate float DelegateMethod1(float param1, float param2);
            public delegate void DelegateMethod2(string message);
            public delegate float DelegateMethod3(float param1, float param2);

            // <델리게이트 변수 생성>
            // 선언한 델리게이트의 변수 생성
            public static DelegateMethod1 delegate1;
            public static DelegateMethod2 delegate2;
            public static DelegateMethod3 delegate3;

            public static float Plus(float x, float y) { return x + y; }
            public static float Minus(float x, float y) { return x - y; }
            public static float Multi(float x, float y) { return x * y; }
            public static float Divide(float x, float y) { return x / y; }
            public static void Message(string message) { Console.WriteLine(message); }
        }

        public static void Test()
        {
            // <델리게이트 사용>
            // 반환형과 매개변수가 일치하는 함수를 델리게이트 변수에 할당
            // 델리게이트 변수를 함수 호출 방법과 동일하게 ()를 통해서 호출 가능
            delegate1 = new DelegateMethod1(Plus);      // 델리게이트 인스턴스 생성
            delegate2 = Message;                        // 간략한 문법의 델리게이트 인스턴스 생성

            delegate1(20, 10);                  // Plus(20, 10) // 연결되어 있는 함수 호출 
            delegate2("메세지");                 // Meesage("메세지");
            delegate1.Invoke(20, 10);           // Invoke를 통해서 함수의 호출을 진행
            delegate2.Invoke("메세지");

            delegate1 = Plus;
            delegate1(20, 10);      // 30
            delegate1 = Minus;
            delegate1(20, 10);      // 10
            delegate1 = Multi;
            delegate1(20, 10);      // 200
            delegate1 = Divide;
            delegate1(20, 10);      // 2

            // delegate2 = Plus;        // 매개변수와 반환형이 일치하는 함수만 가능
            // delegate3 = delegate1;   // 델리게이트간의 할당은 같은 형식만 가능
        }

        static void DelegateMain(string[] args)
        {
            Chain.Test();
        }
    }
}