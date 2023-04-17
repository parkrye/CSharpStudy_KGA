namespace _10.Generic
{
    internal class Program
    {
        /*
         * 일반화 (Generic)
         * 클래스 또는 함수가 코드에 의해 선언되고 인스턴스화될 때까지 형식의 사양을 연기하는 디자인
         * 거의 모든 부분이 동일하지만 일부 자료형만이 다른 경우 사용
         */
        public static T[] ArrayCopy<T>(T[] source)
        {
            T[] output = new T[source.GetLength(0)];
            for (int i = 0; i < source.GetLength(0); i++)
                output[i] = source[i];
            return output;
        }

        // <일반화 자료형 제약>
        // 일반화 자료형을 선언할 때 제약조건을 선언하여 일반화가 가능한 자료형을 제한
        class StructClass<T> where T : struct { }
        class ClassClass<T> where T : class { }
        class InterfaceClass<T> where T : IComparable { }

        // <일반화 제약 용도>
        // 일반화 자료형에 제약조건이 있다면 포함가능한 자료형의 기능을 사용할 수 있음
        public class MyBase
        {
            public void Start() { }
        }

        public void Test<T>(T param) where T : MyBase
        {
            param.Start();
        }

        static void Main(string[] args)
        {
            byte[] bArr = { 1, 2, 3 };
            Console.WriteLine(ArrayCopy<byte>(bArr));
            int[] iArr = { 1, 2, 3 };
            Console.WriteLine(ArrayCopy<int>(iArr));
            float[] fArr = { 1f, 2f, 3f };
            Console.WriteLine(ArrayCopy<float>(fArr));
            double[] dArr = { 1d, 2d, 3d };
            Console.WriteLine(ArrayCopy<double>(dArr));
            string[] sArr = { "1", "2", "3" };
            Console.WriteLine(ArrayCopy<string>(sArr));
            char[] cArr = { '1', '2', '3' };
            Console.WriteLine(ArrayCopy<char>(cArr));
        }
    }
}