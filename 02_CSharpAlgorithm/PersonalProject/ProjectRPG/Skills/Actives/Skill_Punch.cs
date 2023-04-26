﻿namespace ProjectRPG
{
    /// <summary>
    /// 액티브 스킬을 상속한 상세 스킬 클래스
    /// </summary>
    internal class Skill_Punch : Skill_Active, IAttackable
    {
        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="_level">스킬 레벨. 기본 1</param>
        /// <param name="_exp">스킬 경험치. 기본 0</param>
        public Skill_Punch(int _level = 1, int _exp = 0) : base()
        {
            name = "(A)주먹질";
            level = _level;
            exp = _exp;
            value = 1;
            cost = 0;
        }

        public override bool Active(int[,] param1, params int[] param2)
        {
            if (other != null)
            {
                return Attack(other, param1[1,2]);
            }
            return false;
        }

        public bool Attack(IHitable hitable, params int[] param)
        {
            if(hitable.Hit(param[0] * value * level))
            {
                GetEXP(1);
                return true;
            }
            return false;
        }
    }
}
