using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeRunner
{
    [Serializable]
    internal class Maze
    {
        enum Tile { Road, Wall, Start , Goal }; // 미로 타일 구성. 길, 벽, 시작, 도착
        Tile[,] maze;                           // 미로 배열
        bool submit, completed;                 // 제출 여부, 완성 여부
        int size;                               // 미로 크기

        /// <summary>
        /// 미로 생성자
        /// </summary>
        /// <param name="_size">미로 크기. 기본 15</param>
        public Maze(int _size = 15)
        {
            size = _size;
            maze = new Tile[size, size];
            for (int i = 0; i < size; i++){
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
            int x = 1, y = 1;
            while(!completed)
            {
                PrintMaze();
                PrintCursor(x, y);
                if(MoveCursor(ref x, ref y))
                {
                    if (maze[y, x] == Tile.Road)
                        maze[y, x] = Tile.Wall;
                    else if (maze[y, x] == Tile.Wall)
                        maze[y, x] = Tile.Goal;
                    else if (maze[y, x] == Tile.Goal)
                        maze[y, x] = Tile.Start;
                    else if (maze[y, x] == Tile.Start)
                        maze[y, x] = Tile.Road;
                }

                if (submit)
                {
                    if (CheckMzae())
                    {
                        completed = true;
                    }
                    else
                    {
                        submit = false;
                    }
                }
            }
        }

        /// <summary>
        /// 미로 출력
        /// </summary>
        public void PrintMaze()
        {
            Console.SetCursorPosition(0, 0);
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

        void PrintCursor(int x, int y)
        {
            Console.SetCursorPosition(x * 2, y);
        }

        /// <summary>
        /// 키 입력
        /// </summary>
        /// <param name="x">현재 커서 x</param>
        /// <param name="y">현재 커서 y</param>
        /// <returns>미로 제출 여부</returns>
        bool MoveCursor(ref int x, ref int y)
        {
            ConsoleKey key = Console.ReadKey().Key;
            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    if (x > 1)
                        x--;
                    break;
                case ConsoleKey.RightArrow:
                    if (x < size - 2)
                        x++;
                    break;
                case ConsoleKey.UpArrow:
                    if (y > 1)
                        y--;
                    break;
                case ConsoleKey.DownArrow:
                    if (y < size - 2)
                        y++;
                    break;
                case ConsoleKey.Spacebar:
                    return true;
                case ConsoleKey.Enter:
                    submit = true;
                    break;
            }
            return false;
        }

        /// <summary>
        /// BFS로 미로가 탈출 가능한지 점검
        /// </summary>
        /// <returns>탈출 가능 여부</returns>
        bool CheckMzae()
        {
            bool goalBool = false, startBool = false;
            (int x, int y) goalPos = (0, 0), startPos = (0, 0);

            for(int y = 0; y < size; y++)
            {
                for(int x = 0; x < size; x++)
                {
                    if (maze[y, x] == Tile.Start)
                    {
                        if (startBool)
                            return false;
                        startBool = true;
                        goalPos = (y, x);
                    }
                    if (maze[y, x] == Tile.Goal)
                    {
                        if (goalBool)
                            return false;
                        goalBool = true;
                        startPos = (y, x);
                    }
                }
            }
            if (!goalBool || !startBool)
                return false;


            bool[,] visited = new bool[size, size];

            for (int y = 0; y < size; y++)
            {
                for(int x = 0; x < size; x++)
                {
                    if (maze[y,x] == Tile.Wall)
                    {
                        visited[y,x] = true;
                    }
                }
            }

            Queue<(int x, int y)> bfsQueue = new Queue<(int x, int y)>();

            bfsQueue.Enqueue(startPos);

            while (bfsQueue.Count > 0)
            {
                (int x, int y) next = bfsQueue.Dequeue();
                visited[next.y, next.x] = true;
                if(next == goalPos)
                {
                    return true;
                }

                for (int i = -1; i < 2; i++)
                {
                    for (int j = -1; j < 2; j++)
                    {
                        if (next.y + i >= 0 && next.y + i < size && next.x + j >= 0 && next.x + j < size)
                        {
                            if (!visited[next.y + i, next.x + j])
                            {
                                bfsQueue.Enqueue((next.x + j, next.y + i));
                            }
                        }
                    }
                }
            }

            return false;
        }
    }
}
