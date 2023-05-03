namespace MazeRunner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Maze mz = new Maze();
            mz.MakeMaze();
            mz.RunMaze();
        }
    }
}