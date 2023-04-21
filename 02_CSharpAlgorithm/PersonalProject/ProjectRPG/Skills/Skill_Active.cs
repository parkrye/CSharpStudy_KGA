﻿namespace ProjectRPG
{
    /// <summary>
    /// 액티브 스킬에 대한 클래스
    /// </summary>
    internal abstract class Skill_Active : Skill
    {
        /// <summary>
        /// 생성자
        /// </summary>
        public Skill_Active()
        {
            type = SkillType.ACTIVE;
        }

        /// <summary>
        /// 스킬 사용에 대한 메소드
        /// </summary>
        /// <param name="param">주어지는 변수</param>
        /// <returns>스킬 발동 성공 여부</returns>
        public abstract override bool Active(params float[] param);
    }
}