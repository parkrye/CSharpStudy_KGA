using System.Xml.Linq;

namespace Homework_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool[,] tileMap = new bool[9, 9]
            {
                { false, false, false, false, false, false, false, false, false },
                { false,  true,  true,  true, false, false, false,  true, false },
                { false,  true, false,  true, false, false, false,  true, false },
                { false,  true, false,  true,  true,  true,  true,  true, false },
                { false,  true, false,  true, false, false, false,  true, false },
                { false,  true, false,  true, false, false, false,  true, false },
                { false, false, false, false, false, false, false,  true, false },
                { false,  true,  true,  true,  true,  true,  true,  true, false },
                { false, false, false, false, false, false, false, false, false },
            };
            List<Point> path;


            AStar(tileMap, new Point(1, 1), new Point(1, 7), out path);
            PrintResult(tileMap, path);
        }

        static bool AStar(bool[,] tileMap, Point start, Point end, out List<Point> path)
        {
            // 초기화
            int ySize = tileMap.GetLength(0);
            int xSize = tileMap.GetLength(1);

            Node[,] nodes = new Node[ySize, xSize];
            bool[,] visited = new bool[ySize, xSize];
            PriorityQueue<Node, int> nextPointPQ = new PriorityQueue<Node, int>();

            // 0. 시작 정점을 생성하여 추가
            Node startNode = new Node(start, null, 0, Heuristic(start, end));
            nextPointPQ.Enqueue(startNode, startNode.f);
            nodes[startNode.point.y, startNode.point.x] = startNode;

            // 1. 다음으로 탐색할 정점 꺼내기
            while(nextPointPQ.Count > 0)
            {
                // 2. 방문한 정점은 방문표시
                Node node = nextPointPQ.Dequeue();
                visited[node.point.y, node.point.x] = true;

                // 3. 다음으로 탐색할 정점이 도착지인 경우
                // 도착했다고 판단해서 경로 반환
                if (node.point.x == end.x && node.point.y == end.y)
                {
                    path = new List<Point>();
                    while(node.parent != null)
                    {
                        path.Add(node.point);
                        node = nodes[node.parent.point.y, node.parent.point.x];
                    }
                    path.Reverse();
                    return true;
                }

                // 4. AStar 탐색을 진행
                for(int i = 0; i < Direction.Length; i++)
                {
                    // 방향 탐색
                    int x = node.point.x + Direction[i].x;
                    int y = node.point.y + Direction[i].y;

                    // 4-1. 탐색하면 안되는 경우
                    // 맵을 벗어났을 경우
                    if (x < 0 || x >= tileMap.GetLength(0) || y < 0 || y >= tileMap.GetLength(1))
                        continue;
                    // 탐색할 수 없는 정점일 경우
                    if (!tileMap[y, x])
                        continue;
                    // 이미 방문한 정점일 경우
                    if (visited[y, x])
                        continue;
                    // 4-2. 탐색한 정점 만들기
                    int g = node.g + CostStraight;
                    int h = Heuristic(new Point(x, y), end);
                    Node newNode = new Node(new Point(x, y), node, g, h);

                    // 4-3. 정점의 갱신이 필요한 경우 새로운 정점으로 할당
                    // 탐색하지 않은 정점이거나
                    // 가중치가 높은 정점인 경우
                    if (nodes[y, x] == null || nodes[y, x].f > newNode.f)
                    {
                        nextPointPQ.Enqueue(newNode, newNode.f);
                        nodes[newNode.point.y, newNode.point.x] = newNode;
                    }
                }
            }
            path = null;
            return false;
        }


        // 휴리스틱 (Heuristic) : 최상의 경로를 추정하는 순위값, 휴리스틱에 의해 경로탐색 효율이 결정됨
        static int Heuristic(Point start, Point end)
        {
            // 가로로 가야하는 횟수
            // 세로로 가야하는 횟수
            int x = Math.Abs(start.x - end.x);
            int y = Math.Abs(start.y - end.y);

            // 유클리드 거리 : 대각선을 통해 이동하는 거리
            return (int)(Math.Sqrt(x * x + y * y));
        }

        const int CostStraight = 10;
        const int CostDiagonal = 14;

        static Point[] Direction =
        {
            new Point(  0, 1 ),
			new Point(  0, -1 ),
			new Point( -1,  0 ),
			new Point( 1,  0 ),
		};

        class Node
        {
            public Point point;
            public Node? parent;

            public int f, g, h;

            public Node(Point _point, Node? _parent, int _g, int _h)
            {
                point = _point;
                parent = _parent;
                g = _g;
                h = _h;
                f = g + h;
            }
        }

        struct Point
        {
            public int x;
            public int y;

            public Point(int _x, int _y)
            {
                this.x = _x;
                this.y = _y;
            }
        }

        static void PrintResult(in bool[,] tileMap, in List<Point> path)
        {
            char[,] pathMap = new char[tileMap.GetLength(0), tileMap.GetLength(1)];
            for (int y = 0; y < pathMap.GetLength(0); y++)
            {
                for (int x = 0; x < pathMap.GetLength(1); x++)
                {
                    if (tileMap[y, x])
                        pathMap[y, x] = ' ';
                    else
                        pathMap[y, x] = 'X';
                }
            }

            foreach (Point point in path)
            {
                pathMap[point.y, point.x] = '*';
            }

            Point start = path.First();
            Point end = path.Last();
            pathMap[start.y, start.x] = 'S';
            pathMap[end.y, end.x] = 'E';

            for (int i = 0; i < pathMap.GetLength(0); i++)
            {
                for (int j = 0; j < pathMap.GetLength(1); j++)
                {
                    Console.Write(pathMap[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}