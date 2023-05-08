namespace ProjectTextRPG
{
    public class Warrior : Job
    {
        public Warrior() 
        {
            name = "전사";
            addHP = 10;
            addAp = 1;
            addDP = 1;
            skillList = new List<Skill>();
            skillList.Add(new WarriorAttack());
        }
    }
}
