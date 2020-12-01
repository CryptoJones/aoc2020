using System;

namespace d01
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args == null)
                Console.WriteLine("Enter filename to parse numbers!");
            else
                parseFile(args);
        }
        static void parseFile(string[] fileName)
        {
            // do something with file
        }
    }
}
