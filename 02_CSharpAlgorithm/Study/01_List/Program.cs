using System.Security.Cryptography.X509Certificates;

namespace _01_List
{
    internal class Program
    {
        /*
         * 배열 (Array)
         * 연속적인 메모리상에 동일한 타입의 요소를 일렬로 저장하는 자료구조
         * 초기화때 정한 크기가 소멸까지 유지됨
         * 배열의 요소는 인덱스를 사용하여 직접적으로 엑세스 가능
         */

        // <배열의 사용>
        static void Array()
        {
            int[] intArray = new int[100];

            // 인덱스를 통한 접근
            intArray[10] = 10;
            int value = intArray[10];
            Console.WriteLine(value);
        }

        // <배열의 시간복잡도>
        // 접근: O(1)
        // 탐색: O(N)

        /// <summary>
        /// 배열에서 특정 데이터의 위치를 반환하는 함수
        /// </summary>
        /// <param name="intArray">탐색하려는 배열</param>
        /// <param name="data">탐색하려는 데이터</param>
        /// <returns>데이터의 위치. 만약 없다면 -1</returns>
        static int Find(int[] intArray, int data)
        {
            for(int i = 0; i < intArray.Length; i++)
            {
                if (intArray[i] == data)
                {
                    return i;
                }
            }
            return -1;
        }

        /*
         * 리스트(동적배열) (Dynamic Array)
         * 런타임 중 크기를 확장할 수 있는 배열 기반의 자료구조
         * 배열 요소의 개수를 특정할 수 없는 경우 사용
         */

        // <리스트의 사용>
        static void List()
        {
            List<string> stringList = new List<string>();

            // 배열 요소 삽입
            stringList.Add("Zero");
            stringList.Add("One");
            stringList.Add("Two");
            stringList.Add("Three");
            stringList.Add("Four");
            stringList.Add("Five");

            Console.WriteLine(stringList.Capacity);

            // 배열 요소 삭제 
            stringList.Remove("one");

            // 배열 요소 접근
            stringList[0] = "ONE";
            string value = stringList[0];
            Console.WriteLine(value);

            // 배열 요소 탐색
            string? findValue = stringList.Find(x => x.Contains("T"));
            Console.WriteLine(findValue);
            int findIndex = stringList.FindIndex(x => x.Contains("T"));
            Console.WriteLine(findIndex);
        }

        static void Main(string[] args)
        {
            Array();
            Console.WriteLine(Find(new int[5] { 0, 3, 2, 4, 1 }, 2));
            List();
        }
    }
}