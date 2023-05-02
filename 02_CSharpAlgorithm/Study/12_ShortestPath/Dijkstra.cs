using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_ShortestPath
{
    internal class Dijkstra
    {
        /******************************************************
         * 다익스트라 알고리즘 (Dijkstra Algorithm)
         * 
         * 특정한 노드에서 출발하여 다른 노드로 가는 각각의 최단 경로를 구함
         * 방문하지 않은 노드 중에서 최단 거리가 가장 짧은 노드를 선택 후,
         * 해당 노드를 거쳐 다른 노드로 가는 비용 계산
         ******************************************************/

        const int INF = 99999;

        public static void ShortestPath(in int[,] graph, in int start, out int[] distance, out int[] path)
        {
            int size = graph.GetLength(0);
            bool[] visited = new bool[size];    // 방문 여부 배열

            distance = new int[size];           // start로부터의 거리
            path = new int[size];               // 해당 노드를 연결한 이전 정점
            for (int i = 0; i < size; i++)
            {
                distance[i] = graph[start, i];  // 각 정점으로의 거리를 복사
                path[i] = graph[start, i] < INF ? start : -1;
                                                // 거리가 INF가 아니라면, start와 연결된 정점이다
            }

            for (int i = 0; i < size; i++)
            {
                // 1. 방문하지 않은 정점 중 가장 가까운 정점부터 탐색
                int next = -1;
                int minCost = INF;
                for (int j = 0; j < size; j++)
                {
                    if (!visited[j] &&          // 방문하지 않았고
                        distance[j] < minCost)  // 최소 거리인 정점에 대해
                    {
                        next = j;               // 해당 정점을 대상으로 한다
                        minCost = distance[j];
                    }
                }
                if (next < 0)   // 그러한 정점이 없다면 해당 정점과 연결된 정점은 모두 탐색했거나 고립된 것
                    break;

                // 2. 직접연결된 거리보다 거쳐서 더 짧아진다면 갱신.
                for (int j = 0; j < size; j++)
                {
                    // distance[j]    : 목적지까지 직접 연결된 거리
                    // distance[next] : 탐색중인 정점까지 거리
                    // graph[next, j] : 탐색중인 정점부터 목적지의 거리
                    if (distance[j] > distance[next] + graph[next, j])
                    {
                        distance[j] = distance[next] + graph[next, j];
                        path[j] = next;
                    }
                }
                visited[next] = true;
            }
        }
    }
}
