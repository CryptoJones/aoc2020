using System;
using System.Collections.Generic;
using System.Text;

namespace D02
{
    public class PasswordRecord
    {
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
        public char LetterRequired { get; set; }
        public string Password { get; set; }

        public PasswordRecord(int minValue, int maxValue, char letterRequired, string password)
        {
            MinValue = minValue;
            MaxValue = maxValue;
            LetterRequired = letterRequired;
            Password = password;

        }
    }
}
