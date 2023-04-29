﻿namespace ProjectRPG
{
    /// <summary>
    /// 패시브 스킬을 상속한 상세 스킬 클래스
    /// </summary>
    [Serializable]
    internal class Skill_MagicShield : Skill_Passive
    {
        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="_level">스킬 레벨. 기본 1</param>
        /// <param name="_exp">스킬 경험치. 기본 0</param>
        public Skill_MagicShield(int _level = 1, int _exp = 0) : base()
        {
            name = "(P)마법 방패";
            level = _level;
            exp = _exp;
            value = 0;
            cost = 0;
            rank = 0;
        }

        public override void AddListener(Character character)
        {
            if (character != null)
                character.AddListenerOnDamaged(Active);
        }

        public override bool Cast(int[,] param1, params int[] param2)
        {
            if (param2[0] <= param1[1, 1])
            {
                param1[1, 1] -= param2[0];
                param2[0] = 0;
            }
            return true;
        }

        protected override void RankUp()
        {
            rank++;
            level -= 10;
        }
    }
}