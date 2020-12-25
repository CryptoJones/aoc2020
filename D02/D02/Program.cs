using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace D02
{
    public class Program
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
            //Console.WriteLine("There were {0} instances of correct passwords for part one.", partOneValidPasswordCount(sb.ToString()).ToString());
            Console.WriteLine("There were {0} instances of correct passwords for part two.", partTwoValidPasswordCount(sb.ToString()).ToString());

        }

        public static int partOneValidPasswordCount(string fileName)
        {

            // Object to hold the lines of the file
            List<string> lineList = GetLineList(fileName);

            // object to hold elements from each line
            List<PairedValues> pairedValuesList = GetPairedValuesList(lineList);
            
            // object to hold the password records
            List<PasswordRecord> passwordRecords = GeneratePasswordRecords(pairedValuesList);

            // return result
            return countValidPasswords(passwordRecords);
        }

        public static int partTwoValidPasswordCount(string fileName)
        {

            // Object to hold the lines of the file
            List<string> lineList = GetLineList(fileName);

            // object to hold elements from each line
            List<PairedValues> pairedValuesList = GetPairedValuesList(lineList);

            // object to hold the password records
            List<PasswordRecord> passwordRecords = GeneratePasswordRecords(pairedValuesList);

            // return result
            return CountActualValidPasswords(passwordRecords);
        }

        private static int CountActualValidPasswords(List<PasswordRecord> passwordRecords)
        {
            int count = 0;

            foreach (PasswordRecord pr in passwordRecords)
            {
                if ((pr.Password[pr.MinValue - 1] == pr.LetterRequired) || (pr.Password[pr.MaxValue -1] == pr.LetterRequired))
                {
                    if ((pr.Password[pr.MinValue - 1] == pr.LetterRequired) &
                        (pr.Password[pr.MaxValue - 1] == pr.LetterRequired))
                    {

                    }
                    else
                    {
                        count++;

                    }
                    Console.WriteLine(string.Format("{0}, {1}, {2}, {3}", pr.MinValue, pr.MaxValue, pr.LetterRequired, pr.Password));

                }

            }

            return count;
        }

        private static int countValidPasswords(List<PasswordRecord> passwordRecords)
        {
            int count = 0;
            
            foreach (PasswordRecord pr in passwordRecords)
            {
                int letterCount = pr.Password.Split(pr.LetterRequired).Length - 1;
                if ((letterCount <= pr.MaxValue) & (letterCount >= pr.MinValue))
                {
                    count++;
                } 
                
                // Console.WriteLine(string.Format("{0}, {1}, {2}, {3}", pr.MinValue, pr.MaxValue, pr.LetterRequired, pr.Password));
            }

            return count;
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

        private static List<PairedValues> GetPairedValuesList(List<String> lineList)
        {
            List<PairedValues> pairedValuesList = new List<PairedValues>();

            // Gets each element and put it in a "per-line" object
            for (int i = 0; i <= lineList.Count -1; i++)
            {
                string[] subs = lineList[i].ToString().Split(' ');
                PairedValues pv = new PairedValues(subs[0], subs[1], subs[2]);
                pairedValuesList.Add(pv);
            }

            return pairedValuesList;
        }

        private static List<PasswordRecord> GeneratePasswordRecords(List<PairedValues> pairedValuesList)
        {
            List<PasswordRecord> passwordRecords = new List<PasswordRecord>();

            // puts each element in to a password record
            for (int i = 0; i <= pairedValuesList.Count - 1; i++)
            {
                int minValue = 0;
                int maxValue = 0;

                string[] numbers = pairedValuesList[i].value1.Split("-");
                char letterRequired = pairedValuesList[i].value2[0];
                string password = pairedValuesList[i].value3;

                minValue = Int32.Parse(numbers[0]);
                maxValue = Int32.Parse(numbers[1]);

                PasswordRecord pr = new PasswordRecord(minValue, maxValue, letterRequired, password);
                passwordRecords.Add(pr);
            }
            
            return passwordRecords;
        }
    }
}
