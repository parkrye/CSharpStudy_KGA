using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.Additional
{
    public static class ExtensionMethod
    {
        // <확장 메서드>
        // 클래스의 원래 형식을 수정하지 않고도 기존 형식에 함수를 추가하는 방법
        // 상속을 통하여 만들지 않고 추가적인 함수를 구현 가능

        /// <summary>
        /// 뮨자열의 단어 수 확인 함수
        /// </summary>
        /// <param name="str">문자열</param>
        /// <returns>단어 수</returns>
        public static int WordCount(this string str)
        {
            return str.Split(' ').Length;
        }

        public static void Test()
        {
            string str = "Hello World";
            str.WordCount();
        }
    }
}
