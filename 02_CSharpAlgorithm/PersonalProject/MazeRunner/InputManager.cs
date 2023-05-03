namespace MazeRunner
{
    public enum Key { None, Left, Right, Up, Down, Enter, Space, Cancel };

    internal static class InputManager
    {
        static bool inputProcess = false;

        /// <summary>
        /// 키 입력을 열거형 키로 반환하는 메소드
        /// </summary>
        /// <returns>열거형 키</returns>
        public static Key GetInput()
        {
            if (!inputProcess)
            {
                inputProcess = true;
                ConsoleKey inputKey = Console.ReadKey().Key;
                Key key;

                switch (inputKey)
                {
                    default:
                        key = Key.None;
                        break;
                    case ConsoleKey.LeftArrow:
                        key = Key.Left;
                        break;
                    case ConsoleKey.RightArrow:
                        key = Key.Right;
                        break;
                    case ConsoleKey.UpArrow:
                        key = Key.Up;
                        break;
                    case ConsoleKey.DownArrow:
                        key = Key.Down;
                        break;
                    case ConsoleKey.Enter:
                        key = Key.Enter;
                        break;
                    case ConsoleKey.Spacebar:
                        key = Key.Space;
                        break;
                    case ConsoleKey.Backspace:
                        key = Key.Cancel;
                        break;
                }
                inputProcess = false;
                return key;
            }
            else
            {
                return Key.None;
            }
        }
    }
}
