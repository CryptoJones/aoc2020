using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters;
using System.Text;

namespace d01
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            if (args == null)
                Console.WriteLine("Enter filename to parse numbers!");
            else
                foreach (string value in args)
                {
                    sb.Append(value);
                }
                partOneParseFile(sb.ToString());
                partTwoParseFile(sb.ToString());
                
        }
        static void partOneParseFile(string fileName)
        {
            List<int> intList = new List<int>();
            
            int lineCounter = 0;
            string line;
            
            

            System.IO.StreamReader file = new System.IO.StreamReader(fileName);
            while ((line = file.ReadLine()) != null)
            {
                intList.Add(Int32.Parse(line));
                lineCounter++;
            }

            file.Close();

            for (int i = 1; i < lineCounter + 1; i++)
            {
                for (int j = lineCounter; j > 0; j--)
                {
                    Console.WriteLine(string.Format("Values for i and j are {0} and {1}.", intList[i -1].ToString(), intList[j - 1].ToString()));
                    if (intList[i - 1] + intList[j - 1] == 2020)
                    {
                        Console.WriteLine((intList[i - 1] * intList[j - 1]));
                        Console.ReadLine();
                    }
                }

            }
        }

        static void partTwoParseFile(String fileName)
        {
            List<int> intList = new List<int>();

            int lineCounter = 0;
            string line;



            System.IO.StreamReader file = new System.IO.StreamReader(fileName);
            while ((line = file.ReadLine()) != null)
            {
                intList.Add(Int32.Parse(line));
                lineCounter++;
            }

            file.Close();

            for (int i = 1; i < lineCounter + 1; i++)
            {
                for (int j = lineCounter; j > 0; j--)
                {
                    for (int k = 1; k < lineCounter + 1; k++)
                    {
                        Console.WriteLine(string.Format("Values for i, j, and k are {0}, {1} and {2}.", intList[i - 1].ToString(), intList[j - 1].ToString(), intList[k - 1].ToString()));
                        if (intList[i - 1] + intList[j - 1] + intList[k - 1] == 2020)
                        {
                            Console.WriteLine((intList[i - 1] * intList[j - 1] * intList[k -1]));
                            Console.ReadLine();
                        }
                    }

                }

            }
        }
    }
}
