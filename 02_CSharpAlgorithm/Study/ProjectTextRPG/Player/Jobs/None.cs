namespace ProjectTextRPG
{
    public class None : Job
    {
        public None() 
        {
            name = "무직";
            addHP = 0;
            addAp = 0;
            addDP = 0;
            skillList = new List<Skill>();
            skillList.Add(new Attack());
            skillList.Add(new Recovery());
        }
    }
}
