namespace _13.Additional
{
    internal class Program
    {
        static void AdditionalMain(string[] args)
        {
            Additional additional = new();
            additional.Test();
            Partial partial = new();
            partial.Test();
        }
    }
}