namespace ProjectTextRPG
{
    public class Rogue : Job
    {
        public Rogue()
        {
            name = "도적";
            addHP = 0;
            addAp = 3;
            addDP = 0;
            skillList = new List<Skill>();
            skillList.Add(new RogueAttack());
        }
    }
}
