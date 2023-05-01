using System.ComponentModel;

namespace ProjectRPG
{
    internal class GameCore
    {
        Player player;

        bool isPlaying;
        int cursor;
        bool select;

        public GameCore()
        {
            Console.Title = "Project RPG";
            Console.CursorVisible = false;
            isPlaying = true;

            if (new FileInfo("save.dat").Exists)
                cursor = 1;
            else
                cursor = 0;
            select = false;
        }

        public void GameStart()
        {
            DrawMain();
            while (isPlaying)
            {
                DrawUI();
                MoveCursor();
                ClickCursor();
            }
        }

        void DrawMain()
        {
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < 60; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("=");
                Console.SetCursorPosition(i, 10);
                Console.Write("=");
            }
            for(int i = 1; i < 10; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("||");
                Console.SetCursorPosition(58, i);
                Console.Write("||");
            }
        }

        void DrawUI()
        {
            for(int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(16 * (i + 1) - 6, 12);
                if (cursor == i)
                    Console.ForegroundColor = ConsoleColor.Green;
                else
                    Console.ForegroundColor = ConsoleColor.White;
                switch (i)
                {
                    case 0:
                        Console.Write("[처음부터]");
                        break;
                    case 1:
                        Console.Write("[불러오기]");
                        break;
                    case 2:
                        Console.Write("[종료]");
                        break;
                }
            }
        }

        void MoveCursor()
        {
            switch (InputManager.GetInput())
            {
                default:
                    break;
                case Key.LEFT:
                case Key.UP:
                    cursor--;
                    if (cursor < 0)
                        cursor = 2;
                    break;
                case Key.RIGHT:
                case Key.DOWN:
                    cursor++;
                    if (cursor > 2)
                        cursor = 0;
                    break;
                case Key.ENTER:
                    select = true;
                    break;
                case Key.CANEL:
                    isPlaying = false;
                    break;
            }
        }

        void ClickCursor()
        {
            if (select)
            {
                Console.Clear();
                switch (cursor)
                {
                    case 0:
                        Console.Clear();
                        Console.SetCursorPosition(8, 6);
                        Console.Write("이름을 입력해주세요 : ");
                        player = new Player(Console.ReadLine());
                        if (player.NAME.Length == 0)
                            break;
                        if (player.NAME.Equals("ABBA"))
                        {
                            player.FINDINGS = new bool[4] { true, true, true, true };
                            player.EmployCharacter(new PC(new Class_Soldier()));
                            player.EmployCharacter(new PC(new Class_Soldier()));
                            player.EmployCharacter(new PC(new Class_Soldier()));
                            player.EmployCharacter(new PC(new Class_Soldier()));
                            player.PARTY.PCs[0].STATUS = new int[2, 5] { { 99999,99999,99999,99999,99999 }, { 99999,99999,99999,99999,99999 } };
                            player.PARTY.PCs[1].STATUS = new int[2, 5] { { 99999,99999,99999,99999,99999 }, { 99999,99999,99999,99999,99999 } };
                            player.PARTY.PCs[2].STATUS = new int[2, 5] { { 99999,99999,99999,99999,99999 }, { 99999,99999,99999,99999,99999 } };
                            player.PARTY.PCs[3].STATUS = new int[2, 5] { { 99999,99999,99999,99999,99999 }, { 99999,99999,99999,99999,99999 } };
                        }
                        player.EmployCharacter(new PC(new Class_Soldier()));
                        new Field(player).StartMap();
                        break;
                    case 1:
                        player = new Player(DataManager.LoadFile());
                        new Field(player).StartMap();
                        break;
                    case 2:
                        isPlaying = false;
                        break;
                }
                Console.Clear();
                DrawMain();
                select = false;
                cursor = 0;
            }
        }
    }
}
