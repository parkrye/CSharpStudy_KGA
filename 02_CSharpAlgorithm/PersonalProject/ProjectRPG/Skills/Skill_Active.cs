namespace ProjectRPG
{
    internal abstract class Skill_Active : Skill
    {

        public Skill_Active()
        {
            type = SkillType.ACTIVE;
        }

        public abstract override void Active(float param);
    }
}
