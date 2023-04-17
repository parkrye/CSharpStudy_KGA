namespace Personal_ProjectD.Skills
{
    public abstract class Skill
    {
        protected string skillName;
        protected StatusType baseStatus;
        protected bool skilled;

        public string GetSkillName()
        {
            return skillName;
        }

        public void Skilled()
        {
            skilled = true;
        }

        public bool GetSkilled()
        {
            return skilled;
        }
    }
}
