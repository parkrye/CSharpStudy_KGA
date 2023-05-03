using System.Diagnostics;

namespace MazeRunner
{
    [Serializable]
    internal class Maze
    {
        enum Tile { Road, Wall, Start , Goal }; // 미로 타일 구성. 길, 벽, 시작, 도착
        Tile[,] maze;                           // 미로 배열
        bool submit, completed;                 // 제출 여부, 완성 여부
        int size;                               // 미로 크기
        (int x, int y) start, goal;             // 시작, 목표 위치
        Stopwatch stopWatch;                    // 시간 측정을 위한 스톱워치

        // 상하좌우 방향에 대한 변수
        (int x, int y)[] Direction =
        {
            new (  0, +1 ),
            new (  0, -1 ),
            new ( -1,  0 ),
            new ( +1,  0 ),
        };

        /// <summary>
        /// 미로 생성자
        /// </summary>
        /// <param name="_size">미로 크기. 기본 15</param>
        public Maze(int _size = 15)
        {
            size = _size;
            maze = new Tile[size, size];
            for (int i = 0; i < size; i++){     // 외곽은 무조건 벽
                maze[0, i] = Tile.Wall;
                maze[size - 1, i] = Tile.Wall;
                maze[i, 0] = Tile.Wall;
                maze[i, size - 1] = Tile.Wall;
            }
            completed = false;
        }

        /// <summary>
        /// 미로 제작
        /// </summary>
        public void MakeMaze()
        {
            PrintMaze();                                // 초기 미로를 보여주고
            int x = 1, y = 1;                           // 초기 커서 위치
            while(!completed)
            {
                PrintMaze(false, x, y);                 // 현재 미로를 보여주고
                if(ClickCursor(ref x, ref y))           // 커서 클릭
                {                                       // true : 현재 커서의 블록을 수정한다
                    if (maze[y, x] == Tile.Road)        // false : 커서를 이동했다
                        maze[y, x] = Tile.Wall;         //   ㄴ 혹은 미로가 완성되었다고 제출했다
                    else if (maze[y, x] == Tile.Wall)
                        maze[y, x] = Tile.Goal;
                    else if (maze[y, x] == Tile.Goal)
                        maze[y, x] = Tile.Start;
                    else if (maze[y, x] == Tile.Start)
                        maze[y, x] = Tile.Road;
                }

                if (submit)                             // 미로가 완성되었다고 제출했다면
                {
                    if (CheckMzae())                    // 완성 여부를 파악하고
                    {
                        completed = true;               // 완성되었다면 while문을 탈출한다
                    }
                    else
                    {
                        submit = false;                 // 완성되지 않았다면 제출을 취소한다
                    }
                }
            }
        }

        /// <summary>
        /// 미로 출력
        /// </summary>
        public void PrintMaze(bool full = true, params int[] pos)
        {
            if (full)
            {
                Console.Clear();
                Console.WriteLine("[Maze]");
                for (int y = 0; y < size; y++)
                {
                    for (int x = 0; x < size; x++)
                    {
                        if (maze[y, x] == Tile.Road)
                            Console.Write("　");
                        else if (maze[y, x] == Tile.Wall)
                            Console.Write("■");
                        else if (maze[y, x] == Tile.Goal)
                            Console.Write("※");
                        else if (maze[y, x] == Tile.Start)
                            Console.Write("＠");
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                for(int y = -1; y < 2; y++)
                {
                    for(int x = -1; x < 2; x++)
                    {
                        Console.SetCursorPosition((pos[0] + x) * 2, pos[1] + y + 1);
                        if (pos[0] + x >= 0 && pos[0] + x < size && pos[1] + y >= 0 && pos[1] + y < size)
                        {
                            if (maze[pos[1] + y, pos[0] + x] == Tile.Road)
                                Console.Write("　");
                            else if (maze[pos[1] + y, pos[0] + x] == Tile.Wall)
                                Console.Write("■");
                            else if (maze[pos[1] + y, pos[0] + x] == Tile.Goal)
                                Console.Write("※");
                            else if (maze[pos[1] + y, pos[0] + x] == Tile.Start)
                                Console.Write("＠");
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 키 입력
        /// </summary>
        /// <param name="x">현재 커서 x</param>
        /// <param name="y">현재 커서 y</param>
        /// <returns>블록 수정 여부</returns>
        bool ClickCursor(ref int x, ref int y)
        {
            Console.SetCursorPosition(x * 2, y + 1);    // 커서를 현재 위치로 이동
            switch (InputManager.GetInput())
            {
                // 커서 이동
                case Key.Left:
                    if (x > 1)
                        x--;
                    break;
                case Key.Right:
                    if (x < size - 2)
                        x++;
                    break;
                case Key.Up:
                    if (y > 1)
                        y--;
                    break;
                case Key.Down:
                    if (y < size - 2)
                        y++;
                    break;
                case Key.Space: // 블록 수정
                    return true;
                case Key.Enter: // 미로 제출
                    submit = true;
                    break;
            }
            return false;
        }

        /// <summary>
        /// BFS로 미로가 완성되었는지 확인
        /// </summary>
        /// <returns>미로 완성 여부</returns>
        bool CheckMzae()
        {
            bool goalBool = false, startBool = false;               // 목표, 시작 위치가 존재하는지 여부

            for(int y = 0; y < size; y++)
            {
                for(int x = 0; x < size; x++)
                {
                    if (maze[y, x] == Tile.Start)   // 시작 타일을 찾았는데
                    {
                        if (startBool)              // 이미 시작 타일이 있었다면
                            return false;           // 미완성 미로임
                        startBool = true;           // 아니라면 시작 타일을 체크하고
                        start = (x, y);             // 좌표를 저장
                    }
                    if (maze[y, x] == Tile.Goal)    // 목표 타일을 찾았는데
                    {
                        if (goalBool)               // 이미 목표 타일이 있었다면
                            return false;           // 미완성 미로임
                        goalBool = true;            // 아니라면 목표 타일을 체크하고
                        goal = (x, y);              // 좌표를 저장
                    }
                }
            }

            if (!goalBool || !startBool)            // 시작 타일이나 목표 타일이 하나라도 없다면
                return false;                       // 미완성 미로임


            bool[,] visited = new bool[size, size]; // 방문 여부 배열

            Queue<(int x, int y)> bfsQueue = new Queue<(int x, int y)>();   // bfs 탐색을 위한 큐

            bfsQueue.Enqueue(start);                // 큐에 초기 위치를 추가

            while (bfsQueue.Count > 0)
            {
                (int x, int y) now = bfsQueue.Dequeue();    // 탐색할 좌표를 큐에서 꺼내고
                visited[now.y, now.x] = true;               // 탐색 좌표를 방문

                if(now == goal)                             // 탐색 좌표가 목표 좌표라면
                {
                    return true;                            // 완성된 미로임
                }


                for (int i = 0; i < Direction.Length; i++)  // 각 상하좌우 방향에 대하여
                {
                    int xi = now.x + Direction[i].x;
                    int yi = now.y + Direction[i].y;

                    if (xi >= 0 && xi < size && yi >= 0 && yi < size && // 범위 내이고
                        maze[yi, xi] != Tile.Wall &&                    // 벽이 아니고
                        !visited[yi, xi])                               // 방문하지 않은 좌표라면
                    {
                        bfsQueue.Enqueue((xi, yi));                     // 좌표를 큐에 넣는다
                    }
                }
            }

            return false;       // 반복이 끝날 때까지 목표에 닿지 않았다면 미완성 미로임
        }

        /// <summary>
        /// 미로 찾기 경로를 표기하는 메소드
        /// </summary>
        public void RunMaze()
        {
            stopWatch = new Stopwatch();

            // 정답이 그려지지 않은 미로 출력
            PrintMaze();
            InputManager.GetInput();

            // DFS로 발견한 탈출 경로 출력
            DFS();
            InputManager.GetInput();

            // AStar로 발견한 탈출 경로 출력
            Astar();
            InputManager.GetInput();
        }

        /// <summary>
        /// DFS 경로를 찾고 출력하는 메소드
        /// </summary>
        void DFS()
        {
            stopWatch.Start();
            bool[,] visit = new bool[size, size];   // 좌표 방문 배열 
            bool[,] route = new bool[size, size];   // 이동 좌표 배열
            Solve_DFS(start, visit, route);         // 문제를 해결
            stopWatch.Stop();
            float time = stopWatch.Elapsed.Milliseconds;
            Print_DFS(route, time);                // 해결한 결과 출력
        }

        /// <summary>
        /// DFS 문제 해결 메소드
        /// </summary>
        /// <param name="point">현재 좌표</param>
        /// <param name="visit">방문 좌표 배열</param>
        /// <param name="route">이동 경로 배열</param>
        /// <returns>목표 도착 여부</returns>
        bool Solve_DFS((int x, int y) point, bool[,] visit, bool[,] route)
        {
            if(point == goal)   // 현재 좌표가 목표 좌표라면
            {
                return true;    // 길을 찾았으므로 즉시 탈출한다
            }

            visit[point.y, point.x] = true;                 // 현재 좌표를 방문 표시하고
            for (int i = 0; i < Direction.Length; i++)      // 상하좌우 좌표에 대해
            {
                int xi = point.x + Direction[i].x;
                int yi = point.y + Direction[i].y;

                if (yi > 0 && yi < size - 1 &&              // 좌우 범위 이내이고
                    xi > 0 && xi < size - 1 &&              // 상하 범위 이내이며
                    maze[yi, xi] != Tile.Wall &&            // 벽이 아니고
                    !visit[yi, xi])                         // 방문하지 않았다면
                {
                    route[yi, xi] = true;                   // 그 좌표로 이동
                    if (Solve_DFS((xi, yi), visit, route))  // 재귀 호출
                        return true;                        // 만약 true가 반환되면 더이상 탐색할 필요 없음
                    route[yi, xi] = false;                  // 그 좌표가 틀렸으므로 이동 취소
                }
            }
            return false;                                   // 끝까지 목표에 닿지 못했으므로 false 반환
        }

        /// <summary>
        /// DFS 결과 만들어진 경로를 출력하는 메소드
        /// </summary>
        /// <param name="route">경로 배열</param>
        void Print_DFS(bool[,] route, float time)
        {
            PrintMaze();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine($"[DFS : {time}ms]");
            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    if (route[y, x] && (maze[y, x] != Tile.Start && maze[y, x] != Tile.Goal) )
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("○");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        if (maze[y, x] == Tile.Road)
                            Console.Write("　");
                        else if (maze[y, x] == Tile.Wall)
                            Console.Write("■");
                        else if (maze[y, x] == Tile.Goal)
                            Console.Write("※");
                        else if (maze[y, x] == Tile.Start)
                            Console.Write("＠");
                    }
                }
                Console.WriteLine();
            }
        }

        const int CostStraight = 10;    // 직선 이동 코스트
        const int CostDiagonal = 14;    // 대각선 이동 코스트

        /// <summary>
        /// AStar 문제 해결 메소드
        /// </summary>
        /// <returns>문제 해결 여부</returns>
        bool Astar()
        {
            stopWatch.Restart();
            bool[,] visit = new bool[size, size];   // 방문 여부의 배열
            Node[,] nodes = new Node[size, size];   // 각 변수들(좌표, 이전 좌표, fgh)을 갖는 노드들의 배열
            PriorityQueue<Node, int> nextPointPQ = new PriorityQueue<Node, int>();  // 우선순위 큐로 노드들을 예상되는 총 코스트(f)로 정렬하여 저장
            List<(int x, int y)> path = new List<(int x, int y)>(); // 결과를 저장할 리스트

            Node startNode = new Node(start, null, 0, Heuristic(start, goal));  // 초기 노드
            nodes[startNode.point.y, startNode.point.x] = startNode;            // 초기 노드를 노드 배열에 저장
            nextPointPQ.Enqueue(startNode, startNode.f);                        // 우선순위 큐에 초기 노드를 추가

            while (nextPointPQ.Count > 0)   // 큐가 남아있는 한 반복
            {
                Node nextNode = nextPointPQ.Dequeue();  // 큐에서 f가 가장 낮은 노드를 빼내어

                visit[nextNode.point.y, nextNode.point.x] = true;   // 해당 노드를 탐색한다

                if (nextNode.point.x == goal.x && nextNode.point.y == goal.y)   // 해당 노드가 목적지 노드라면
                {
                    (int x, int y)? pathPoint = goal;
                    path = new List<(int x, int y)>();

                    while (pathPoint != null)   // 지금까지의 좌표들을 리스트에 저장한다(각 노드는 이전 노드 좌표를 갖고 있으므로)
                    {
                        (int x, int y) point = pathPoint.GetValueOrDefault();
                        path.Add(point);
                        pathPoint = nodes[point.y, point.x].parent;
                    }

                    path.Reverse();     // 이렇게 저장된 경로는 역순이므로 뒤집어서
                    stopWatch.Stop();
                    Print_AStar(path, stopWatch.Elapsed.Milliseconds);  // 출력하고
                    return true;        // 반환한다
                }

                // 목적지가 아니라면 탐색한다
                for (int i = 0; i < Direction.Length; i++)  // 각 십자 방향에 대하여
                {
                    int x = nextNode.point.x + Direction[i].x;
                    int y = nextNode.point.y + Direction[i].y;

                    if (x < 0 || x >= size || y < 0 || y >= size)   // 범위 밖이면 패스
                        continue;
                    else if (maze[y, x] == Tile.Wall)   // 벽이면 패스
                        continue;
                    else if (visit[y, x])   // 방문했으면 패스
                        continue;

                    int g = nextNode.g + ((nextNode.point.x == x || nextNode.point.y == y) ? CostStraight : CostDiagonal);  // 이동 코스트에 직선 코스트 or 대각선 코스트만큼 더하고
                    int h = Heuristic((x, y), goal);    // 예상 코스트를 구하고
                    Node newNode = new Node((x, y), nextNode.point, g, h);  // 이를 기반으로 노드를 생성한다

                    if (nodes[y, x] == null ||      // 추가할 노드의 자리가 비어있거나
                        nodes[y, x].f > newNode.f)  // 추가할 노드의 총 코스트가 원래 노드의 총 코스트보다 작다면
                    {
                        nodes[y, x] = newNode;      // 노드를 저장하고 큐에 추가한다
                        nextPointPQ.Enqueue(newNode, newNode.f);
                    }
                }
            }

            path = null;
            return false;
        }

        /// <summary>
        /// 예상 코스트를 계산하는 메소드
        /// </summary>
        /// <param name="start">시작 위치</param>
        /// <param name="end">목표 위치</param>
        /// <returns>예상 코스트</returns>
        int Heuristic((int x, int y) start, (int x, int y) end)
        {
            int xSize = Math.Abs(start.x - end.x);
            int ySize = Math.Abs(start.y - end.y);

            return CostStraight * (int)Math.Sqrt(xSize * xSize + ySize * ySize);
        }

        /// <summary>
        /// AStar를 위한 변수들을 갖는 노드
        /// </summary>
        class Node
        {
            public int f;   // g + h
            public int g;   // 현재까지 이동 코스트
            public int h;   // 앞으로 예상되는 이동 코스트

            public (int x, int y) point;    // 현재 좌표
            public (int x, int y)? parent;  // 이전 좌표

            public Node((int x, int y) _point, (int x, int y)? _parent, int _g, int _h)
            {
                point = _point;
                parent = _parent;
                g = _g;
                h = _h;
                f = g + h;
            }
        }

        /// <summary>
        /// AStar 경로를 출력하는 메소드
        /// </summary>
        /// <param name="path">탈출 경로</param>
        void Print_AStar(List<(int x, int y)> path, float time)
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine($"[AStar : {time}ms]");

            bool[,] pathMap = new bool[size, size];

            foreach ((int x, int y) point in path)
            {
                pathMap[point.y, point.x] = true;
            }

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (pathMap[i, j] && (maze[i, j] != Tile.Start && maze[i, j] != Tile.Goal))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("○");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        if (maze[i, j] == Tile.Road)
                            Console.Write("　");
                        else if (maze[i, j] == Tile.Wall)
                            Console.Write("■");
                        else if (maze[i, j] == Tile.Goal)
                            Console.Write("※");
                        else if (maze[i, j] == Tile.Start)
                            Console.Write("＠");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
