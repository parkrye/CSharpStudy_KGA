namespace Homework_06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();

            bst.Add(3);
            bst.Add(1);
            bst.Add(5);
            bst.Add(2);
            bst.Add(4);
            bst.Add(6);

            bst.Remove(3);
            bst.Remove(4);

            bst.Print();
        }
    }
}