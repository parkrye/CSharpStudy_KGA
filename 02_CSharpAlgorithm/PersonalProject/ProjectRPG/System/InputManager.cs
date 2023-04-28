namespace ProjectRPG
{
    public enum Key { NONE, LEFT, RIGHT, UP, DOWN, ENTER, CANEL };

    internal static class InputManager
    {
        /// <summary>
        /// 키 입력을 열거형 키로 반환하는 메소드
        /// </summary>
        /// <returns>열거형 키</returns>
        public static Key GetInput()
        {
            ConsoleKey inputKey = Console.ReadKey().Key;
            Key key;

            switch (inputKey)
            {
                default:
                    key = Key.NONE;
                    break;
                case ConsoleKey.LeftArrow:
                    key = Key.LEFT;
                    break;
                case ConsoleKey.RightArrow:
                    key = Key.RIGHT;
                    break;
                case ConsoleKey.UpArrow:
                    key = Key.UP;
                    break;
                case ConsoleKey.DownArrow:
                    key = Key.DOWN;
                    break;
                case ConsoleKey.Enter:
                case ConsoleKey.Spacebar:
                    key = Key.ENTER;
                    break;
                case ConsoleKey.Backspace:
                    key = Key.CANEL;
                    break;
            }

            return key;
        }
    }
}
