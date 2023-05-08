namespace ProjectTextRPG
{
    public class Wizard : Job
    {
        public Wizard()
        {
            name = "마법사";
            addHP = -10;
            addAp = 5;
            addDP = -1;
            skillList = new List<Skill>();
            skillList.Add(new WizardAttack());
        }
    }
}
