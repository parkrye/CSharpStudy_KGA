namespace ProjectRPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            Player player = new Player("플레이어");

            PC pc11 = new PC(new Class_Figther());
            Party party1 = new Party();
            pc11.ITEMSLOT.AddItem(new Item_MysteriousRing());
            party1.AddPC(pc11);

            PC pc21 = new PC(new Class_Clown());
            PC pc22 = new PC(new Class_Clown());
            PC pc23 = new PC(new Class_Clown());
            PC pc24 = new PC(new Class_Clown());
            Party party2 = new Party();
            pc21.ITEMSLOT.AddItem(new Item_BronzeCoin());
            party2.AddPC(pc21);
            party2.AddPC(pc22);
            party2.AddPC(pc23);
            party2.AddPC(pc24);

            Battle battle = new Battle(player, party1, party2);
            battle.StartBattle();
        }
    }
}