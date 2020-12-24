using System;
using System.Collections.Generic;
using System.Text;

namespace D02
{
    public class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            if (args == null || args)
                Console.WriteLine("Enter filename to parse numbers!");
            else
                foreach (string value in args)
                {
                    sb.Append(value);
                }
            partOneValidPasswordCount(sb.ToString());
            //partTwoParseFile(sb.ToString());
        }

        public static int partOneValidPasswordCount(string fileName)
        {
            // Method Stuff
            int result = 0;
            

            // File Processing
            List<string> lineList = new List<string>();
            int lineListCounter = 0;
            string line;

            System.IO.StreamReader file = new System.IO.StreamReader(fileName);
            while ((line = file.ReadLine()) != null)
            {
                lineList.Add((line));
                lineListCounter++;
            }

            List<PairedValues> elements = new List<PairedValues>();

            for(int i = 0; i < lineList.Count +1; i++){
                string[] subs = lineList[i].ToString().Split(' ');
                PairedValues pv = new PairedValues(subs[0], subs[1], subs[2]);
                elements.Add(pv);
            }


            return result;
        }
    }
}
