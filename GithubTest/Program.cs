namespace GithubTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new();
            Monster monster = new();

            player.NAME = "플레이어";
            player.HP = 10;
            player.AP = 1;
            monster.NAME = "몬스터";
            monster.HP = 100;
            monster.AP = 5;

            player.Attack(monster);
        }
    }
}