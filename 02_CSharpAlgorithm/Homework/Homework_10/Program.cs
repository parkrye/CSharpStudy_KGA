namespace Homework_10
{
    internal class Program
    {
        const int INF = 99999;

        static void Main(string[] args)
        {
            // 사용할 그래프
            int[,] graph = new int[8, 8]
                {
                    { 0, INF, 7, 3, 7, INF, INF, INF },
                    { INF, 0, INF, INF, INF, INF, INF, INF },
                    { 7, INF, 0, INF, INF, INF, 4, INF },
                    { 3, INF, INF, 0, INF, INF, INF, 8 },
                    { 7, INF, INF, INF, 0, INF, INF, 9 },
                    { INF, INF, INF, INF, INF, 0, 3, 3 },
                    { INF, INF, 4, INF, INF, 3, 0, INF },
                    { INF, INF, INF, 8, 9, 3, INF, 0 }
                };
            int[] dist = new int[8];    // 각 노드까지의 거리 배열
            int[] path = new int[8];    // 각 노드의 이전 노드 배열
            MyDijkstra(graph, 0, dist, path);
            PrintMyDijkstra(graph, dist, path);
        }

        /// <summary>
        /// 다익스트라 연산 메소드
        /// </summary>
        /// <param name="graph">그래프</param>
        /// <param name="start">시작 노드</param>
        /// <param name="dist">시작 노드로부터의 거리 배열</param>
        /// <param name="path">노드의 이전 노드 배열</param>
        static void MyDijkstra(int[,] graph, int start, int[] dist, int[] path)
        {
            bool[] visit = new bool[graph.GetLength(0)];    // 방문 여부 배열

            for (int i = 0; i < graph.GetLength(0); i++)    // 각 노드에 대하여
            {
                if(i != start)                              // 시작 노드가 아닌 경우
                {
                    if (graph[start, i] < INF)              // 연결되어 있다면
                    {
                        dist[i] = graph[start, i];          // 거리는 시작 노드로부터의 거리
                        path[i] = start;                    // 이전 노드는 시작 노드
                    }
                    else                                    // 연결되어 있지 않다면
                    {
                        dist[i] = INF;                      // 거리는 무한대
                        path[i] = -1;                       // 이전 노드는 없음
                    }
                }
                else                                        // 시작 노드인 경우
                {
                    dist[i] = 0;                            // 거리는 0
                    path[i] = -1;                           // 이전 노드는 없음
                    visit[start] = true;                    // 시작 노드는 방문
                }
            }

            for (int count = 0; count < graph.GetLength(1); count++)    // 각 노드 개수만큼 반복
            {
                int minIdx = -1;                                        // 가장 거리가 가까운 노드의 번호
                int minDist = INF;                                      // 가장 가까운 노드와의 거리
                for(int i = 0; i < graph.GetLength(0); i++)             // 각 노드에 대하여
                {
                    if(i != start &&                                    // 시작 노드가 아니고
                        !visit[i] &&                                    // 방문하지 않았으며
                        dist[i] < minDist)                              // 거리가 최단 거리 노드보다 작다면
                    {
                        minIdx = i;                                     // 해당 노드가 최단 거리 노드이고
                        minDist = dist[i];                              // 최단 거리느 해당 노드와의 거리
                    }
                }
                if (minIdx == -1)                                       // 최단 노드가 없다면 모든 노드를 방문한 것
                    break;

                for (int i = 0; i < graph.GetLength(0); i++)            // 각 노드에 대하여
                {
                    if (i != start &&                                   // 시작 노드가 아니고
                        dist[i] > dist[minIdx] + graph[minIdx, i])      // 시작 노드로부터의 거리가 최단 노드를 거쳐서 도달하는 거리보다 크다면
                    {
                        dist[i] = dist[minIdx] + graph[minIdx, i];      // 시작 노드로부터의 거리는 최단 노드를 거쳐서 도달하는 거리
                        path[i] = minIdx;                               // 시작 노드로부터의 노드의 이전 노드는 최단 노드
                    }
                }

                visit[minIdx] = true;                                   // 최단 노드는 방문
            }
        }

        /// <summary>
        /// 다익스트라 결과 출력 메소드
        /// </summary>
        /// <param name="graph">그래프</param>
        /// <param name="dist">거리</param>
        /// <param name="path">이전노드</param>
        static void PrintMyDijkstra(int[,] graph, int[] dist, int[] path)
        {
            int size = graph.GetLength(0);
            Console.WriteLine("[그래프]");
            for (int i = 0; i < size; i++)
            {
                for(int j = 0; j < size; j++)
                {
                    Console.Write($"{(graph[i, j] < INF ? graph[i, j] : "-")} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            Console.WriteLine("[최단 거리]");
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine($"{i} : {(dist[i] < INF ? dist[i] : "-")} ");
            }
            Console.WriteLine();

            Console.WriteLine("[이전 경로]");
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine($"{i} : {(path[i] != -1 ? path[i] : "-")} ");
            }
            Console.WriteLine();
        }
    }
}