namespace ProjectTextRPG
{
    public abstract class Skill
    {
        public string name;

        public abstract void Active(Monster? monster);
    }
}
