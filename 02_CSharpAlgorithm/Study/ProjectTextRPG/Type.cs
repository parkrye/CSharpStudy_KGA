namespace ProjectTextRPG
{
    public enum SceneCate { Main, Map, Inve, Batt }

    public enum Direction { Left, Right, Up, Down }

    public struct Position
    {
        public int x;
        public int y;

        public Position(int _x, int _y)
        {
            x = _x;
            y = _y;
        }
    }
}
