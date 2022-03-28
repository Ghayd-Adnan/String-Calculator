using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Simple_String_Calculator
{
    internal class StringCalculator
    {
        public int[] iNumbers { get; set; }
        public int sum;

        public int Add(string numbers)
        {
            sum = 0;
            if (string.IsNullOrEmpty(numbers)) return sum;
            iNumbers = ConvertToIntegers(numbers);
            foreach (var i in iNumbers)
            {
                sum = sum + i;  
            }
            return sum;
        }
        public int[] ConvertToIntegers(string numbers)
        {
            string[] str_num = numbers.Split(',', '\n').ToArray();
            int[] int_num = Array.ConvertAll(str_num, Int32.Parse);
            return int_num;
        }
    }
}
