using System;
using System.Collections.Generic;
using System.Numerics;

namespace HomeWork_6_Proejct_S
{
    internal class Program
    {
        Tile[,] map;            // 게임 맵 타일 배열
        Point player;           // 플레이어 위치 및 이동 정보
        Direction input;        // 사용자 입력 방향
        int left, top;          // 게임 화면 죄상단 위치
        int time;               // 이동 시도 횟수
        int level;              // 현재 레벨
        bool escape;            // 게임 탈출

        // 사용자 이동 방향
        enum Direction { Up, Down, Left, Right, Escape, None }

        // 맴 타일 종류
        enum Tile { None, Wall, Box, Goal, BoxGoal }

        // 플레이어 위치 및 이동 정보 구조체
        struct Point
        {
            public int x;   // 현재 위치 x좌표
            public int y;   // 현재 위치 y좌표

            // 초기화
            public Point(int _x, int _y)
            {
                x = _x;
                y = _y;
            }

            /// <summary>
            /// 플레이어 이동 함수
            /// </summary>
            /// <param name="map">게임 맵 배열</param>
            /// <param name="_x">이동할 x좌표</param>
            /// <param name="_y">이동할 y좌표</param>
            public void Move(Tile[,] map, int _x = 0, int _y = 0){
                // 만약 이동할 위치가 빈칸이라면 이동한다
                if (map[y + _y, x + _x] == Tile.None)
                {
                    x += _x;
                    y += _y;
                }
                // 만약 이동할 위치가 골이라면 이동한다
                else if (map[y + _y, x + _x] == Tile.Goal)
                {
                    x += _x;
                    y += _y;
                }
                // 만약 이동할 위치가 박스라면
                else if (map[y + _y, x + _x] == Tile.Box)
                {
                    // 그 다음 위치가 빈칸이라면 이동한다
                    if (map[y + _y * 2, x + _x * 2] == Tile.None)
                    {
                        x += _x;
                        y += _y;
                        // 그리고 다음 위치는 빈칸으로, 그 다음 위치를 박스로 수정한다
                        map[y, x] = Tile.None;
                        map[y + _y, x + _x] = Tile.Box;
                    }
                    // 그 다음 위치가 골이라면 이동한다
                    else if (map[y + _y * 2, x + _x * 2] == Tile.Goal)
                    {
                        x += _x;
                        y += _y;
                        // 그리고 다음 위치는 빈칸으로, 그 다음 위치를 골박스로 수정한다
                        map[y, x] = Tile.None;
                        map[y + _y, x + _x] = Tile.BoxGoal;
                    }
                }
                // 만약 이동할 위치가 골박스라면
                else if (map[y + _y, x + _x] == Tile.BoxGoal)
                {
                    // 그 다음 위치가 빈칸이라면 이동한다
                    if (map[y + _y * 2, x + _x * 2] == Tile.None)
                    {
                        x += _x;
                        y += _y;
                        // 그리고 다음 위치는 골로, 그 다음 위치를 박스로 수정한다
                        map[y, x] = Tile.Goal;
                        map[y + _y, x + _x] = Tile.Box;
                    }
                    // 그 다음 위치가 골이라면 이동한다
                    else if (map[y + _y * 2, x + _x * 2] == Tile.Goal)
                    {
                        x += _x;
                        y += _y;
                        // 그리고 다음 위치는 골로, 그 다음 위치를 골박스로 수정한다
                        map[y, x] = Tile.Goal;
                        map[y + _y, x + _x] = Tile.BoxGoal;
                    }
                }
            }
        }

        /// <summary>
        /// 맵 출력 함수
        /// 맵 출력 시 콘솔의 출력물이 초기화된다
        /// </summary>
        void MapDraw()
        {
            Console.Clear();
            PrintUI(0);
            for (int y = 0; y < map.GetLength(0); y++)
            {
                for(int i = 0; i < left; i++)
                    Console.Write('　');
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    switch (map[y, x])
                    {
                        default:
                        case Tile.None:
                            Console.Write('　');
                            break;
                        case Tile.Wall:
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write('▦');
                            break;
                        case Tile.BoxGoal:
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write('⊙');
                            break;
                        case Tile.Goal:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write('○');
                            break;
                        case Tile.Box:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write('●');
                            break;
                    }
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// 게임 중 출력문을 생성하는 함수
        /// </summary>
        /// <param name="num">0: 상위 배너, 1: 인게임 안내, 2: 게임 종료 안내</param>
        void PrintUI(int num)
        {
            switch (num)
            {
                default:
                case 0:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.SetCursorPosition(0, 0);
                    if(top >= 8)
                    {
                        Console.WriteLine("########################################");
                        Console.WriteLine("####### ####    ## ## ## ##### ##### ###");
                        Console.WriteLine("###### # ###### ##    ## ####   ##   ###");
                        Console.WriteLine("#### #### ##    ## ## ##  ##          ##");
                        Console.WriteLine("### ##### ##### ##    ## ####       ####");
                        Console.WriteLine("###### ###### ##### ###########   ######");
                        Console.WriteLine("###       ##    ###      ####### #######");
                        Console.WriteLine("########################################");
                        for (int i = 0; i < top - 8; i++)
                            Console.WriteLine();
                    }
                    break;
                case 1:
                    Console.SetCursorPosition(0, map.GetLength(1) + top + 1);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("========================================");
                    Console.WriteLine("   [ 현재 시도 횟수 : {0}] ", time);
                    int goalCount = 0;
                    int boxGoalCount = 0;
                    foreach (Tile tile in map)
                    {
                        if (tile == Tile.Goal)
                            goalCount++;
                        if (tile == Tile.BoxGoal)
                            boxGoalCount++;
                    }
                    Console.WriteLine("   [ 현재 목표 달성 : {0} / {1} ]", boxGoalCount, boxGoalCount + goalCount);
                    Console.WriteLine("========================================");
                    Console.WriteLine("    ☆ : 플레이어            ▦ : 벽    ");
                    Console.WriteLine("    ● : 공   ○ : 구멍   ⊙ : 메워짐   ");
                    Console.WriteLine("========================================");
                    break;
                case 2:
                    Console.SetCursorPosition(0, top);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("########################################");
                    Console.WriteLine("####   ## #####    ###    ####   ###  ##");
                    Console.WriteLine("## ###### ##### ###### ## ### ### ##  ##");
                    Console.WriteLine("## ###### ##### ##### #### ## ### ##  ##");
                    Console.WriteLine("## ###### #####    ##      ##    ###  ##");
                    Console.WriteLine("## ###### ##### ##### #### ## ## ###  ##");
                    Console.WriteLine("## ###### ##### ##### #### ## ### ######");
                    Console.WriteLine("####   ##     #    ## #### ## ### ##  ##");
                    Console.WriteLine("########################################");
                    break;
                case 3:
                    Console.SetCursorPosition(0, top);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("########################################");
                    Console.WriteLine("##                 ##                 ##");
                    Console.WriteLine("#####  #######  ########  #######  #####");
                    Console.WriteLine("#####  #######  ########  #######  #####");
                    Console.WriteLine("#####  #######  ########  #######  #####");
                    Console.WriteLine("#####  #######  ########  #######  #####");
                    Console.WriteLine("#####  #######  ########  #######  #####");
                    Console.WriteLine("#####  #######  ########  #######  #####");
                    Console.WriteLine("########################################");
                    break;
            }
        }

        /// <summary>
        /// 게임 초기화 함수
        /// </summary>
        void Initialize()
        {
            Console.Title = "Project S";    // 콘솔창을 프로젝트명으로 정정한다
            Console.CursorVisible = false;  // 현재 커서 위치 깜빡임을 제거한다

            // 게임 맵 구성
            left = 5;
            top = 9;
            map = new Tile[10, 10]
            {
                { Tile.Wall, Tile.Wall, Tile.Wall, Tile.Wall, Tile.Wall, Tile.Wall, Tile.Wall, Tile.Wall, Tile.Wall, Tile.Wall },
                { Tile.Wall, Tile.None, Tile.Goal, Tile.None, Tile.Wall, Tile.None, Tile.None, Tile.None, Tile.None, Tile.Wall },
                { Tile.Wall, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.Wall },
                { Tile.Wall, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.Goal, Tile.None, Tile.None, Tile.Wall },
                { Tile.Wall, Tile.Wall, Tile.Wall, Tile.Wall, Tile.Wall, Tile.None, Tile.Wall, Tile.None, Tile.None, Tile.Wall },
                { Tile.Wall, Tile.None, Tile.None, Tile.None, Tile.Wall, Tile.None, Tile.None, Tile.None, Tile.None, Tile.Wall },
                { Tile.Wall, Tile.None, Tile.None, Tile.None, Tile.Wall, Tile.None, Tile.None, Tile.None, Tile.None, Tile.Wall },
                { Tile.Wall, Tile.None, Tile.Box, Tile.None, Tile.None, Tile.None, Tile.Box, Tile.None, Tile.None, Tile.Wall },
                { Tile.Wall, Tile.None, Tile.None, Tile.None, Tile.Wall, Tile.None, Tile.None, Tile.None, Tile.None, Tile.Wall },
                { Tile.Wall, Tile.Wall, Tile.Wall, Tile.Wall, Tile.Wall, Tile.Wall, Tile.Wall, Tile.Wall, Tile.Wall, Tile.Wall }
            };

            MapDraw();

            // 플레이어 위치(x, y) 변수
            time = 0;
            player = new(2, 2);

            Reader();

            escape = false;
        }

        /// <summary>
        /// 게임 입력 함수
        /// </summary>
        void Input()
        {
            ConsoleKeyInfo info = Console.ReadKey();    // 키 입력을 받아 게임에서 제공하는 변수로 저장한다
            switch (info.Key)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                case ConsoleKey.NumPad8:
                    input = Direction.Up;       // 위 화살표, W, 숫자패드 8은 위 입력
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                case ConsoleKey.NumPad2:
                    input = Direction.Down;     // 아래 화살표, S, 숫자패드 2는 아래 입력
                    break;
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                case ConsoleKey.NumPad4:
                    input = Direction.Left;     // 왼족 화살표, A, 숫자패드 4는 왼쪽 입력
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                case ConsoleKey.NumPad6:
                    input = Direction.Right;    // 오른쪽 화살표, D 숫자패드 6은 오른쪽 입력
                    break;
                case ConsoleKey.Escape:
                    input = Direction.Escape;   // esc 입력 시 탈출
                    break;
                default:
                    input = Direction.None;     // 그 외 기타 입력은 미입력
                    break;
            }
        }

        /// <summary>
        /// 게임 갱신 함수
        /// </summary>
        void Update()
        {
            // 입력값에 따라 플레이어를 이동시킨다
            switch (input)
            {
                case Direction.Up:
                    player.Move(map, 0, -1);
                    time++;
                    break;
                case Direction.Down:
                    player.Move(map, 0, 1);
                    time++;
                    break;
                case Direction.Left:
                    player.Move(map, -1, 0);
                    time++;
                    break;
                case Direction.Right:
                    player.Move(map, 1, 0);
                    time++;
                    break;
                case Direction.Escape:
                    escape = true;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 게임 출력 함수
        /// </summary>
        void Reader()
        {
            // 게임 상위 배너 출력
            PrintUI(0);

            // 플레이어 주변 재출력
            for (int i = -1; i < 2; i++)
            {
                Console.SetCursorPosition((player.x - 1 + left) * 2, player.y + top + i);
                for (int j = -1; j < 2; j++)
                {
                    switch (map[player.y + i, player.x + j])
                    {
                        default:
                        case Tile.None:
                            Console.Write('　');
                            break;
                        case Tile.Wall:
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write('▦');
                            break;
                        case Tile.BoxGoal:
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write('⊙');
                            break;
                        case Tile.Goal:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write('○');
                            break;
                        case Tile.Box:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write('●');
                            break;
                    }
                }
            }

            // 플레이어 위치 출력
            Console.SetCursorPosition((player.x + left) * 2, player.y + top);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("☆");

            // 게임 안내문 출력
            PrintUI(1);
        }

        /// <summary>
        /// 게임 종료 확인 함수
        /// </summary>
        /// <returns>게임 플레이 여부. true: 게임 플레이 중, false: 게임 종료</returns>
        bool IsPlay()
        {
            if(escape)
                return false;
            // 게임 맵의 모든 타일을 순회하여 Goal이 남아있을 경우 게임이 종료되지 않았다고 판단
            foreach (Tile tile in map)
            {
                if (tile == Tile.Goal)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 게임 종료 후 출력 함수
        /// </summary>
        void Release()
        {
            if(!escape)
                PrintUI(2);
            else
                PrintUI(3);
        }

        /// <summary>
        /// 게임 실행 함수
        /// </summary>
        void Play()
        {
            Initialize();           // 게임 요소 초기화
            while (IsPlay())        // 게임 진행 검사 후 반복
            {
                Input();            // 사용자 입력
                Update();           // 상호작용 적용
                Reader();           // 시각화
            }
            Release();              // 게임 종료
        }

        static void Main(string[] args)
        {
            Program game = new();   // 게임 객체 생성
            game.Play();            // 게임 시작
        }
    }
}