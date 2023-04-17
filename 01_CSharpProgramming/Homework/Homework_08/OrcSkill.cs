using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_8
{
    // 문제 4. 오크 스킬 상속
    public class OrcSkill : Skill
    {
        /// <summary>
        /// 스킬 이름 : 강타
        /// 스킬 효과 : 적 1명에게 강력한 피해를 입힌다
        /// </summary>
        /// <param name="values">atk</param>
        public override void Q(params int[] values)
        {
            Console.WriteLine("강타를 사용했습니다");
            Console.WriteLine(values[0] * 2 + " 데미지!");
        }

        /// <summary>
        /// 스킬 이름 : 돌진
        /// 스킬 효과 : 적 1명에게 돌진하고 피해를 입힌다
        /// </summary>
        /// <param name="values">atk</param>
        public override void W(params int[] values)
        {
            Console.WriteLine("돌진을 사용했습니다");
            Console.WriteLine(values[0] * 1.5 + " 데미지!");
        }


        /// <summary>
        /// 스킬 이름 : 점프 공격
        /// 스킬 효과 : 적 1명에게 점프 공격을 하고 피해를 입힌다
        /// </summary>
        /// <param name="values">atk</param>
        public override void E(params int[] values)
        {
            Console.WriteLine("점프 공격을 사용했습니다");
            Console.WriteLine(values[0] * 1.5 + " 데미지!");
        }


        /// <summary>
        /// 스킬 이름 : 훨윈드
        /// 스킬 효과 : 훨윈드를 돌며 주변 적에게 데미지를 입힌다
        /// </summary>
        /// <param name="values">atk</param>
        public override void R(params int[] values)
        {
            Console.WriteLine("훨윈드를 사용했습니다");
            Console.WriteLine(values[0] * 3 + " 데미지!");
        }
    }
}
