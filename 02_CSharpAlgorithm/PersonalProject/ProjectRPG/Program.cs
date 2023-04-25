namespace ProjectRPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            PC pc11 = new PC(new Class_Figther());
            Party party1 = new Party();
            pc11.ITEMSLOT.AddItem(new Item_MysteriousRing());
            party1.AddPC(pc11);

            PC pc21 = new PC(new Class_Clown());
            Party party2 = new Party();
            pc21.ITEMSLOT.AddItem(new Item_BronzeCoin());
            party2.AddPC(pc21);

            Battle battle = new Battle(party1, party2);
            battle.StartBattle();
        }
    }
}