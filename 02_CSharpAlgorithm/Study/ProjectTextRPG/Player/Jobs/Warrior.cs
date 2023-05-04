namespace ProjectTextRPG
{
    public class Warrior : Job
    {
        public Warrior() 
        {
            addHP = 20;
            addAp = 0;
            addDP = 10;
            skillList = new List<Skill>();
            skillList.Add(new WarriorAttack());
        }
    }
}
