using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Homework_9
{
    /// <summary>
    /// 기술에 대한 추상 클래스
    /// </summary>
    public abstract class Skill
    {
        protected string skill_Name;            // 기술명
        protected int skill_Count;              // 기술 사용 수
        protected Elemental skill_Elemental;    // 기술 타입

        /// <summary>
        /// 기술명을 반환한다
        /// </summary>
        /// <returns>기술명</returns>
        public string GetSkillName()
        {
            return skill_Name;
        }

        /// <summary>
        /// 기술 사용에 대한 추상 함수
        /// 기술 대상은 자신이 될 수도 있고, 상대가 될 수도 있으므로 각 기술 클래스에서 재정의
        /// </summary>
        /// <param name="target_self">기술을 사용하는 포켓몬</param>
        /// <param name="target_other">상대 포켓몬</param>
        /// <param name="critical">급소 여부</param>
        public abstract void UseSkill(Pokemon target_self, Pokemon target_other, bool critical);
    }

    /// <summary>
    /// 기술 클래스를 상속받은, 공격 기술에 대한 추상 클래스
    /// </summary>
    public abstract class AttackSkill : Skill, IDamageInflictable
    {
        protected int damage_Value;         // 피해량을 계산하는 변수 1
        protected float damage_Modifier;    // 피해량을 계산하는 변수 2
        protected int related_Status;       // 피해량에 관여하는 능력치 번호

        /// <summary>
        /// 공격 기술은 모두 상대를 대상으로 하므로 공격 함수에서 정의
        /// </summary>
        /// <param name="target_self">기술을 사용하는 포켓몬</param>
        /// <param name="target_other">상대 포켓몬</param>
        /// <param name="critical">급소 여부</param>
        public override void UseSkill(Pokemon target_self, Pokemon target_other, bool critical)
        {
            if (skill_Count > 0)
            {
                skill_Count--;
                int damage = CalculateDamage(target_self, target_other, target_self.GetStatus(true)[related_Status], target_other.GetStatus(true)[related_Status + 1], critical);
                InflictDamage(target_other, damage);
            }
        }

        public void InflictDamage(Pokemon target, int damage)
        {
            Console.WriteLine(target.GetName() + " 은/는 " + damage + " 의 피해를 입었다!");
            target.ChangeHP(-damage);
        }

        /// <summary>
        /// 데미지 계산 함수
        /// </summary>
        /// <param name="target_self">기술을 사용하는 포켓몬</param>
        /// <param name="target_other">상대 포켓몬</param>
        /// <param name="attack_Status">피해량에 관여하는 능력치 1</param>
        /// <param name="block_Status">피해량에 관여하는 능력치 2</param>
        /// <returns></returns>
        protected int CalculateDamage(Pokemon target_self, Pokemon target_other, int attack_Status, int block_Status, bool critical)
        {
            damage_Value = attack_Status - block_Status / 2;
            damage_Value = damage_Value < 1 ? 1 : damage_Value;

            // 기술을 사용하는 포켓몬의 타입과 기술의 타입이 일치하면 1.5배
            if (target_self.GetElemental() == skill_Elemental) damage_Modifier *= 1.5f;

            // 기술 타입과 기술에 당하는 포켓몬의 타입 상성에 따라 0배, 0.5배, 1배, 2배
            if((target_other.GetElemental() & Elemental.노말) != Elemental.없음)
            {
                if(skill_Elemental == Elemental.격투)
                    damage_Modifier *= 2f;
                if(skill_Elemental == Elemental.고스트)
                    damage_Modifier *= 0f;
            }
            if ((target_other.GetElemental() & Elemental.불꽃) != Elemental.없음)
            {
                if(skill_Elemental == Elemental.물   ||
                    skill_Elemental == Elemental.땅  ||
                    skill_Elemental == Elemental.바위 )
                    damage_Modifier *= 2f;
                if (skill_Elemental == Elemental.불꽃 ||
                    skill_Elemental == Elemental.풀   ||
                    skill_Elemental == Elemental.얼음 ||
                    skill_Elemental == Elemental.벌레 )
                    damage_Modifier *= 0.5f;
            }
            if ((target_other.GetElemental() & Elemental.물) != Elemental.없음)
            {
                if (skill_Elemental == Elemental.전기 ||
                    skill_Elemental == Elemental.풀    )
                    damage_Modifier *= 2f;
                if (skill_Elemental == Elemental.불꽃 ||
                    skill_Elemental == Elemental.물   ||
                    skill_Elemental == Elemental.얼음 )
                    damage_Modifier *= 0.5f;
            }
            if ((target_other.GetElemental() & Elemental.전기) != Elemental.없음)
            {
                if (skill_Elemental == Elemental.땅   )
                    damage_Modifier *= 2f;
                if (skill_Elemental == Elemental.전기 ||
                    skill_Elemental == Elemental.비행 )
                    damage_Modifier *= 0.5f;
            }
            if ((target_other.GetElemental() & Elemental.풀) != Elemental.없음)
            {
                if (skill_Elemental == Elemental.불꽃 ||
                    skill_Elemental == Elemental.얼음 ||
                    skill_Elemental == Elemental.독   ||
                    skill_Elemental == Elemental.비행 ||
                    skill_Elemental == Elemental.벌레  )
                    damage_Modifier *= 2f;
                if (skill_Elemental == Elemental.물   ||
                    skill_Elemental == Elemental.전기 ||
                    skill_Elemental == Elemental.풀   ||
                    skill_Elemental == Elemental.땅    )
                    damage_Modifier *= 0.5f;
            }
            if ((target_other.GetElemental() & Elemental.얼음) != Elemental.없음)
            {
                if (skill_Elemental == Elemental.불꽃 ||
                    skill_Elemental == Elemental.격투 ||
                    skill_Elemental == Elemental.바위 )
                    damage_Modifier *= 2f;
                if (skill_Elemental == Elemental.얼음)
                    damage_Modifier *= 0.5f;
            }
            if ((target_other.GetElemental() & Elemental.격투) != Elemental.없음)
            {
                if (skill_Elemental == Elemental.비행 ||
                    skill_Elemental == Elemental.에스퍼)
                    damage_Modifier *= 2f;
                if (skill_Elemental == Elemental.벌레 ||
                    skill_Elemental == Elemental.바위 )
                    damage_Modifier *= 0.5f;
            }
            if ((target_other.GetElemental() & Elemental.독) != Elemental.없음)
            {
                if (skill_Elemental == Elemental.땅   ||
                    skill_Elemental == Elemental.에스퍼)
                    damage_Modifier *= 2f;
                if (skill_Elemental == Elemental.풀   ||
                    skill_Elemental == Elemental.격투 ||
                    skill_Elemental == Elemental.독   ||
                    skill_Elemental == Elemental.벌레  )
                    damage_Modifier *= 0.5f;
            }
            if ((target_other.GetElemental() & Elemental.땅) != Elemental.없음)
            {
                if (skill_Elemental == Elemental.물   ||
                    skill_Elemental == Elemental.풀   ||
                    skill_Elemental == Elemental.얼음  )
                    damage_Modifier *= 2f;
                if (skill_Elemental == Elemental.독   ||
                    skill_Elemental == Elemental.바위  )
                    damage_Modifier *= 0.5f;
                if (skill_Elemental == Elemental.전기  )
                    damage_Modifier *= 0f;
            }
            if ((target_other.GetElemental() & Elemental.비행) != Elemental.없음)
            {
                if (skill_Elemental == Elemental.전기   ||
                    skill_Elemental == Elemental.얼음   ||
                    skill_Elemental == Elemental.바위  )
                    damage_Modifier *= 2f;
                if (skill_Elemental == Elemental.풀   ||
                    skill_Elemental == Elemental.격투   ||
                    skill_Elemental == Elemental.벌레  )
                    damage_Modifier *= 0.5f;
                if (skill_Elemental == Elemental.땅  )
                    damage_Modifier *= 0f;
            }
            if ((target_other.GetElemental() & Elemental.에스퍼) != Elemental.없음)
            {
                if (skill_Elemental == Elemental.벌레   ||
                    skill_Elemental == Elemental.고스트  )
                    damage_Modifier *= 2f;
                if (skill_Elemental == Elemental.에스퍼   ||
                    skill_Elemental == Elemental.격투)
                    damage_Modifier *= 0.5f;
            }
            if ((target_other.GetElemental() & Elemental.벌레) != Elemental.없음)
            {
                if (skill_Elemental == Elemental.불꽃 ||
                    skill_Elemental == Elemental.비행 ||
                    skill_Elemental == Elemental.바위)
                    damage_Modifier *= 2f;
                if (skill_Elemental == Elemental.풀   ||
                    skill_Elemental == Elemental.격투 ||
                    skill_Elemental == Elemental.땅)
                    damage_Modifier *= 0.5f;
            }
            if ((target_other.GetElemental() & Elemental.바위) != Elemental.없음)
            {
                if (skill_Elemental == Elemental.물 ||
                    skill_Elemental == Elemental.풀 ||
                    skill_Elemental == Elemental.격투 ||
                    skill_Elemental == Elemental.땅 )
                    damage_Modifier *= 2f;
                if (skill_Elemental == Elemental.노말   ||
                    skill_Elemental == Elemental.불꽃 ||
                    skill_Elemental == Elemental.독 ||
                    skill_Elemental == Elemental.비행)
                    damage_Modifier *= 0.5f;
            }
            if ((target_other.GetElemental() & Elemental.고스트) != Elemental.없음)
            {
                if (skill_Elemental == Elemental.고스트)
                    damage_Modifier *= 2f;

                if (skill_Elemental == Elemental.독 ||
                    skill_Elemental == Elemental.벌레)
                    damage_Modifier *= 0.5f;
                if (skill_Elemental == Elemental.노말 ||
                    skill_Elemental == Elemental.격투)
                    damage_Modifier *= 0f;
            }
            if ((target_other.GetElemental() & Elemental.드래곤) != Elemental.없음)
            {
                if (skill_Elemental == Elemental.얼음 ||
                    skill_Elemental == Elemental.드래곤)
                    damage_Modifier *= 2f;
                if (skill_Elemental == Elemental.불꽃 ||
                    skill_Elemental == Elemental.물 ||
                    skill_Elemental == Elemental.전기 ||
                    skill_Elemental == Elemental.풀)
                    damage_Modifier *= 0.5f;
            }
            // 계산된 피해량을 정수형으로 반환
            if(critical) damage_Value = (int)(damage_Value * damage_Modifier * 2f);
            else damage_Value = (int)(damage_Value * damage_Modifier);
            return damage_Value;
        }
    }

    /// <summary>
    /// 기술 클래스를 상속받은, 변화 기술에 대한 추상 클래스
    /// </summary>
    public abstract class StatusSkill : Skill, IStatusChangable
    {
        protected int status_Target;        // 변화하는 능력치
        protected int status_Modifier;      // 변동값

        public void ChangeStatus(Pokemon target, int change_Value)
        {
            Console.WriteLine(target.GetName() + " 의 " + (Status_Name)status_Target + " 이/가 " + change_Value + " 로/으로 변했다!");
            target.ChangeStatus(status_Target, change_Value);
        }

        /// <summary>
        /// 이 기술은 상대를 대상으로 한다
        /// </summary>
        /// <param name="target_self">기술을 사용하는 포켓몬</param>
        /// <param name="target_other">상대 포켓몬</param>
        /// <param name="user_Status">기술을 사용하는 포켓몬의 능력치</param>
        public override void UseSkill(Pokemon target_self, Pokemon target_other, bool critical)
        {
            if (skill_Count > 0)
            {
                skill_Count--;
                int modify_Value = (target_other.GetStatus(true)[status_Target] * status_Modifier / 10);
                ChangeStatus(target_other, modify_Value);
            }
        }
    }

    /// <summary>
    /// 기술 클래스를 상속받은, 회복 기술에 대한 추상 클래스
    /// </summary>
    public abstract class RecovorySkill : Skill, IHPRecoverable
    {
        protected int recovery_Value;      // 회복값

        public void RecoveryHP(Pokemon target)
        {
            Console.WriteLine(target.GetName() + " 은/는 " + recovery_Value + " 만큼 회복했다!");
            target.ChangeHP(recovery_Value);
        }

        /// <summary>
        /// 이 기술은 상대를 대상으로 한다
        /// </summary>
        /// <param name="target_self">기술을 사용하는 포켓몬</param>
        /// <param name="target_other">상대 포켓몬</param>
        /// <param name="user_Status">기술을 사용하는 포켓몬의 능력치</param>
        public override void UseSkill(Pokemon target_self, Pokemon target_other, bool critical)
        {
            if (skill_Count > 0)
            {
                skill_Count--;
                RecoveryHP(target_self);
            }
        }
    }
}
