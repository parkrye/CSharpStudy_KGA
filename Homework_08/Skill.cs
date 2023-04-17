using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_8
{
    // 문제 4. 추상 스킬 클래스
    public abstract class Skill
    {
        // 각 스킬은 가변 길이 정수 배열 values을 매개변수로 받는다

        /// <summary>
        /// 스킬 이름
        /// 스킬 설명
        /// </summary>
        /// <param name="values"></param>
        public abstract void Q(params int[] values);
        public abstract void W(params int[] values);
        public abstract void E(params int[] values);
        public abstract void R(params int[] values);
    }
}
