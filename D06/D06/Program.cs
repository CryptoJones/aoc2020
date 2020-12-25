using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Text;

namespace D06
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            if (args == null || !(args.Length > 0))
                Console.WriteLine("Enter filename to parse numbers!");
            else
                foreach (string value in args)
                {
                    sb.Append(value);
                }

            Console.WriteLine("{0} yes answers were found for part one", DaySixPartOne(sb.ToString()));;
            Console.ReadLine();
        }

        private static int DaySixPartOne(string fileName)
        {
            int result = 0;
            
            List<string> lineList = GetLineList(fileName);

            result = CountYesAnswersPartOne(lineList);
            
            return result;

        }

        private static int CountYesAnswersPartOne(List<string> lineList)
        {
            int lineCount = lineList.Count;
            int result = 0;
            foreach (string s in lineList)
            {
                //Console.WriteLine("Line {0} being read", s);
                //string letters = "abcdefghijklmnopqrstuvwxyz";
                //int internalCounter = 0;

                //    for (int j = 0; j < 26; j++)
                //    {
                //        if (s.Contains(letters[j]))
                //        {
                //            internalCounter++;
                //        }
                //    }
                if (s.Length > 0)
                {
                    result++;
                }

               
            }

            return result;
        }

        private static List<string> GetLineList(string fileName)
        {
            // file processing / control stuff
            List<string> lineList = new List<string>();
            int lineListCounter = 0;
            string line;

            // read the file
            System.IO.StreamReader file = new System.IO.StreamReader(fileName);
            while ((line = file.ReadLine()) != null)
            {
                lineList.Add((line));
                lineListCounter++;
            }

            return lineList;
        }
    }
}
