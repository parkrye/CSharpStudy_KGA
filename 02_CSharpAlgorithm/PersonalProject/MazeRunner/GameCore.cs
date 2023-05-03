namespace MazeRunner
{
    /// <summary>
    /// 게임 코어
    /// </summary>
    internal class GameCore
    {
        MazeGroup mazeGroup;    // 미로 그룹
        bool playing;           // 플레이 여부
        enum Screen { Main, Play, Make }
        Screen screen;          // 현재 화면
        int cursor;             // 커서

        /// <summary>
        /// 생성자
        /// </summary>
        public GameCore() 
        {
            Console.CursorVisible = false;          // 커서 비가시화
            if (new FileInfo("maze.dat").Exists)    // 데이터가 있다면
                mazeGroup = DataManager.LoadFile(); // 데이터를 불러오고
            else                                    // 데이터가 없다면
                mazeGroup = new MazeGroup();        // 새로운 그룹을 생성

            playing = true;                         // 플레이 여부
            screen = Screen.Main;                   // 초기 화면
            cursor = 0;                             // 초기 커서
        }

        /// <summary>
        /// 게임 실행 메소드
        /// </summary>
        public void StartGame()
        {
            while (playing)     // 플레이 중이라면 반복
            {
                ScreenManage(); // 화면 출력
                CursorManage(); // 커서 관리
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        
        /// <summary>
        /// 화면 출력
        /// </summary>
        void ScreenManage()
        {
            switch (screen)         // 현재 화면에 따라
            {
                case Screen.Main:
                    Screen_Main();  // 메인 화면 출력
                    break;
                case Screen.Play:
                    Screen_Play();  // 실행 화면 출력
                    break;
                case Screen.Make:
                    Screen_Make();  // 제작 화면 출력
                    break;
            }
        }

        /// <summary>
        /// 메인 화면
        /// </summary>
        void Screen_Main()
        {
            Console.Clear();    // 콘솔을 초기화하고
                                // 현재 커서가 위치한 항목을 녹색으로 표기
            if(cursor == 0)
                Console.ForegroundColor = ConsoleColor.Green;
            else
                Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("[미로 실행]");
            if (cursor == 1)
                Console.ForegroundColor = ConsoleColor.Green;
            else
                Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("[미로 제작]");
            if (cursor == 2)
                Console.ForegroundColor = ConsoleColor.Green;
            else
                Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("[게임 종료]");
        }

        /// <summary>
        /// 실행 화면
        /// </summary>
        void Screen_Play()
        {
            Console.Clear();    // 콘솔을 초기화하고
                                // 미로 그룹의 미로와 뒤로가기를 커서 위치에 따라 녹색으로 표기
            for (int i = 0; i < mazeGroup.Count; i++)
            {
                if (cursor == i)
                    Console.ForegroundColor = ConsoleColor.Green;
                else
                    Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"[{i+1}번 미로]");
            }
            if (cursor == mazeGroup.Count)
                Console.ForegroundColor = ConsoleColor.Green;
            else
                Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("[뒤로가기]");
        }

        /// <summary>
        /// 제작 화면
        /// </summary>
        void Screen_Make()
        {
            Console.Clear();                    // 콘솔을 초기화하고
            Maze maze = new Maze();             // 새 미로를 생성
            Console.CursorVisible = true;       // 미로 제작 중에는 커서가 필요
            maze.MakeMaze();                    // 미로 제작
            Console.CursorVisible = false;      // 미로 제작 후에는 커서가 불필요
            mazeGroup.AddMaze(maze);            // 완성된 미로를 미로 그룹에 추가하고
            DataManager.SaveFile(mazeGroup);    // 데이터를 저장
        }

        /// <summary>
        /// 커서 관리
        /// </summary>
        void CursorManage()
        {
            switch (screen)         // 현재 화면에 따라
            {
                case Screen.Main:
                    Cursor_Main();  // 메인 커서 호출
                    break;
                case Screen.Play:
                    Cursor_Play();  // 실행 커서 호출
                    break;
                case Screen.Make:
                    Cursor_Make();  // 제작 커서 호출
                    break;
            }
        }

        /// <summary>
        /// 메인 커서
        /// </summary>
        void Cursor_Main()
        {
            switch (InputManager.GetInput())
            {
                case Key.Left:      // 커서 위로 이동
                case Key.Up:
                    cursor--;
                    if (cursor < 0)
                        cursor = 2;
                    break;
                case Key.Right:     // 커서 아래로 이동
                case Key.Down:
                    cursor++;
                    if (cursor > 2)
                        cursor = 0;
                    break;
                case Key.Enter:     // 커서 클릭
                case Key.Space:
                    if (cursor == 0)
                        screen = Screen.Play;
                    else if(cursor == 1)
                        screen = Screen.Make;
                    else
                        playing = false;
                    break;
                case Key.Cancel:    // 취소
                    playing = false;
                    break;
            }
        }

        /// <summary>
        /// 실행 커서
        /// </summary>
        void Cursor_Play()
        {
            switch (InputManager.GetInput())
            {
                case Key.Left:      // 커서 위로 이동
                case Key.Up:
                    cursor--;
                    if (cursor < 0)
                        cursor = mazeGroup.Count;
                    break;
                case Key.Right:     // 커서 아래로 이동
                case Key.Down:
                    cursor++;
                    if (cursor > mazeGroup.Count)
                        cursor = 0;
                    break;
                case Key.Enter:     // 커서 클릭
                case Key.Space:
                    if (cursor == mazeGroup.Count)
                    {               // 뒤로가기
                        screen = Screen.Main;
                        cursor = 0;
                    }
                    else            // 해당 미로 실행
                        mazeGroup[cursor].RunMaze();
                    break;
                case Key.Cancel:    // 취소
                    screen = Screen.Main;
                    cursor = 0;
                    break;
            }
        }

        /// <summary>
        /// 제작 커서
        /// </summary>
        void Cursor_Make()
        {
            screen = Screen.Main;
            cursor = 1;
        }
    }
}
