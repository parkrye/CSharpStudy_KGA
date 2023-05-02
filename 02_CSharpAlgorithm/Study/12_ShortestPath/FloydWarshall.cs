using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_ShortestPath
{
    internal class FloydWarshall
    {
        /******************************************************
		 * 플로이드-워셜 알고리즘 (Floyd-Warshall Algorithm)
		 * 
		 * 모든 노드에서 출발하여 다른 노드로 가는 각각의 최단 경로를 구함
		 * 모든 노드를 거쳐가며 최단 거리가 갱신되는 조합이 있을 경우 갱신
		 ******************************************************/

        const int INF = 99999;

        public static void ShortestPath(in int[,] graph, out int[,] costTable, out int[,] pathTable)
        {
            int count = graph.GetLength(0);
            costTable = new int[count, count];  // 각 정점에서 다른 정점으로의 거리에 대한 배열
            pathTable = new int[count, count];  // 최단 거리로 각 정점에 도달한 직전 정점

            for (int y = 0; y < count; y++)
            {
                for (int x = 0; x < count; x++)
                {
                    costTable[y, x] = graph[y, x];
                    pathTable[y, x] = graph[y, x] < INF ? y : -1;
                }
            }

            for (int middle = 0; middle < count; middle++)      // 중간 정점
            {
                for (int start = 0; start < count; start++)     // 출발 정점
                {
                    if (middle == start)
                        continue;

                    for (int end = 0; end < count; end++)       // 도착 정점
                    {
                        if (middle == end || start == end)
                            continue;

                        // 출발 => 도착 > 출발 => 중간 => 도착이라면
                        if (costTable[start, end] > costTable[start, middle] + costTable[middle, end])
                        {
                            // 중간을 거치는 경로가 더 짧으니 해당 거리를 저장
                            costTable[start, end] = costTable[start, middle] + costTable[middle, end];
                            // 중간 정점을 기록
                            pathTable[start, end] = middle;
                        }
                    }
                }
            }
        }
    }
}
