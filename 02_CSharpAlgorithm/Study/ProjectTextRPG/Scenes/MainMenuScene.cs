using System.Diagnostics;

namespace ProjectTextRPG
{
    public class MainMenuScene : Scene
    {
        int cursor;

        public MainMenuScene(Game _game) : base(_game)
        {

        }

        public override void Render()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("RRRRRRRRRRRRRR        OOOOOOO            GGGGGGGGGGGEEEEEEEEEEEEEEEEEEELLLLLLLLLL           IIIIIIIIIKKKKKK    KKKKKKKEEEEEEEEEEEEEEEEEEE");
            Console.WriteLine("R:::::::::::::R     OO:::::::OO        GG::::::::::GE:::::::::::::::::EL::::::::L           I:::::::IK::::K    K:::::KE:::::::::::::::::E");
            Console.WriteLine("R:::::RRRRR::::R  OO:::::::::::OO    GG::::::::::::GE:::::::::::::::::EL::::::::L           I:::::::IK::::K    K:::::KE:::::::::::::::::E");
            Console.WriteLine("RR::::R    R::::RO::::::OOO::::::O  G::::GGGGGGG:::GEE:::::EEEEEEEE:::ELL::::::LL           II:::::IIK::::K   K::::::KEE:::::EEEEEEEE:::E");
            Console.WriteLine("  R:::R    R::::RO:::::O   O:::::O G::::G      GGGGG  E::::E      EEEEE  L::::L               I:::I  KK:::K  K:::::KKK  E::::E      EEEEE");
            Console.WriteLine("  R:::R    R::::RO::::O     O::::OG::::G              E::::E             L::::L               I:::I    K::K K:::::K     E::::E           ");
            Console.WriteLine("  R:::RRRRR::::R O::::O     O::::OG::::G              E:::::EEEEEEEEE    L::::L               I:::I    K:::K:::::K      E:::::EEEEEEEEE  ");
            Console.WriteLine("  R::::::::::RR  O::::O     O::::OG::::G   GGGGGGGGG  E:::::::::::::E    L::::L               I:::I    K::::::::K       E:::::::::::::E  ");
            Console.WriteLine("  R:::RRRRR::::R O::::O     O::::OG::::G   G:::::::G  E:::::::::::::E    L::::L               I:::I    K::::::::K       E:::::::::::::E  ");
            Console.WriteLine("  R:::R    R::::RO::::O     O::::OG::::G   GGGGG:::G  E:::::EEEEEEEEE    L::::L               I:::I    K:::K:::::K      E:::::EEEEEEEEE  ");
            Console.WriteLine("  R:::R    R::::RO::::O     O::::OG::::G       G:::G  E::::E             L::::L               I:::I    K::K K:::::K     E::::E           ");
            Console.WriteLine("  R:::R    R::::RO:::::O   O:::::O G::::G      G:::G  E::::E      EEEEE  L::::L        LLLLL  I:::I  KK:::K  K:::::KKK  E::::E      EEEEE");
            Console.WriteLine("RR::::R    R::::RO::::::OOO::::::O  G::::GGGGGGG:::GEE:::::EEEEEEE::::ELL::::::LLLLLLLL::::LII:::::IIK::::K   K::::::KEE:::::EEEEEEE::::E");
            Console.WriteLine("R:::::R    R::::R OO:::::::::::OO    GG::::::::::::GE:::::::::::::::::EL:::::::::::::::::::LI:::::::IK::::K    K:::::KE:::::::::::::::::E");
            Console.WriteLine("R:::::R    R::::R   OO:::::::OO        GG:::::GGG::GE:::::::::::::::::EL:::::::::::::::::::LI:::::::IK::::K    K:::::KE:::::::::::::::::E");
            Console.WriteLine("RRRRRRR    RRRRRR     OOOOOOO            GGGGG   GGGEEEEEEEEEEEEEEEEEEELLLLLLLLLLLLLLLLLLLLLIIIIIIIIIKKKKKK    KKKKKKKEEEEEEEEEEEEEEEEEEE");
            Console.WriteLine();

            if (cursor == 0) Console.ForegroundColor = ConsoleColor.Green;
            else Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("[게임 시작]");

            if (cursor == 1) Console.ForegroundColor = ConsoleColor.Green;
            else Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("[게임 종료]");
        }

        public override void Update()
        {
            ConsoleKey input = Console.ReadKey().Key;

            switch (input)
            {
                case ConsoleKey.UpArrow:
                    cursor--;
                    if(cursor < 0) cursor = 1;
                    break;
                case ConsoleKey.DownArrow:
                    cursor++;
                    if (cursor > 1) cursor = 0;
                    break;
                case ConsoleKey.Enter:
                    switch (cursor)
                    {
                        case 0:
                            game.GameStart();
                            break;
                        case 1:
                            game.GameOver(DeadCause.Debug);
                            break;
                    }
                    break;
                default:
                    Console.Clear();
                    break;
            }
        }
    }
}
