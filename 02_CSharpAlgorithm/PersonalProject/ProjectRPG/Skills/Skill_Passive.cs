namespace ProjectRPG
{
    internal abstract class Skill_Passive : Skill
    {
        protected bool used;
        public Skill_Passive()
        {
            type = SkillType.PASSIVE;
            used = false;
        }

        public abstract void AddListener(Character character);

        public override void Active(float param)
        {
            if (!used)
            {
                Result(param);
                used = true;
            }
        }

        public abstract float Result(float param);

        public void Restore()
        {
            used = false;
        }
    }
}
