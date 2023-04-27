using System.ComponentModel;

namespace ProjectRPG
{
    internal class GameCore
    {
        Field field;
        Player player;

        bool isPlaying;
        int cursor;
        bool select;

        public GameCore()
        {
            Console.CursorVisible = false;

            field = new Field();
            player = new Player();
            player.AddItem(new Item_HPPotion1());
            player.AddItem(new Item_HPPotion2());
            player.AddItem(new Item_HPPotion3());
            player.AddItem(new Item_SPPotion1());
            player.AddItem(new Item_SPPotion2());
            player.EmployCharacter(new PC(new Class_Soldier()));
            player.EmployCharacter(new PC(new Class_Soldier()));
            player.EmployCharacter(new PC(new Class_Soldier()));
            player.EmployCharacter(new PC(new Class_Soldier()));
            player.EmployCharacter(new PC(new Class_Soldier()));
            isPlaying = true;
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
                        field.StartMap(player);
                        break;
                    case 1:
                        field.StartMap(player);
                        break;
                    case 2:
                        isPlaying = false;
                        break;
                }
                DrawMain();
                select = false;
                cursor = 0;
            }
        }
    }
}
