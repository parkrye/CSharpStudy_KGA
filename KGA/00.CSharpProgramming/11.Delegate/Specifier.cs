using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Delegate
{
    internal class Specifier
    {
        // <대리자의 지정자로서 사용>
        // 델리게이트를 지정자로 사용하여 미완성 상태의 함수를 구성
        // 매개변수로 전달한 델리게이트를 기준으로 함수를 완성하여 호출함
        public delegate int Compare(int left, int right);

        public static void Sort(int[] array, Compare compare)
        {
            for(int i = 0; i < array.Length; i++)
            {
                for(int j = i; j < array.Length; j++)
                {
                    if (compare(array[i], array[j]) > 0)
                    {
                        int temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }

        public static void Test()
        {
            int[] array = { 3, -2, 1, -4, 9, -8, 7, -6, 5 };
            Sort(array, AscendingOrder);
            Sort(array, AscendingOrder);

        }

        // 찾는 조건
        public static bool FindCondition(int arrayElement, int findNumber)
        {
            if (arrayElement == findNumber)
                return true;
            return false;
        }

        // 오름차순 정렬
        public static int AscendingOrder(int left, int right)
        {
            if (left > right)
                return 1;
            else if (left < right)
                return -1;
            return 0;

        }

        // 오름차순 정렬
        public static int DescendingOrder(int left, int right)
        {
            if (left > right)
                return -1;
            else if (left < right)
                return 1;
            return 0;

        }
    }
}
