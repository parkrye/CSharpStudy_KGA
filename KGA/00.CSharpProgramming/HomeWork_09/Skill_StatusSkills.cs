using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_9
{

    /// <summary>
    /// 째려보기
    /// </summary>
    public class Stare : StatusSkill
    {
        public Stare()
        {
            skill_Name = "째려보기"     ;           // 기술 이름
            skill_Count = 30;                       // 30회 사용 가능하다
            skill_Elemental = Elemental.노말;       // 노멀 타입 기술이다
            status_Target = 0;                      // 물리 공격력을 대상으로
            status_Modifier = 8;                    // 0.8로 조정한다.
        }

        /// <summary>
        /// 이 기술은 상대를 대상으로 한다
        /// </summary>
        /// <param name="target_self">기술을 사용하는 포켓몬</param>
        /// <param name="target_other">상대 포켓몬</param>
        /// <param name="user_Status">기술을 사용하는 포켓몬의 능력치</param>
        public override void UseSkill(Pokemon target_self, Pokemon target_other, bool critical)
        {
            base.UseSkill(target_self, target_other, critical);
        }
    }

    /// <summary>
    /// 고속이동
    /// </summary>
    public class NastyPlot : StatusSkill
    {
        public NastyPlot()
        {
            skill_Name = "고속이동";                // 기술 이름
            skill_Count = 30;                       // 30회 사용 가능하다
            skill_Elemental = Elemental.에스퍼;     // 에스퍼 타입 기술이다
            status_Target = 4;                      // 스피드를 대상으로
            status_Modifier = 12;                   // 1.2로 조정한다.
        }

        /// <summary>
        /// 이 기술은 자신을 대상으로 한다
        /// </summary>
        /// <param name="target_self">기술을 사용하는 포켓몬</param>
        /// <param name="target_other">상대 포켓몬</param>
        /// <param name="user_Status">기술을 사용하는 포켓몬의 능력치</param>
        public override void UseSkill(Pokemon target_self, Pokemon target_other, bool critical)
        {
            base.UseSkill(target_self, target_self, critical);
        }

        /// <summary>
        /// HP회복
        /// </summary>
        public class Recover : StatusSkill
        {
            public Recover()
            {
                skill_Name = "HP회복";                  // 기술 이름
                skill_Count = 5;                        // 5회 사용 가능하다
                skill_Elemental = Elemental.노말;       // 노말 타입 기술이다
                status_Target = 4;                      // 스피드를 대상으로
                status_Modifier = 12;                   // 1.2로 조정한다.
            }

            /// <summary>
            /// 이 기술은 자신을 대상으로 한다
            /// </summary>
            /// <param name="target_self">기술을 사용하는 포켓몬</param>
            /// <param name="target_other">상대 포켓몬</param>
            /// <param name="user_Status">기술을 사용하는 포켓몬의 능력치</param>
            public override void UseSkill(Pokemon target_self, Pokemon target_other, bool critical)
            {
                base.UseSkill(target_self, target_self, critical);
            }
        }
    }
}
