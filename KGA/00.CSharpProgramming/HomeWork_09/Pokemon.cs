using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Homework_9
{
    /// <summary>
    /// 포켓몬에 대한 추상 클래스
    /// </summary>
    public abstract class Pokemon
    {
        protected int id;                          // 도감 넘버
        protected Elemental elemental;             // 타입

        protected int level;                       // 레벨
        protected int exp;                         // 경험치
        protected string name;                     // 별명
        protected int hp_Max;                      // 최대 체력
        protected int hp_Now;                      // 현재 체력
        protected int[] status = new int[5];       // 물리 공격력, 물리 방어력, 특수 공격력, 특수 방어력, 스피드
        protected int[] status_inBattle;           // 배틀에서 사용하는 스테이터스
        protected State state;                     // 현재 상태

        protected Skill[] skills = new Skill[4];   // 보유 스킬들
        protected bool isBattle;                   // 전투 중인지 여부
        protected Pokemon other;                   // 상대 포켓몬

        /// <summary>
        /// 기본 생성자.
        /// level, exp, name만 포켓몬 객체 생성 시 할당(기본값 0, 0, "")
        /// name은 각 포켓몬 클래스에서 기본 이름으로 기본값 변경
        /// hp, status, skills는 각 포켓몬 클래스마다 할당
        /// </summary>
        /// <param name="level"></param>
        /// <param name="name"></param>
        public Pokemon(int level = 1, int exp = 0, string name = "")
        {
            this.level = 1;             // 레벨은 포켓몬 객체마다 할당
            this.name = name;               // 별명은 포켓몬 객체마다 할당
            this.exp = exp;                 // 경험치는 포켓몬 객체마다 할당

            state = new None();
            isBattle = false;
            SetDefault();                   // 자식 클래스에서 나머지 데이터 할당
            for (int i = 1; i < level; i++)
                TakeEXP(this.level * 100);
        }

        /// <summary>
        /// elemental, hp, status, skills 할당
        /// </summary>
        abstract protected void SetDefault();

        /// <summary>
        /// 경험치를 얻는 함수
        /// </summary>
        /// <param name="exp">획득 경험치</param>
        public void TakeEXP(int exp)
        {
            Console.WriteLine(name + " 은/는 " + exp + " 의 경험치를 얻었다!");
            if (level < 100)
            {
                this.exp += exp;
                while (this.exp >= level * 100)
                {
                    LevelUP();
                }
            }
        }

        /// <summary>
        /// 레벨을 올리는 함수
        /// </summary>
        protected void LevelUP()
        {
            level++;
            Console.WriteLine(name + " 은/는 " + level + " 레벨이 되었다!");
            exp -= (level - 1) * 100;
            hp_Max += hp_Max / (level - 1);
            hp_Now = hp_Max;
            for (int i = 0; i < 5; i++)
                status[i] += (status[i] / (level - 1)) / 2;
            RememberLevelSkill();
        }

        /// <summary>
        /// 레벨에 맞는 기술을 배우는 함수.
        /// </summary>
        abstract protected void RememberLevelSkill();

        /// <summary>
        /// 배틀에 돌입하는 함수
        /// </summary>
        /// <param name="other">상대 포켓몬</param>
        public void StartBattle(Pokemon other)
        {
            status_inBattle = (int[])status.Clone();
            isBattle = true;
            this.other = other;
        }

        /// <summary>
        /// 배틀을 끝마치는 함수
        /// </summary>
        public void EndBattle()
        {
            isBattle = false;
            other = null ;
        }

        /// <summary>
        /// 기술을 기억하는 함수
        /// </summary>
        /// <param name="skill">기억할 기술</param>
        /// <param name="num">기억할 슬롯</param>
        public void RememberSkill(Skill skill, int num = -1)
        {
            if (num == -1) num = EmptySkillSlot();
            if (num >= 0 && num < 4)
            {
                skills[num] = skill;
                Console.WriteLine(name + " 은/는 " + skills[num].GetSkillName() + " 을/를 기억했다!");
            }
            else
            {
                Console.WriteLine("[Error: 기술 등록 범위를 벗어난 범위를 선택하였습니다]");
            }
        }

        public void RemoveSkill(int num)
        {
            skills[num] = null;
            Console.WriteLine(name + " 은/는 " + skills[num].GetSkillName() + " 을/를 잊었다!");
        }

        /// <summary>
        /// 기술을 사용하는 함수
        /// </summary>
        /// <param name="num">사용할 기술 슬롯</param>
        /// <param name="critical">급소 여부</param>
        public void CommandPokemon(int num, bool critical)
        {
            if (other != null)
            {
                if (skills[num] != null)
                {
                    Console.WriteLine(name + " 은/는 " + skills[num].GetSkillName() + " 을/를 사용했다!");
                    skills[num].UseSkill(this, other, critical);
                }
                else
                {
                    Console.WriteLine("[Error: 기술이 등록되지 않은 기술 번호를 입력하였습니다]");
                }
            }
        }

        /// <summary>
        /// 현재 비어있는 스킬 슬롯을 반환하는 함수
        /// </summary>
        /// <returns>비어있는 스킬 슬롯. 없다면 -1을 반환</returns>
        int EmptySkillSlot()
        {
            for(int i = 0; i < 4; i++)
            {
                if (skills[i] == null)
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// 현재 체력을 조정하는 함수
        /// </summary>
        /// <param name="value">조정값</param>
        public void ChangeHP(int value)
        {
            hp_Now += value;
            if (hp_Now < 0)
            {
                Die();
                EndBattle();
            }
            else if (hp_Now > hp_Max)
            {
                hp_Now = hp_Max;
            }
        }

        /// <summary>
        /// 포켓몬이 사망 시 호출되는 함수
        /// </summary>
        public void Die()
        {
            hp_Now = 0;
        }

        /// <summary>
        /// 능력치를 반환하는 함수
        /// </summary>
        /// <param name="battle">true:배틀중 체력, false:능력치</param>
        /// <returns></returns>
        public int[] GetStatus(bool battle)
        {
            if (battle) return status_inBattle;
            return status;
        }

        /// <summary>
        /// 배틀중 능력치를 수정하는 함수
        /// </summary>
        /// <param name="target_Status">수정할 능력치 번호</param>
        /// <param name="value">수정값</param>
        public void ChangeStatus(int target_Status, int value)
        {
            status_inBattle[target_Status] = value;
        }

        public string GetName()
        {
            return name;
        }

        public bool IsBattle()
        {
            return isBattle;
        }

        public Skill[] GetSkills()
        {
            return skills;
        }

        public Elemental GetElemental()
        {
            return elemental;
        }

        public (int, int) GetHP()
        {
            return (hp_Max, hp_Now);
        }

        public int GetLevel()
        {
            return level;
        }
    }
}
