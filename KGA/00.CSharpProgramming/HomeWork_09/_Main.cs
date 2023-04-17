namespace Homework_9
{
    internal class _Main
    {
        static void Main(string[] args)
        {
            Pikachu pikachu = new Pikachu(level: 5, name: "내 피카츄");
            Console.WriteLine();
            Console.ReadKey();

            new Battle(pikachu, new Charmander(level: 5)).StartBattle();
        }
    }
}