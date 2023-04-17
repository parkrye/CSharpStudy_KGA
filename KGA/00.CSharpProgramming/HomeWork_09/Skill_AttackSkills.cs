using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_9
{

    /// <summary>
    /// 몸통박치기
    /// </summary>
    public class Tackle : AttackSkill
    {
        public Tackle()
        {
            skill_Name = "몸통박치기";           // 기술 이름
            skill_Count = 35;                    // 30회 사용 가능하다
            skill_Elemental = Elemental.노말;    // 속성은 노말이다
            related_Status = 0;                  // 물리 공격력 기반으로
            damage_Modifier = 0.4f;              // 0.4의 피해를 입힌다
        }
    }

    /// <summary>
    /// 10만볼트
    /// </summary>
    public class Thunderbolt : AttackSkill
    {
        public Thunderbolt()
        {
            skill_Name = "10만볼트";            // 기술 이름
            skill_Count = 15;                   // 15회 사용 가능하다
            skill_Elemental = Elemental.전기;   // 속성은 전기다
            related_Status = 2;                 // 특수 공격력 기반으로
            damage_Modifier = 0.9f;             // 0.9의 피해를 입힌다
        }
    }

    /// <summary>
    /// 거품
    /// </summary>
    public class Bubble : AttackSkill
    {
        public Bubble()
        {
            skill_Name = "거품";                // 기술 이름
            skill_Count = 30;                   // 30회 사용 가능하다
            skill_Elemental = Elemental.물;     // 속성은 물이다
            related_Status = 2;                 // 특수 공격력 기반으로
            damage_Modifier = 0.4f;             // 0.4의 피해를 입힌다
        }
    }

    /// <summary>
    /// 불꽃세례
    /// </summary>
    public class Ember : AttackSkill
    {
        public Ember()
        {
            skill_Name = "불꽃세례";            // 기술 이름
            skill_Count = 25;                   // 25회 사용 가능하다
            skill_Elemental = Elemental.불꽃;   // 속성은 불꽃이다
            related_Status = 2;                 // 특수 공격력 기반으로
            damage_Modifier = 0.4f;             // 0.4의 피해를 입힌다
        }
    }

    /// <summary>
    /// 잎날가르기
    /// </summary>
    public class RazorLeaf : AttackSkill
    {
        public RazorLeaf()
        {
            skill_Name = "잎날가르기";          // 기술 이름
            skill_Count = 25;                   // 25회 사용 가능하다
            skill_Elemental = Elemental.불꽃;   // 속성은 불꽃이다
            related_Status = 0;                 // 물리 공격력 기반으로
            damage_Modifier = 0.55f;            // 0.55의 피해를 입힌다
        }
    }

    /// <summary>
    /// 돌떨구기
    /// </summary>
    public class RockThrow : AttackSkill
    {
        public RockThrow()
        {
            skill_Name = "돌떨구기";            // 기술 이름
            skill_Count = 15;                   // 15회 사용 가능하다
            skill_Elemental = Elemental.바위;   // 속성은 바위다
            related_Status = 0;                 // 물리 공격력 기반으로
            damage_Modifier = 0.5f;             // 0.5의 피해를 입힌다
        }
    }
}