using System.Text;

namespace ProjectTextRPG
{
    public class MainMenuScene : Scene
    {
        public MainMenuScene(Game _game) : base(_game)
        {

        }

        public override void Render()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("[1. 게임 시작]");
            sb.AppendLine("[2. 게임 종료]").AppendLine();
            sb.Append("입력 : ");

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(sb.ToString());
        }

        public override void Update()
        {
            string input = Console.ReadLine();
            Console.WriteLine();

            int command;
            if(!int.TryParse(input, out command))
                command = -1;

            switch (command)
            {
                case 1:
                    game.GameStart();
                    break;
                case 2:
                    game.GameOver();
                    break;
                default:
                    Console.WriteLine("[잘못된 입력입니다]");
                    Thread.Sleep(1000);
                    return;
            }
        }
    }
}
