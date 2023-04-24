namespace ProjectRPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PC pc11 = new PC(new Class_Figther());
            PC pc12 = new PC(new Class_Figther());
            Party party1 = new Party();
            party1.AddPC(pc11);
            party1.AddPC(pc12);

            PC pc21 = new PC(new Class_Rouge());
            PC pc22 = new PC(new Class_Rouge());
            PC pc23 = new PC(new Class_Rouge());
            Party party2 = new Party();
            party2.AddPC(pc21);
            party2.AddPC(pc22);
            party2.AddPC(pc23);

            Battle battle = new Battle(party1, party2);
            battle.StartBattle();
        }
    }
}