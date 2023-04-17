namespace Programming
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* 
             * Console
             * 콘솔 프로그램(텍스트 형태로 입출력을 진행하는 프로그램)
             * Console.WriteLine: 콘솔에 출력하고 줄을 바꿈
             * Console.Write: 콘솔에 출력하고 줄을 바꾸지 않음
             * Console.ReadLine: 콘솔을 통해 한줄을 입력받음
             * Console.Read: 콘솔을 통해 한글자를 입력받음
             * Console.ReadKey: 콘솔을 통해 키를 입력받음
             */

            /*
            Console.WriteLine("Hello, World!");
            */

            /*
            Console.Write("Input Line: ");
            Console.ReadLine();
            Console.WriteLine("Input Completed");
            */

            /*
            Console.Write("Input Key: ");
            Console.ReadKey();
            Console.WriteLine("Input Completed");
            */

            /*
            Console.Write("Select Job: ");
            string job = Console.ReadLine();
            Console.WriteLine("You Select : " + job);
            */

            Program program = new();
            program.Play();
        }

        private int count;

        private void Play()
        {
            Console.Write("input number: ");
            string s = "" + Console.ReadLine();
            Console.WriteLine("");
            int num = int.Parse(s);
            if (num < 1) num = 1;
            int[] board = new int[num];
            count = 0;

            Do(board, 0);
            Console.WriteLine("Total : " + count);
        }

        private void Do(int[] board, int num)
        {
            if (num == board.Length)
            {
                Draw(board);
                return;
            }

            for (int i = 0; i < board.Length; i++)
            {
                bool go = true;
                for (int j = 0; j < num; j++)
                {
                    if (board[j] == i) go = false;
                    if (board[j] + num == i + j) go = false;
                    if (board[j] - num == i - j) go = false;
                }
                if (go)
                {
                    board[num] = i;
                    Do(board, num + 1);
                }
            }
        }

        private void Draw(int[] board)
        {
            count++;
            foreach (int i in board)
            {
                for (int j = 0; j < board.Length; j++)
                {
                    if (i == j) Console.Write("■");
                    else Console.Write("□");
                }
                Console.WriteLine("");
            }
            Console.WriteLine("");
        }
    }
}