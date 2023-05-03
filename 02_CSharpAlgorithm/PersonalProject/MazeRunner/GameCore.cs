namespace MazeRunner
{
    internal class GameCore
    {
        MazeGroup mazeGroup;
        bool playing;
        enum Screen { Main, Play, Make }
        Screen screen;
        int cursor;

        public GameCore() 
        {
            if (new FileInfo("maze.dat").Exists)
                mazeGroup = DataManager.LoadFile();
            else
                mazeGroup = new MazeGroup();
            playing = true;
            screen = Screen.Main;
            cursor = 0;
        }

        public void StartGame()
        {
            while (playing)
            {
                ScreenManage();
                CursorManage();
            }
        }
        
        void ScreenManage()
        {
            switch (screen)
            {
                case Screen.Main:
                    MainScreen();
                    break;
                case Screen.Play:
                    PlayScreen();
                    break;
                case Screen.Make:
                    MakeScreen();
                    break;
            }
        }

        void MainScreen()
        {
            Console.Clear();
            Console.WriteLine("1 : 미로 시작");
            Console.WriteLine("2 : 미로 제작");
            Console.WriteLine("3 : 게임 종료");
        }

        void PlayScreen()
        {
            Console.Clear();
            for (int i = 0; i < mazeGroup.Count; i++)
            {
                Console.WriteLine($"{i}번 미로");
            }
            Console.WriteLine("뒤로가기");
        }

        void MakeScreen()
        {
            Console.Clear();
            Maze maze = new Maze();
            maze.MakeMaze();
            mazeGroup.AddMaze(maze);
        }

        void CursorManage()
        {
            switch (screen)
            {
                case Screen.Main:
                    MainCursor();
                    break;
                case Screen.Play:
                    PlayCursor();
                    break;
                case Screen.Make:
                    MakeCursor();
                    break;
            }
        }

        void MainCursor()
        {
            switch (InputManager.GetInput())
            {
                case Key.Left:
                case Key.Up:
                    cursor--;
                    if (cursor < 0)
                        cursor = 2;
                    break;
                case Key.Right:
                case Key.Down:
                    cursor++;
                    if (cursor > 2)
                        cursor = 0;
                    break;
                case Key.Enter:
                case Key.Space:
                    if (cursor == 0)
                        screen = Screen.Play;
                    else if(cursor == 1)
                        screen = Screen.Make;
                    else
                        playing = false;
                    break;
            }
        }

        void PlayCursor()
        {
            switch (InputManager.GetInput())
            {
                case Key.Left:
                case Key.Up:
                    cursor--;
                    if (cursor < 0)
                        cursor = mazeGroup.Count;
                    break;
                case Key.Right:
                case Key.Down:
                    cursor++;
                    if (cursor > mazeGroup.Count)
                        cursor = 0;
                    break;
                case Key.Enter:
                case Key.Space:
                    if (cursor == mazeGroup.Count)
                    {
                        screen = Screen.Main;
                        cursor = 0;
                    }
                    else// 미로 플레이 추가
                        mazeGroup[cursor].PrintMaze();
                    break;
            }
        }

        void MakeCursor()
        {
            switch (InputManager.GetInput())
            {
                default:
                    screen = Screen.Main;
                    cursor = 1;
                    break;
            }
        }
    }
}
