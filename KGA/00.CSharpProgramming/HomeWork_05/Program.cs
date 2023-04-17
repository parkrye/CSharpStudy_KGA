namespace HomeWork_5
{
    internal class Program
    {
        enum Direction { Up, Down, Left, Right, None }  // 플레이어 키 입력 결과
        enum Tile { None, Wall, Goal, Box, BoxGoal }    // 맴 타일 종류

        /// <summary>
        /// 플레이어 위치 구조체
        /// </summary>
        struct Point
        {
            public int x;   // 현재 x좌표
            public int y;   // 현재 y좌표

            /// <summary>
            /// 초기화 함수
            /// </summary>
            /// <param name="x"> 첫 위치 x좌표</param>
            /// <param name="y">첫 위치 y좌표</param>
            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        const char PLAYER = '♥';
        const char WALL = '▩';
        const char GOAL = '□';
        const char BOX = '●';
        const char BOXGOAL = '■';

        static void HW5Main(string[] args)
        {
            // Game Init: 게임 초기화
            Console.Title = "Sokoban";          // 콘솔 타이틀 명명
            Console.CursorVisible = false;      // 커서 깜빡임 해제

            // 맵 구성
            Tile[,] map =
            {
                { Tile.Wall, Tile.Wall, Tile.Wall, Tile.Wall, Tile.Wall, Tile.Wall, Tile.Wall },
                { Tile.Wall, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.Wall },
                { Tile.Wall, Tile.None, Tile.None, Tile.Wall, Tile.Box , Tile.None, Tile.Wall },
                { Tile.Wall, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.Wall },
                { Tile.Wall, Tile.None, Tile.None, Tile.None, Tile.Box , Tile.Goal, Tile.Wall },
                { Tile.Wall, Tile.None, Tile.None, Tile.None, Tile.Wall, Tile.Goal, Tile.Wall },
                { Tile.Wall, Tile.Wall, Tile.Wall, Tile.Wall, Tile.Wall, Tile.Wall, Tile.Wall },
            };
            Point player = new Point(1, 1);     // 플레이어 생성 및 위치 초기화

            // Game render: 게임 시각화
            GameRender(map, player);

            // Game loop: 게임 루프(본 게임)
            while (true)
            {
                // Game input: 게임 입력(사용자 입력 적용)
                Direction direction = GameInput();

                // Game update: 게임 업데이트(입력으로 인한 변경사항 적용)
                (Tile[,] map, Point player) result = GameUpdate(map, player, direction);
                // 변경된 결과 저장
                map = result.map;
                player = result.player;

                // Game render: 게임 시각화(변경된 사항 갱신)
                GameRender(map, player);

                // Game end check: 게임 종료 확인
                if (CheckGameClear(map))
                {
                    Console.Clear();
                    Console.WriteLine("게임 클리어!");
                    break;
                }
            }
        }

        /// <summary>
        /// 게임 갱신 함수
        /// </summary>
        /// <param name="map">게임 맵 배열</param>
        /// <param name="player">플레이어 위치 정보</param>
        static void GameRender(Tile[,] map, Point player)
        {
            Console.Clear();        // 콘솔 출력물 삭제

            // 각 맵 좌표를 순회하며
            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    // 맵 타일에 따라 출력
                    switch (map[y, x])
                    {
                        case Tile.Wall:
                            Console.Write(WALL);
                            break;
                        case Tile.Goal:
                            Console.Write(GOAL);
                            break;
                        case Tile.Box:
                            Console.Write(BOX);
                            break;
                        case Tile.BoxGoal:
                            Console.Write(BOXGOAL);
                            break;
                        default:
                            Console.Write(' ');
                            break;
                    }
                }
                Console.WriteLine();
            }

            // 콘솔 커서 위치를 플레이어 위치로 옮긴 후 플레이어 출력
            Console.SetCursorPosition(player.x, player.y);
            Console.Write(PLAYER);
        }

        /// <summary>
        /// 게임 입력 변환 함수
        /// </summary>
        /// <returns>플레이어 이동 방향</returns>
        static Direction GameInput()
        {
            Direction direction;                        // 플레이어 이동 방향이 저장될 변수
            ConsoleKeyInfo info = Console.ReadKey();    // 키 입력을 받아서
            switch (info.Key)                           // 각 키 입력에 따라 방향을 저장
            {
                case ConsoleKey.UpArrow:
                    direction = Direction.Up;
                    break;
                case ConsoleKey.DownArrow:
                    direction = Direction.Down;
                    break;
                case ConsoleKey.LeftArrow:
                    direction = Direction.Left;
                    break;
                case ConsoleKey.RightArrow:
                    direction = Direction.Right;
                    break;
                default:
                    direction = Direction.None;
                    break;
            }
            return direction;
        }

        /// <summary>
        /// 게임 상황 업데이트 함수
        /// </summary>
        /// <param name="map">게임 맵 배열</param>
        /// <param name="player">플레이어 위치 정보</param>
        /// <param name="direction">플레이어 이동 방향</param>
        /// <returns>변경된 게임 맵 배열, 변경된 플레이어 위치 정보</returns>
        static (Tile[,] map, Point player) GameUpdate(Tile[,] map, Point player, Direction direction)
        {
            Point prevPoint = player;
            // 플레이어 이동
            // 이동 방향에 따라 플레이어 좌표 변경
            switch (direction)
            {
                case Direction.Up:
                    player.y--;
                    break;
                case Direction.Down:
                    player.y++;
                    break;
                case Direction.Left:
                    player.x--;
                    break;
                case Direction.Right:
                    player.x++;
                    break;
            }

            // 이동한 자리가 벽일 경우
            if (map[player.y, player.x] == Tile.Wall)
            {
                // 원위치 시키기
                player = prevPoint;
            }

            // 이동한 자리가 박스일 경우
            else if (map[player.y, player.x] == Tile.Box)
            {
                // 박스 위치(현재 플레이어의 위치)를 이동방향에 맞춰 이동시켜서
                Point point = player;
                switch (direction)
                {
                    case Direction.Up:
                        point.y--;
                        break;
                    case Direction.Down:
                        point.y++;
                        break;
                    case Direction.Left:
                        point.x--;
                        break;
                    case Direction.Right:
                        point.x++;
                        break;
                }

                if (map[point.y, point.x] == Tile.None)         // 이동시킬 위치에 아무것도 없다면
                {
                    map[point.y, point.x] = Tile.Box;           // 박스를 해당 위치로 이동시킨다
                    map[player.y, player.x] = Tile.None;
                }
                else if (map[point.y, point.x] == Tile.Goal)    // 이동시킬 위치에 골이 있다면
                {
                    map[point.y, point.x] = Tile.BoxGoal;       // 골을 골박스로 수정한다
                    map[player.y, player.x] = Tile.None;
                }
                else                                            // 그 외의 경우(박스이거나 벽인 경우)
                {
                    player = prevPoint;                         // 움직일 수 없으므로 플레이어를 원위치시킨다
                }
            }

            // 이동한 자리가 골에 있는 박스일 경우
            else if (map[player.y, player.x] == Tile.BoxGoal)
            {
                // 박스 위치(현재 플레이어의 위치)를 이동방향에 맞춰 이동시켜서
                Point point = player;
                switch (direction)
                {
                    case Direction.Up:
                        point.y--;
                        break;
                    case Direction.Down:
                        point.y++;
                        break;
                    case Direction.Left:
                        point.x--;
                        break;
                    case Direction.Right:
                        point.x++;
                        break;
                }

                if (map[point.y, point.x] == Tile.None)         // 이동시킬 위치에 아무것도 없다면
                {
                    map[point.y, point.x] = Tile.Box;           // 박스를 해당 위치로 이동시키고
                    map[player.y, player.x] = Tile.Goal;        // 그 자리에 골이 남는다
                }
                else if (map[point.y, point.x] == Tile.Goal)    // 이동시킬 위치에 골이 있다면
                {
                    map[point.y, point.x] = Tile.BoxGoal;       // 골을 골박스로 수정하고
                    map[player.y, player.x] = Tile.Goal;        // 그 자리에 골이 남는다
                }
                else                                            // 그 외의 경우(박스이거나 벽인 경우)
                {
                    player = prevPoint;                         // 움직일 수 없으므로 플레이어를 원위치시킨다
                }
            }

            // 수정된 맵 배열과 플레이어 위치 정보를 잔환한다
            return (map, player);
        }

        /// <summary>
        /// 게임 종료 여부 판단 함수
        /// </summary>
        /// <param name="map">게임 맵 배열</param>
        /// <returns>게임 종료 여부. true: 게임 종료, false: 게임 지속</returns>
        static bool CheckGameClear(Tile[,] map)
        {
            foreach (Tile tile in map)
            {
                if (tile == Tile.Goal)
                    return false;
            }

            return true;
        }
    }
}