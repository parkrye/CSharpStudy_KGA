using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_8
{
    // 문제 4. 슬라임 스킬 상속
    public class SlimeSkill : Skill
    {

        /// <summary>
        /// 스킬 이름 : 분열
        /// 스킬 효과 : 슬라임이 하나 늘어난다
        /// </summary>
        /// <param name="values">없음</param>
        public override void Q(params int[] values)
        {
            Console.WriteLine("분열을 사용했습니다");
            Console.WriteLine("슬라임이 늘어났습니다");
        }


        /// <summary>
        /// 스킬 이름 : 독 발사
        /// 스킬 효과 : 적 1명에게 독을 발사해 피해를 입힌다
        /// </summary>
        /// <param name="values">atk</param>
        public override void W(params int[] values)
        {
            Console.WriteLine("독 발사를 사용했습니다");
            Console.WriteLine(values[0] * 2 + " 데미지!");
        }

        /// <summary>
        /// 스킬 이름 : 재생
        /// 스킬 효과 : 체력을 회복한다
        /// </summary>
        /// <param name="values">회복량</param>
        public override void E(params int[] values)
        {
            Console.WriteLine("재생을 사용했습니다");
            Console.WriteLine("체력을" + values[0] + " 회복했습니다");
        }

        /// <summary>
        /// 스킬 이름 : 거대화
        /// 스킬 효과 : 모든 능력치가 상승한다
        /// </summary>
        /// <param name="values">상승치</param>
        public override void R(params int[] values)
        {
            Console.WriteLine("거대화를 사용했습니다");
            Console.WriteLine("모든 능력치가" + values[0] + " 상승했습니다");
        }
    }
}
