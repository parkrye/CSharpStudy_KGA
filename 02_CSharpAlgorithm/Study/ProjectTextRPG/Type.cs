namespace ProjectTextRPG
{
    public enum SceneCate { Main, Map, Inve, Batt, Shop }

    public enum Direction { Left, Right, Up, Down }

    public enum DeadCause { Debug, Beat, Melt, Starve, Burn, Tear, Eat, Posion }

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
