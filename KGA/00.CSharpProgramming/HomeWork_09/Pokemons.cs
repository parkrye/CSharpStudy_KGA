using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_9
{
    /// <summary>
    /// 피카츄
    /// </summary>
    public class Pikachu : Pokemon
    {
        /// <summary>
        /// 피카츄 생성자
        /// </summary>
        /// <param name="level">레벨. 기본값 1</param>
        /// <param name="exp">현재 경험치. 기본값 0</param>
        /// <param name="name">별명. 기본값 피카츄</param>
        public Pikachu(int level = 1, int exp = 0, string name = "피카츄") : base(level, exp, name)
        {
        }

        /// <summary>
        /// 변수들을 초기화하는 함수
        /// </summary>
        protected override void SetDefault()
        {
            id = 0;                             // 피카츄의 도감 넘버는 0
            elemental = Elemental.전기;         // 피카츄의 타입은 전기
            hp_Max = 7;                        // 피카츄의 체력 및 이하 능력치
            hp_Now = hp_Max;
            status[0] = 11;
            status[1] = 8;
            status[2] = 10;
            status[3] = 10;
            status[4] = 18;
            RememberSkill(new Tackle());        // 피카츄의 초기 기술
        }


        /// <summary>
        /// 레벨에 맞는 기술을 배우는 함수
        /// </summary>
        protected override void RememberLevelSkill()
        {
            switch (level)
            {
                case 3:
                    RememberSkill(new Stare());
                    break;
                case 5:
                    RememberSkill(new Thunderbolt());
                    break;
            }
        }
    }

    /// <summary>
    /// 롱스톤
    /// </summary>
    public class Onix : Pokemon
    {
        /// <summary>
        /// 롱스톤 생성자
        /// </summary>
        /// <param name="level">레벨. 기본값 1</param>
        /// <param name="exp">현재 경험치. 기본값 0</param>
        /// <param name="name">별명. 기본값 피카츄</param>
        public Onix(int level = 1, int exp = 0, string name = "롱스톤") : base(level, exp, name)
        {
        }

        /// <summary>
        /// 변수들을 초기화하는 함수
        /// </summary>
        protected override void SetDefault()
        {
            id = 1;                             // 롱스톤의 도감 넘버는 1
            elemental = Elemental.땅;           // 롱스톤의 타입은 땅
            elemental = Elemental.바위;         // 롱스톤의 타입은 바위
            hp_Max = 7;                         // 롱스톤의 체력 및 이하 능력치
            hp_Now = hp_Max;
            status[0] = 9;
            status[1] = 32;
            status[2] = 6;
            status[3] = 9;
            status[4] = 14;
            RememberSkill(new Tackle());        // 롱스톤의 초기 기술
        }


        /// <summary>
        /// 레벨에 맞는 기술을 배우는 함수
        /// </summary>
        protected override void RememberLevelSkill()
        {
            switch (level)
            {
                case 3:
                    RememberSkill(new Stare());
                    break;
                case 5:
                    RememberSkill(new RockThrow());
                    break;
            }
        }
    }

    /// <summary>
    /// 꼬부기
    /// </summary>
    public class Squirtle : Pokemon
    {
        /// <summary>
        /// 꼬부기 생성자
        /// </summary>
        /// <param name="level">레벨. 기본값 1</param>
        /// <param name="exp">현재 경험치. 기본값 0</param>
        /// <param name="name">별명. 기본값 꼬부기</param>
        public Squirtle(int level = 1, int exp = 0, string name = "꼬부기") : base(level, exp, name)
        {
        }

        /// <summary>
        /// 변수들을 초기화하는 함수
        /// </summary>
        protected override void SetDefault()
        {
            id = 2;                             // 꼬부기의 도감 넘버는 2
            elemental = Elemental.물;           // 꼬부기의 타입은 물
            hp_Max = 9;                         // 꼬부기의 체력 및 이하 능력치
            hp_Now = hp_Max;
            status[0] = 10;
            status[1] = 13;
            status[2] = 10;
            status[3] = 11;
            status[4] = 9;
            RememberSkill(new Tackle());        // 꼬부기의 초기 기술
        }


        /// <summary>
        /// 레벨에 맞는 기술을 배우는 함수
        /// </summary>
        protected override void RememberLevelSkill()
        {
            switch (level)
            {
                case 3:
                    RememberSkill(new Stare());
                    break;
                case 5:
                    RememberSkill(new Bubble());
                    break;
            }
        }
    }

    /// <summary>
    /// 파이리
    /// </summary>
    public class Charmander : Pokemon
    {
        /// <summary>
        /// 파이리 생성자
        /// </summary>
        /// <param name="level">레벨. 기본값 1</param>
        /// <param name="exp">현재 경험치. 기본값 0</param>
        /// <param name="name">별명. 기본값 파이리</param>
        public Charmander(int level = 1, int exp = 0, string name = "파이리") : base(level, exp, name)
        {
        }

        /// <summary>
        /// 변수들을 초기화하는 함수
        /// </summary>
        protected override void SetDefault()
        {
            id = 3;                             // 파이리의 도감 넘버는 3
            elemental = Elemental.불꽃;         // 파이리의 타입은 불
            hp_Max = 8;                         // 파이리의 체력 및 이하 능력치
            hp_Now = hp_Max;
            status[0] = 11;
            status[1] = 9;
            status[2] = 12;
            status[3] = 10;
            status[4] = 13;
            RememberSkill(new Tackle());        // 파이리의 초기 기술
        }


        /// <summary>
        /// 레벨에 맞는 기술을 배우는 함수
        /// </summary>
        protected override void RememberLevelSkill()
        {
            switch (level)
            {
                case 3:
                    RememberSkill(new Stare());
                    break;
                case 5:
                    RememberSkill(new Ember());
                    break;
            }
        }
    }

    /// <summary>
    /// 이상해씨
    /// </summary>
    public class Bulbasaur : Pokemon
    {
        /// <summary>
        /// 이상해씨 생성자
        /// </summary>
        /// <param name="level">레벨. 기본값 1</param>
        /// <param name="exp">현재 경험치. 기본값 0</param>
        /// <param name="name">별명. 기본값 이상해씨</param>
        public Bulbasaur(int level = 1, int exp = 0, string name = "이상해씨") : base(level, exp, name)
        {
        }

        /// <summary>
        /// 변수들을 초기화하는 함수
        /// </summary>
        protected override void SetDefault()
        {
            id = 4;                             // 이상해씨의 도감 넘버는 4
            elemental = Elemental.풀;           // 이상해씨의 타입은 불
            hp_Max = 9;                         // 이상해씨의 체력 및 이하 능력치
            hp_Now = hp_Max;
            status[0] = 10;
            status[1] = 10;
            status[2] = 13;
            status[3] = 13;
            status[4] = 9;
            RememberSkill(new Tackle());        // 이상해씨의 초기 기술
        }


        /// <summary>
        /// 레벨에 맞는 기술을 배우는 함수
        /// </summary>
        protected override void RememberLevelSkill()
        {
            switch (level)
            {
                case 3:
                    RememberSkill(new Stare());
                    break;
                case 5:
                    RememberSkill(new RazorLeaf());
                    break;
            }
        }
    }
}
