namespace UserDefinedType
{
    internal class Program
    {
        /*
         * 열거형 (Enum)
         * 기본 정수 형식의 명명된 상수 집합에 의해 정의되는 값 형식
         * 열거형 맴버의 이름으로 관리되어 코드의 가독성에 도움이 됨
         */

        // <열거형 기본사용>
        // enum 열거형이름 { 맴버 이름, ... };
        enum Elemental { Fire, Water, Wind, Dirt };
        Elemental userElemental = Elemental.Fire;

        enum Season
        {
            Spring,         // 0    : 따로 값을 지정하지 않는다면 0부터 시작
            Summer = 20,    // 20   : 직접 정수값 할당 가능
            Fall,           // 21   : 정수값을 할당하지 않을 경우 이전 맴버 +1
            Winter          // 22
        }

        // <열거형 비트플래그>
        // 두가지 이상 혼합한 상태가 존재할 수 있음
        [Flags]
        enum Day
        {
            Mon = 0b_0000_0001,
            Tue = 0b_0000_0010,
            Wed = 0b_0000_0100,
            Thu = 0b_0000_1000,
            Fri = 0b_0001_0000,
            Sat = 0b_0010_0000,
            Sun = 0b_0100_0000,
            Weekend = Sat | Sun
        }

        /*
         * 튜플 (Tuple)
         * 간단한 데이터 구조에서 여러 데이터 요소를 그룹화하는 간결한 구문을 제공
         */
        (int min, int max) GetMinMax(int[] array)
        {
            return (array.Min(), array.Max());
        }

        /*
         * 구조체 (Struct)
         * 데이터와 관련 기능을 캡슐화할 수 있는 값 형식
         * 데이터를 저장하기 위한 단위용도로 사용
         */

        // <구조체 구성>
        // struct 구조체이름 { 구조체내용 }
        // 구조체의 내용은 변수와 함수 포함 가능

        struct Cat
        {
            string name;
            int age;

            public void SetCat()
            {
                name = "나비";
                age = 1;
            }

            public void SetName(string _name)
            {
                name = _name;
            }

            public void SetAge(int _age)
            {
                age = _age;
            }

            public string GetName()
            {
                return name;
            }

            public int GetAge()
            {
                return age;
            }
        }

        // <구조체 초기화 및 기본값>
        // 반환형이 없는 구조체이름의 함수를 초기화라 하며 구조체 변수들의 초기화를 진행하는 역할로 사용
        // 구조체의 초기화는 new 키워드를 통해서 사용
        // 초기화 기능을 포함하지 않아도 기본 초기화(매개변수가 없는 초기화)는 자동으로 생성됨
        // 기본 초기화는 구조체 변수들의 기본 초기화를 진행

        enum Job { Warrior, Mage, Achor }
        struct Player
        {
            public string name;
            public Job job;
            public int hp;
            public int mp;

            // C#  9.0 이전 버전 : 기본 초기화는 자동으로 생성되며 변경할 수 없음
            // C# 10.0 이후 버전 : 기본 초기화를 추가하지 않는 경우 기본 초기화는 자동으로 생성됨
            public Player()
            {
                name = "기본";
            }

            public Player(string _name, Job job)
            {
                name = _name;
                switch (job)
                {
                    case Job.Warrior:
                        hp = 100;
                        mp = 10;
                        break;
                    case Job.Mage:
                        hp = 10;
                        mp = 100;
                        break;
                    case Job.Achor:
                        hp = 50;
                        mp = 50;
                        break;
                    default:
                        hp = 10;
                        mp = 10;
                        break;
                }
            }
        }

        struct StructExpample
        {
            public int value;
            public int GetValue()
            {
                return value;
            }
        }

        class ClassExpample
        {
            public int value;
            public int GetValue()
            {
                return value;
            }
        }

        static void Main(string[] args)
        {
            // <열거형 사용>
            Console.WriteLine(Season.Spring);
            Console.WriteLine((int)Season.Winter);
            Console.WriteLine((Season)0);

            // <열거형 비트플래그 사용>
            Console.WriteLine(Day.Mon | Day.Tue);
            Console.WriteLine(Day.Sat | Day.Sun);

            // <튜플 사용>
            // 이름을 지정하지 않은 경우
            (double, int) t1 = (4.5, 3);
            Console.WriteLine(t1.Item1 + ", " + t1.Item2);

            // 이름을 지정한 경우
            (double a1, int a2) t2 = (4.5, 3);
            Console.WriteLine(t2.a1 + ", " + t2.Item2);

            // <구조체 사용>
            Cat cat1 = new Cat();
            cat1.SetCat();
            cat1.SetName("개");
            Console.WriteLine(cat1.GetName() + ", " + cat1.GetAge());

            Player player1 = new Player("전사", Job.Warrior);

            // 구조체와 클래스
            StructExpample structExpample = new StructExpample();
            structExpample.value = 10;
            StructExpample copyStructExample = new StructExpample();
            copyStructExample = structExpample;

            ClassExpample classExpample = new ClassExpample();
            classExpample.value = 10;
            ClassExpample copyClassExample = new ClassExpample();
            copyClassExample = classExpample;

            Console.WriteLine(copyStructExample.GetValue() + " : " + copyClassExample.GetValue());

            structExpample.value = 20;  // 값 형식인 구조체는 이후 원본의 값이 변경되도 변화 없음
            classExpample.value = 20;   // 참조 형식인 클래스는 원본의 객체를 참조중이기 떄문에 원본의 값이 수정되면 수정된 값을 가져오게 됨

            Console.WriteLine(copyStructExample.GetValue() + " : " + copyClassExample.GetValue());
        }
    }
}