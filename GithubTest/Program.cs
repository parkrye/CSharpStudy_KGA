namespace GithubTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new();
            Monster monster = new();

            player.NAME = "플레이어";
            monster.NAME = "몬스터";

            player.Attack(monster);
        }
    }
}