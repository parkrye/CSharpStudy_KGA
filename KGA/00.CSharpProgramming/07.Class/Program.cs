using System.Numerics;

namespace _07.Class
{
    internal class Program
    {
        /*
         * 클래스 (Class)
         * 데이터와 관련 기능을 캡슐화할 수 있는 참조 형식
         * 객체지향 프로그래밍에 객체를 만들기 위한 설계도
         * 클래스는 객체를 만들기 위한 설계도이며, 만들어진 객체는 인스턴스라 함
         * 참조 : 원본을 가리키고 있음 == 원본의 주소를 가지고 있음
         */

        // <클래스 구성>
        // class 클래스명 {클래스내용}
        // 클래스 내용으로는 변수와 함수 등이 포함 가능
        class Student
        {
            public string name;
            public int math;
            public int english;

            public Student(string name, int math, int english)
            {
                this.name = name;
                this.math = math;
                this.english = english;
            }

            public float GetAverage()
            {
                return (math + english) / 2f;
            }
        }

        /*
         * 값형식 참조형식
         * 
         * 값형식:     스택영역에 저장, 정적으로 메모리에 할당
         *             복사할 때 실제값이 복사됨, 블록이 끝날 때 소멸
         *             예) 구조체
         * 참조형식:   힙영역에 저장, 동적으로 메모리에 할당
         *             복사할 때 원본주소가 복사됨, 사용하지 않을때 가비지 컬렉터에 의해 소멸
         *             예) 클래스
         */

        // <값형식과 참조형식의 차이>
        // 값형식: 데이터가 중요, 값이 복사됨
        // 참조형식: 원본이 중요, 주소가 복사됨

        struct ValueType { public int value; }
        class RefType { public int value; }

        // <생성자>
        // 반환형이 없는 클래스이름의 함수를 생성자라 하며 클래스의 인스턴스를 만들 때 호출되는 함수로 사용
        // 생성자를 포함하지 않아도 기본 생성자(매개변수가 없는 생성자)는 자동으로 생성됨
        // 기본 생성자 외 매개변수가 있는 생성자를 포함한 경우 기본 생성자는 자동으로 생성되지 않는다

        static void Swap(int left, int right)
        {
            int tmp = left;
            left = right;
            right = tmp;
        }

        // <박싱, 언박싱>
        // 박싱: 값형식의 데이터를 참조형식으로 변환하는 방법
        // 언박싱: 참조형식의 데이터를 값형식으로 변환하는 방법
        static void Swap(object left, object right)
        {
            // object: 최상위 자료형
            int temp = (int)left;
            left = right;
            right = (object)temp;
        }

        // <ref>
        // C# 7.0 이상 버전에서 지원
        // ref 키워드를 통해 값형식을 원본으로 참조하는 방법 지원
        static void Swap(ref int left, ref int right)
        {
            int tmp = left;
            left = right;
            right = tmp;
        }

        static void Swap(RefType left, RefType right)
        {
            int tmp = left.value;
            left.value = right.value;
            right.value = tmp;
        }

        /*
         * 메모리 구조
         * 
         * 코드   영역: 실핼할 프로그램의 코드가 저장되는 영역. CPU가 코드 영역에 저장된 명령어를 하나씩 처리
         * 데이터 영역: 전역(global), 정적(static) 변수가 저장되는 영역, 프로그램의 시작과 함께 할당, 프로그램 종료시 소멸
         * 스택   영역: 지역(local), 매개(parameter) 변수가 저장되는 영역, 블록의 시작과 함께 할당, 블록 완료시 소멸. 컴파일 당시에 크기가 결정
         * 힙     영역: 인스턴스가 저장되는 영역, 사용하지 않을 때 가비지 컬렉터에 의해 소멸. 런타임 당시에 크기가 결정
         */

        // 정적 (Static)
        // 프로그램의 시작과 함꼐 할당, 프로그램 종료시 소멸하는 단 하나의 요소
        // 프로그램 전역에서 클래스의 이름을 통해 접근 가능
        class StaticClass
        {
            public static int staticInt;
            public int nonStaticInt;

            public static void StaticFunc()
            {
                Console.WriteLine("StaticFunc");
                Console.WriteLine(StaticClass.staticInt);
                // Console.WriteLine(nonStaticInt);  => Error: 정적 함수에서 동적 변수는 사용 불가
            }

            public void NonStaticFunc()
            {
                Console.WriteLine("NonStaticFunc");
                Console.WriteLine(StaticClass.staticInt);
                Console.WriteLine(nonStaticInt);
            }
        }

        static class StaticClass2
        {
            public static int staticInt;
            // public int nonStaticInt; => Error: 정적 클래스에서 동적 변수는 사용 불가

            public static void StaticFunc()
            {
                Console.WriteLine("StaticFunc");
                Console.WriteLine(StaticClass.staticInt);
                // Console.WriteLine(nonStaticInt);  => Error: 정적 함수에서 동적 변수는 사용 불가
            }

            /* => Error: 정적 클래스에서 동적 함수는 사용 불가
            public void NonStaticFunc()
            {
                Console.WriteLine("NonStaticFunc");
                Console.WriteLine(StaticClass.staticInt);
                Console.WriteLine(nonStaticInt);
            }
            */
        }

        static void ClassMain(string[] args)
        {
            Student student = new Student("김감자", 50, 70);
            student.name = "김고구마";
            Console.WriteLine(student.GetAverage());

            ValueType valueType1 = new ValueType() { value = 10 };
            ValueType valueType2 = valueType1;      // 값에 의한 복사
            valueType2.value = 20;
            Console.WriteLine(valueType1.value);    // output: 10

            RefType refType1 = new RefType() { value = 10 };
            RefType refType2 = refType1;            // 원본의 주소가 복사
            refType2.value = 20;
            Console.WriteLine(refType2.value);      // output: 20

            int a = 10, b = 20;
            Swap(a, b);
            Console.WriteLine("{0}, {1}",a, b);

            Swap(ref a, ref b);
            Console.WriteLine("{0}, {1}", a, b);

            RefType aR = new RefType() { value = 10 };
            RefType bR = new RefType() { value = 20 };
            Swap(aR, bR);
            Console.WriteLine("{0}, {1}", aR.value, bR.value);

            StaticClass instance = new StaticClass();
            instance.nonStaticInt = 20;
            instance.NonStaticFunc();
            // instance.staticInt = 20; => Error: 정적 변수는 인스턴스로 사용 불가
            // instance.StaticInFunc(); => Error: 정적 함수는 인스턴스로 사용 불가

            // StaticClass2 instance = new StaticClass2();  => Error: 정적 클래스는 인스턴스로 사용 불가
            StaticClass2.staticInt = 30;
            StaticClass2.StaticFunc();

            StaticClass instance1 = new StaticClass();
            StaticClass instance2 = new StaticClass();
            StaticClass instance3 = new StaticClass();
            instance1.nonStaticInt = 10;
            instance2.nonStaticInt = 20;
            instance3.nonStaticInt = 30;
            StaticClass.staticInt = 10;
        }
    }
}