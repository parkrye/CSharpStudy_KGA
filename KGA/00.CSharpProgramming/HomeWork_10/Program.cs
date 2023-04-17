using static HomeWork_10.Program;

namespace HomeWork_10
{
    internal class Program
    {
        // 문제 1.
        public static T[] ArrayCopy<T>(T[] source)
        {
            T[] copied = new T[source.GetLength(0)];
            for (int i = 0; i < source.GetLength(0); i++)
                copied[i] = source[i];
            return copied;
        }

        // 문제 2.
        public delegate float Delegate(float param1, float param2);
        public static float Plus(float x, float y) { return (x + y); }
        public static float Minus(float x, float y) { return (x - y); }
        public static float Multi(float x, float y) { return (x * y); }
        public static float Divide(float x, float y) { return (x / y); }

        // 문제 3.
        public delegate void DelegateChain();
        public static void PrintMorning() { Console.WriteLine("Good Morning"); }
        public static void PrintNoon() { Console.WriteLine("Good Day"); }
        public static void PrintNight() { Console.WriteLine("Good Night"); }

        // 문제 4.
        public delegate int Sorter(int left, int right);
        public static int AscendingOrder(int left, int right)
        {
            if (left > right)
                return 1;
            return 0;
        }
        public static void SortArray(int[] arr, Sorter sorter)
        {
            int[] result = new int[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i; j < arr.Length; j++)
                {
                    if (sorter.Invoke(arr[i], arr[j]) == 1)
                    {
                        int tmp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = tmp;
                    }
                }
            }
        }

        // 문제 5.
        public delegate bool SuperSorter<T>(T left, T right) where T : IComparable;
        public static bool SuperAscendingOrder<T>(T left, T right) where T : IComparable
        {
            if (left.CompareTo(right) > 0)
                return true;
            return false;
        }
        public static void SuperSortArray<T>(T[] arr, SuperSorter<T> superSorter) where T : IComparable
        {
            int[] result = new int[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i; j < arr.Length; j++)
                {
                    if (superSorter.Invoke(arr[i], arr[j]))
                    {
                        T tmp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = tmp;
                    }
                }
            }
        }


        static void Main(string[] args)
        {
            // 문제 1.
            Console.WriteLine("문제 1.");
            int[] iArr = new int[3] { 1, 2, 3 };
            int[] copiediArr = ArrayCopy(iArr);
            foreach(int i in copiediArr)
                Console.Write(i + ", ");
            Console.WriteLine();
            bool[] bArr = new bool[3] { true, false, true };
            bool[] copiedbArr = ArrayCopy(bArr);
            foreach (bool i in copiedbArr)
                Console.Write(i + ", ");
            Console.WriteLine();
            string[] sArr = new string[3] { "one", "two", "three" };
            string[] copiedsArr = ArrayCopy(sArr);
            foreach (string i in copiedsArr)
                Console.Write(i + ", ");
            Console.WriteLine("\n");

            // 문제 2.
            Console.WriteLine("문제 2.");
            Delegate del;
            del = Plus;
            Console.WriteLine("10 + 20 = " + del.Invoke(10, 20));
            del = Minus;
            Console.WriteLine("10 - 20 = " + del.Invoke(10, 20));
            del = Multi;
            Console.WriteLine("10 * 20 = " + del.Invoke(10, 20));
            del = Divide;
            Console.WriteLine("10 / 20 = " + del.Invoke(10, 20));
            Console.WriteLine();

            // 문제 3.
            Console.WriteLine("문제 3.");
            DelegateChain chain;
            chain = PrintMorning;
            chain += PrintNoon;
            chain += PrintNight;
            chain.Invoke();
            chain -= PrintNoon;
            chain.Invoke();
            Console.WriteLine();

            // 문제 4.
            Console.WriteLine("문제 4.");
            Sorter sorter = AscendingOrder;
            int[] sortTarget = new int[5] { 1, -1, 2, -3, 4 };
            SortArray(sortTarget, sorter);
            foreach (int i in sortTarget)
                Console.Write(i + ", ");
            Console.WriteLine("\n");

            // 문제 5.
            // 아래 풀이처럼 자료형 별로 초기화시키지 않고 하나의 델리게이트 변수를 정식 인수만 수정하면서 사용할 수는 없나요?
            Console.WriteLine("문제 5.");
            SuperSorter<int> superIntergerSorter;
            superIntergerSorter = SuperAscendingOrder;
            int[] iSortTarget = new int[5] { 1, -1, 2, -3, 4 };
            SuperSortArray(iSortTarget, superIntergerSorter);
            foreach (int i in iSortTarget)
                Console.Write(i + ", ");
            Console.WriteLine();
            SuperSorter<string> superStringSorter;
            superStringSorter = SuperAscendingOrder;
            string[] sSortTarget = new string[5] { "banana", "apple", "mango", "chocolate", "pineapple" };
            SuperSortArray(sSortTarget, superStringSorter);
            foreach (string i in sSortTarget)
                Console.Write(i + ", ");
            Console.WriteLine();
            SuperSorter<bool> superBoolSorter;
            superBoolSorter = SuperAscendingOrder;
            bool[] bSortTarget = new bool[5] { true, false, true, false, false };
            SuperSortArray(bSortTarget, superBoolSorter);
            foreach (bool i in bSortTarget)
                Console.Write(i + ", ");
            Console.WriteLine();
        }
    }
}