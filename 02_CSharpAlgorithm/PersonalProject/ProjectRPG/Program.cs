namespace ProjectRPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            Player player = new Player();

            PC pc11 = new PC(new Class_Figther());
            pc11.ITEMSLOT.AddItem(new Item_MysteriousRing());
            player.EmployCharacter(pc11);
            player.EmployedToParty(0);

            PC pc21 = new PC(new Class_Clown());
            PC pc22 = new PC(new Class_Clown());
            PC pc23 = new PC(new Class_Clown());
            PC pc24 = new PC(new Class_Clown());
            Party enemyParty = new Party();
            pc21.ITEMSLOT.AddItem(new Item_BronzeCoin());
            enemyParty.AddPC(pc21);
            enemyParty.AddPC(pc22);
            enemyParty.AddPC(pc23);
            enemyParty.AddPC(pc24);

            Battle battle = new Battle(player, enemyParty);
            battle.StartBattle();
        }
    }
}