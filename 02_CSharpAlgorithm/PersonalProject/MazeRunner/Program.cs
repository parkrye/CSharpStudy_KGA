namespace MazeRunner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MazeGroup mazeGroup;
            if (new FileInfo("maze.dat").Exists)
                mazeGroup = DataManager.LoadFile();
            else
                mazeGroup = new MazeGroup();
            Maze maze = new Maze();
            maze.MakeMaze();
            mazeGroup.AddMaze(maze);
            DataManager.SaveFile(mazeGroup);
        }
    }
}