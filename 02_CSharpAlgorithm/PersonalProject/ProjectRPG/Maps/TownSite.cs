namespace ProjectRPG
{
    internal abstract class TownSite
    {
        protected string name;
        protected int cursor;
        protected bool outSite, goSite;

        public string NAME { get { return name; } }

        public abstract void GetIn();
    }
}
