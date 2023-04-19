namespace Homerwork_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyDataStructure.List<int> list = new MyDataStructure.List<int>();
            for (int i = 0; i < 20; i++) 
                list.Add(i);
            list.Reverse();
            list.Sort();
        }
    }
}