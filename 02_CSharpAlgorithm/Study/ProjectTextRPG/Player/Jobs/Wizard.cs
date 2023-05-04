namespace ProjectTextRPG
{
    public class Wizard : Job
    {
        public Wizard()
        {
            addHP = -10;
            addAp = 50;
            addDP = -10;
            skillList = new List<Skill>();
            skillList.Add(new WizardAttack());
        }
    }
}
