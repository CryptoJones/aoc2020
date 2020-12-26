using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Globalization;
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
            int result = 0;
            List<List<string>> groups = new List<List<string>>();
            List<string> buffer = new List<string>();
            buffer.Clear();
            
            foreach (string s in lineList)
            {

                if (!string.IsNullOrEmpty(s))
                {
                    buffer.Add(s);
                }
                else
                {
                    groups.Add(buffer);
                    buffer.Clear();
                   
                }
               
            }

            int groupCount = groups.Count;

            foreach (List<string> g in groups)
            {
                List<char> lettersFound = new List<char>();
                string letters = "abcdefghijklmnopqrstuvwxyz";
                
                for (int i = 0; i < g.Count; i++)
                {
                    for (int j = 0; j < letters.Length; j++)
                        if (g[i].Contains(letters[j]))
                        {
                            if (!lettersFound.Contains(letters[j]))
                            {
                                lettersFound.Add(letters[j]);
                            }
                           
                        }
                }

                result = result + lettersFound.Count;
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
