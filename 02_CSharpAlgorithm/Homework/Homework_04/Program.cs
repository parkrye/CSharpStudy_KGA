namespace Homework_04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 문제 1.
            Stack<int> stack = new Stack<int>();
            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < 7; i++) 
            { 
                stack.Push(i);
                queue.Enqueue(i);
            }

            Console.WriteLine($"Stack Peek : {stack.Peek()}");
            Console.WriteLine($"Queue Peek : {queue.Peek()}");

            for (int i = 0; i < 3; i++) 
            {
               Console.WriteLine($"Stack Pop : {stack.Pop()}");
                Console.WriteLine($"Queue Enqueue : {queue.Dequeue()}");
            }

            for (int i = 7; i < 12; i++)
            {
                stack.Push(i);
                queue.Enqueue(i);
            }

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Stack Pop : {stack.Pop()}");
                Console.WriteLine($"Queue Dequeue : {queue.Dequeue()}");
            }
            Console.WriteLine();

            // 문제 2-1.
            BracketTest bracketTest = new BracketTest();
            bracketTest.StartTester();

            // 문제 2-2.
            Calculator calculator = new Calculator();
            calculator.StartCalculator();
        }
    }
}