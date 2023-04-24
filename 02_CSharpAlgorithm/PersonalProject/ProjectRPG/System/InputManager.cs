﻿namespace ProjectRPG
{
    public enum Key { LEFT, RIGHT, UP, DOWN, ENTER, CANEL, NONE };

    internal static class InputManager
    {

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
                    key = Key.ENTER;
                    break;
                case ConsoleKey.Escape:
                    key = Key.CANEL;
                    break;
            }

            return key;
        }
    }
}