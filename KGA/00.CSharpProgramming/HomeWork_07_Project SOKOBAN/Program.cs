using File = System.IO.File;    // 파일 입출력
using System.Timers;            // 타이머

namespace HomeWork_7_Project_SOKOBAN
{
    internal class Program
    {
        // 게임 상태: 게임중, 클리어, 종료, 리셋
        enum GameState { Playing, Clear, Quit, Reset };

        // 키 입력: 없음, 종료, 좌, 우, 상, 하, 리셋, 취소
        enum Key { None, Quit, Left, Right, Up, Down, Reset, Undo };

        // 타일: 없음, 벽, 공, 비어있음, 채워져있음, 시작 위치
        enum Tile { None, Wall, Ball, Empty, Full, Start };

        GameState STATE;                    // 게임 상태
        byte LEVEL;                         // 현재 레벨
        Player PLAYER = new Player();       // 플레이어 구조체
        Stack<(byte, byte)> POST_PLAYER;    // 플레이어 위치 스택
        Tile[,] MAP = new Tile[10, 10];     // 맵 배열
        Stack<Tile[,]> POST_MAP;            // 맵 스택
        int counter;                        // 이동 횟수

        // 데이터 주소
        string DATA_ADDRESS = "C:\\Users\\VR\\Downloads\\Programming\\Project SOKOBAN\\Data.txt";
        string[] DATA;                            // 데이터 본문

        static byte LEFT = 7, UP = 8;             // 게임 화면 위치(좌, 상)
        static System.Timers.Timer TIMER;         // 타이머
        ConsoleColor BANNER = (ConsoleColor)1;    // 상위 배너 색

        /// <summary>
        /// 플레이어 구조체
        /// </summary>
        struct Player
        {
            public byte x, y;   // 플레이어 위치 좌표

            /// <summary>
            /// 플레이어를 특정 좌표로 이동시키는 함수
            /// </summary>
            /// <param name="_x">이동할 x좌표</param>
            /// <param name="_y">이동할 y좌표</param>
            public void Move(byte _x, byte _y)
            {
                x = _x;
                y = _y;
            }

            /// <summary>
            /// 플레이어를 특정 좌표로 이동시키는 함수
            /// </summary>
            /// <param name="pos">이동할 좌표 (x, y) </param>
            public void Move((byte, byte) pos)
            {
                x = pos.Item1;
                y = pos.Item2;
            }

            /// <summary>
            /// 플레이어의 현재 위치를 반환하는 함수
            /// </summary>
            /// <returns>(x, y)</returns>
            public (byte, byte) GetPos()
            {
                return (x, y);
            }
        }

        /// <summary>
        /// 게임 실행 함수
        /// </summary>
        void StartGame()
        {
            do                                      // 일단 1회 실행
            {
                Start();                            // 게임 초기화
                while (STATE == GameState.Playing)  // 게임 상태가 Playing이라면 반복
                {
                    Update();                       // 입력 처리
                    Render();                       // 출력 처리
                    ClearCheck();                   // 종료 여부 확인
                }
                Realese();
            } while (STATE != GameState.Quit);      // 게임 상태가 Quit이 아니라면 반복
        }

        /// <summary>
        /// 게임 초기화 함수
        /// </summary>
        void Start()
        {
            STATE = GameState.Playing;                  // 게임 상태를 게임중으로 변경
            POST_PLAYER = new Stack<(byte, byte)>();    // 플레이어 위치 스택 초기화
            POST_MAP = new Stack<Tile[,]>();            // 맵 스택 초기화
            counter = 0;                                // 이동 횟수 초기화

            ReadDataFile();                             // 데이터 파일 읽기
            Render();                                   // 게임 화면 출력

            Console.Title = "Project SOKOBAN";          // 타이틀 작성
            Console.CursorVisible = false;              // 커서 비가시화

            TIMER = new System.Timers.Timer(1000);      // 1초 간격 타이머 생성
            TIMER.Elapsed += OnTimedEvent;              // 타이머 작동 시 실행할 이벤트
            TIMER.AutoReset = true;                     // 타이머 자동 초기화
            TIMER.Enabled = true;                       // 타이머 활성화
        }

        /// <summary>
        /// 데이터 파일을 읽고 게임에 적용하는 함수
        /// </summary>
        void ReadDataFile()
        {
            // 귀찮아서 절대 경로 사용함. 추후 수정 요망
            DATA = File.ReadAllLines(@DATA_ADDRESS);    // 데이터 파일의 모든 줄을 읽어서 배열 형태로 저장
            // 데이터 파일의 레벨이 1 미만, 맵 길이(최대 레벨-1) 이상인 경우 이상값이므로 경계값으로 레벨을 수정
            LEVEL = byte.Parse(DATA[0]) < 1 ? (byte)1 : byte.Parse(DATA[0]);
            LEVEL = byte.Parse(DATA[0]) < DATA.GetLength(0) ? byte.Parse(DATA[0]) : (byte)(DATA.GetLength(0) - 1);
            string[] data = DATA[LEVEL].Split(" ");     // 현재 레벨의 맵을 임시로 저장할 배열
            for(byte i = 0; i < data.Length; i++)
            {
                byte x = (byte)(i % 9);                 // 맵 크기는 모두 9x9이므로 
                byte y = (byte)(i / 9);                 // 9로 나눈 나머지가 x좌표, 몫이 y좌표를 나타냄
                MAP[y, x] = (Tile)byte.Parse(data[i]);  // 정수형으로 저장된 맵을 타일로 형변환하여 맵 배열에 저장
                if (MAP[y, x] == Tile.Start)            // 초기 위치로 플레이어를 이동
                    PLAYER.Move(x, y);
            }
            POST_PLAYER.Push(PLAYER.GetPos());          // 플레이어 위치 스택에 현재 위치를 추가
            POST_MAP.Push((Tile[,])MAP.Clone());        // 맵 스택에 현재 맵을 추가
        }

        /// <summary>
        /// 게임 입력 및 처리 함수
        /// </summary>
        void Update()
        {
            Key key = Input();  // 입력받은 키를 변수에 저장
            Move(key);          // 저장한 변수로 행동 처리
        }

        /// <summary>
        /// 게임 입력 함수
        /// </summary>
        /// <returns>입력 키</returns>
        static Key Input()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(); // 단일 키를 입력받아 키 정보로 저장
            switch (keyInfo.Key)                        // 키 정보를 토대로 키 매핑
            {
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    return Key.Left;                    // A, 왼쪽 화살표는 Left로 매핑
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    return Key.Right;                   // D, 오른쪽 화살표는 Right로 매핑
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    return Key.Up;                      // W, 위쪽 화살표는 Up으로 매핑
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    return Key.Down;                    // S, 아래쪽 화살표는 Down으로 매핑
                case ConsoleKey.Escape:
                    return Key.Quit;                    // Esc는 Quit으로 매핑
                case ConsoleKey.R:
                    return Key.Reset;                   // R은 Reset으로 매핑
                case ConsoleKey.T:
                    return Key.Undo;                    // T는 Undo로 매핑
                default:
                    return Key.None;                    // 그 외의 경우 None으로 매핑
            }
        }

        /// <summary>
        /// 입력받은 키를 토대로 동작 처리
        /// </summary>
        /// <param name="key">매핑한 키</param>
        void Move(Key key)
        {
            (byte, byte) pos = PLAYER.GetPos();                 // 이동 전 플레이어 위치
            Tile[,] map = (Tile[,])MAP.Clone();                 // 이동 전 맵 상태
            int x = 0, y = 0;                                   // 좌표를 이동할 변수

            switch (key)                                        // 매핑된 키에 따라 동작
            {
                case Key.Left:                                  // Left인 경우 x축으로 -1 이동
                    x = -1;
                    break;
                case Key.Right:                                 // Right인 경우 x축으로 +1 이동
                    x = 1;
                    break;
                case Key.Up:                                    // Up인 경우 y축으로 -1 이동
                    y = -1;
                    break;
                case Key.Down:                                  // Down인 경우 y축으로 +1 이동
                    y = 1;
                    break;
                case Key.Quit:                                  // Quit인 경우 게임 상태를 Quit으로 변경하고 반환
                    STATE = GameState.Quit;
                    return;
                case Key.Reset:
                    STATE = GameState.Reset;                    // Reset인 경우 게임 상태를 Reset으로 변경하고 반환
                    return;
                case Key.Undo:                                  // Undo인 경우
                    if (POST_MAP.Count > 1)                     // 맵 스택 크기가 1보다 큰 경우
                    {                                           // 스택을 Pop하여 최신 저장 값으로 맵, 플레이어 위치를 변경하고 반환
                        MAP = (Tile[,])POST_MAP.Pop().Clone();
                        PLAYER.Move(POST_PLAYER.Pop());
                        counter--;                              // 이후 이동횟수 차감
                    }
                    else if (POST_MAP.Count == 1)               // 맵 스택 크기가 1인 경우(스택에 초기 값만 있는 경우)
                    {                                           // 스택을 Peek하여 값을 제거하지 않고 맵, 플레이어 위치를 변경하고 반환
                        MAP = (Tile[,])POST_MAP.Peek().Clone();
                        PLAYER.Move(POST_PLAYER.Peek());
                    }
                    return;
                default:
                case Key.None:                                  // None이거나 그 외 값인 경우 아무것도 하지 않고 반환
                    return;
            }
            counter++;                                          // 이동하지 않더라도 입력하였다면 이동횟수를 증감

            // 이동 할 좌표의 타일에 대하여
            switch (MAP[PLAYER.y + y, PLAYER.x + x])
            {
                case Tile.Start:
                case Tile.None:                 // Start이거나 None이면 이동
                    PLAYER.Move((byte)(PLAYER.x + x), (byte)(PLAYER.y + y));
                    break;
                case Tile.Ball:                 // Ball이면
                                                // Ball이 이동할 좌표의 타일에 대하여
                    switch (MAP[PLAYER.y + y * 2, PLAYER.x + x * 2])
                    {
                        case Tile.Start:
                        case Tile.None:         // Start이거나 None이면 Ball과 함께 이동
                            MAP[PLAYER.y + y, PLAYER.x + x] = Tile.None;
                            MAP[PLAYER.y + y * 2, PLAYER.x + x * 2] = Tile.Ball;
                            PLAYER.Move((byte)(PLAYER.x + x), (byte)(PLAYER.y + y));
                            break;
                        case Tile.Empty:        // Empty이면 Ball을 이동시켜서 Empty를 Full로 수정하고 이동
                            MAP[PLAYER.y + y, PLAYER.x + x] = Tile.None;
                            MAP[PLAYER.y + y * 2, PLAYER.x + x * 2] = Tile.Full;
                            PLAYER.Move((byte)(PLAYER.x + x), (byte)(PLAYER.y + y));
                            break;
                        default:
                        case Tile.Wall:
                        case Tile.Ball:
                        case Tile.Full:         // Wall, Ball, Full이나 그 외 값인 경우 이동하지 않음
                            break;
                    }
                    break;
                case Tile.Empty:                // Empty면 이동
                    PLAYER.Move((byte)(PLAYER.x + x), (byte)(PLAYER.y + y));
                    break;
                case Tile.Full:                 // Full이면
                                                // Full 다음 좌표(Full에 들어있는 Ball이 이동할 좌표)의 타일에 대하여
                    switch (MAP[PLAYER.y + y * 2, PLAYER.x + x * 2])
                    {
                        case Tile.Start:
                        case Tile.None:         // Start나 None이라면 Full을 Empty로, 다음 좌표를 Ball로 수정하고 이동
                            MAP[PLAYER.y + y, PLAYER.x + x] = Tile.Empty;
                            MAP[PLAYER.y + y * 2, PLAYER.x + x * 2] = Tile.Ball;
                            PLAYER.Move((byte)(PLAYER.x + x), (byte)(PLAYER.y + y));
                            break;
                        case Tile.Empty:        // Empty라면 Full을 Empty로, 다음 좌표인 Empty를 Full로 수정하고 이동
                            MAP[PLAYER.y + y, PLAYER.x + x] = Tile.Empty;
                            MAP[PLAYER.y + y * 2, PLAYER.x + x * 2] = Tile.Full;
                            PLAYER.Move((byte)(PLAYER.x + x), (byte)(PLAYER.y + y));
                            break;
                        default:
                        case Tile.Wall:
                        case Tile.Ball:
                        case Tile.Full:         // Wall, Ball, Full이라면 이동하지 않음
                            break;
                    }
                    break;
                default:
                case Tile.Wall:                 // Wall이거나 그 외 값인 경우 이동하지 않음
                    break;
            }

            if (PLAYER.GetPos() != pos)         // 이동 전 위치와 이동 후 위치가 다르다면(이동하였다면)
            {                                   // 이동 전 맵, 플레이어 위치를 스택에 저장한다
                POST_MAP.Push(map);
                POST_PLAYER.Push(pos);
            }
        }

        /// <summary>
        /// 데이터를 시각화하여 출력하는 함수
        /// </summary>
        void Render()
        {
            DrawUI();       // UI를 출력
            DrawMap();      // 맵을 먼저 출력
            DrawPlayer();   // 그 위에 플레이어를 출력
        }

        /// <summary>
        /// 맵을 출력하는 함수
        /// </summary>
        void DrawMap()
        {
            Console.SetCursorPosition(0, UP);                   // 게임 화면 상단부터
            for (byte y = 0; y < 9; y++)
            {
                for (byte i = 0; i < LEFT; i++)                 // 게임 화면 좌단만큼 띄워서
                    Console.Write("　");
                for(byte x = 0; x < 9; x++)
                {
                    Console.Write(ChangeTileToPic(MAP[y, x]));  // 맵 배열의 값을 시각화하여 출력
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// 타일을 특정 기호로 시각화하는 함수
        /// </summary>
        /// <param name="tile">시각화하려는 타일</param>
        /// <returns>한 글자 기호</returns>
        string ChangeTileToPic(Tile tile)
        {
            switch (tile)           // 타일 종류에 따라
            {
                default:
                case Tile.Start:
                case Tile.None:     // None, Start이거나 그 외의 값인 경우 공백을 출력
                    return "　";
                case Tile.Wall:     // Wall인 경우 회색으로 기호를 출력
                    Console.ForegroundColor = ConsoleColor.Gray;
                    return "▤";
                case Tile.Ball:     // Ball인 경우 파란색으로 기호를 출력
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    return "●";
                case Tile.Empty:    // Empty인 경우 붉은색으로 기호를 출력
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    return "○";
                case Tile.Full:     // Full인 경우 짙은 노란색으로 기호를 출력
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    return "⊙";
            }
        }

        /// <summary>
        /// 플레이어를 출력하는 함수
        /// </summary>
        void DrawPlayer()
        {
            // 커서를 플레이어의 현재 위치로 이동시키고 옥색으로 기호를 출력
            Console.SetCursorPosition((PLAYER.x + LEFT) * 2, PLAYER.y + UP);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("ⓟ");
        }

        /// <summary>
        /// UI 출력 함수
        /// </summary>
        void DrawUI()
        {
            // 하단 UI
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, UP + 10);
            for(int i = 0; i < LEFT * 2 + 9; i++)
            {
                Console.Write("==");
            }
            Console.WriteLine();
            Console.WriteLine("　　　[현재 레벨 : {0}]　　[이동횟수 : {1}]", LEVEL, counter);
            Console.WriteLine("##　　　　　WASD, ↑←↓→ : 이동 　　　　　##");
            Console.WriteLine("##　　　　　R : 재시도, T : 무르기　　　　　##");
            Console.WriteLine("##　　　　　　　ESC : 게임 종료　　　　　　 ##");
            for (int i = 0; i < LEFT * 2 + 9; i++)
            {
                Console.Write("==");
            }
            Console.WriteLine();
        }

        void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            // 배너 색 변경
            if ((int)BANNER < 15)
                BANNER++;
            else
                BANNER = (ConsoleColor)1;

            // 상단 배너 출력
            Console.ForegroundColor = BANNER;
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("　　　　　　　　　　　　　　　　　　　　　　　");
            Console.WriteLine("　　　　■　　　　■■■■■　　■　■　■　　");
            Console.WriteLine("　　　■　■　　　　　　　■　　■■■　■■　");
            Console.WriteLine("　　■　■　■　　■■■■■　　■■■　■　　");
            Console.WriteLine("　■　　■　　　　　　■　■　　　■　　　　　");
            Console.WriteLine("　　■■■■■　■■■■■■■　　■■■■　　");
            Console.WriteLine("　　　　　　　　　　　　　　　　　　　　　　　");
        
            // 배너를 인게임 밖으로 빼내는 것도 괜찮을듯
            // 반짝이는 배너 + 하단에 [게임 시작 ( Oo ) 게임 종료 ( )] 놓고
            // 좌우 키 입력으로 게임 돌입하면 사라지도록
        }

        /// <summary>
        /// 게임 상태를 확인하는 함수
        /// </summary>
        void ClearCheck()
        {
            if(STATE != GameState.Reset)    // 게임 상태가 Reset이 아니라면
            {
                foreach (Tile tile in MAP)  // 맵의 각 타일을 순회하여
                {
                    if (tile == Tile.Empty) // Empty인 타일이 있다면 게임 상태를 변경하지 않는다
                        return;
                }
                STATE = GameState.Clear;    // Empty인 타일이 발견되지 않았다면 게임 상태를 Clear로 변경한다
            }
        }

        /// <summary>
        /// 게임 종료 후 처리 함수
        /// </summary>
        void Realese()
        {
            switch (STATE)                          // 게임 상태에 따라
            {
                default:
                case GameState.Quit:                // Quit, Reset이거나 그 외 값인 경우 종료
                case GameState.Reset:
                    break;
                case GameState.Clear:               // Clear라면
                    LEVEL++;                        // 레벨을 올리고
                    StreamWriter sw = new StreamWriter(DATA_ADDRESS, false);
                    sw.WriteLine(LEVEL);            // 데이터 파일에 레벨만 수정하고
                    for(int i = 1; i < DATA.GetLength(0); i++)
                        sw.WriteLine(DATA[i]);
                    sw.Close();                     // 나머지는 기존 값으로 수정한 뒤 저장
                    break;
            }
            Console.SetCursorPosition(0, UP + 20);  // 종료 출력문이 게임 화면을 가리지 않도록 커서를 아래로 내림
        }

        static void Main(string[] args)
        {
            Program game = new Program();   // 프로그램 객체 생성
            game.StartGame();               // 생성한 객체로 게임 실행
        }
    }
}