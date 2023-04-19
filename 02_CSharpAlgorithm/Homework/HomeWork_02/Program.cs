namespace HomeWork_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyDataStructure.LinkedList<string> list = new MyDataStructure.LinkedList<string>();
            for(int i = 0; i < 5; i++) list.AddFirst($"{i + 1}번");
            for (int i = 5; i < 10; i++) list.AddLast($"{i + 1}번");
            Console.WriteLine(list.SpreadValues());
            list.RemoveFirst();
            list.RemoveLast();
            list.Remove("3번");
            Console.WriteLine(list.SpreadValues());
            Console.WriteLine(list.Find("2번").ITEM);
            Console.WriteLine(list.FindLast("2번").ITEM);
            Console.WriteLine(list.Contains("10번"));
            list.AddAfter(list.Find("2번"), "뒤");
            list.AddAfter(list.Find("2번"), new MyDataStructure.LinkedListNode<string>("앞"));
            Console.WriteLine(list.SpreadValues());
            string[] arr = new string[list.COUNT];
            list.CopyTo(arr);
            foreach (string s in arr) Console.Write(s + ", " );
            Console.WriteLine();
            list.Clear();
            for (int i = 0; i < 5; i++) list.AddFirst($"{i + 1}번");
            for (int i = 0; i < 5; i++) list.AddFirst($"{i + 1}번");
            Console.WriteLine(list.SpreadValues());
        }
    }
}