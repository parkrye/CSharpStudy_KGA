using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeRunner
{
    [Serializable]
    internal class MazeGroup
    {
        List<Maze> mazeList;

        public int Count { get {  return mazeList.Count; } }

        public Maze this[int index] 
        { 
            get
            {
                if (CorrectIndex(index))
                {
                    CorrectIndex(index);
                    return mazeList[index];
                }
                return null;
            } 
        }

        public MazeGroup()
        {
            mazeList = new List<Maze>();
        }

        public bool AddMaze(Maze maze)
        {
            mazeList.Add(maze);
            return true;
        }

        public bool RemoveMaze(int index)
        {
            if (CorrectIndex(index))
            {
                mazeList.RemoveAt(index);
                return true;
            }
            return false;
        }

        bool CorrectIndex(int index)
        {
            if (index < 0 || index >= mazeList.Count)
                return false;
            return true;
        }
    }
}
