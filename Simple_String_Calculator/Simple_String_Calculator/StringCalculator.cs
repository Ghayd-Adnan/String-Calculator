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
            if (string.IsNullOrWhiteSpace(numbers)) return sum;
            iNumbers = ConvertToIntegers(numbers);
            foreach (var i in iNumbers)
            {
                sum = sum + i;  
            }
            return sum;
        }
        public int[] ConvertToIntegers(string numbers)
        {
           iNumbers = numbers.Split(',','\n')
                             .Select(x => { if (Int32.TryParse(x, out var num)) return num;
                                 else
                                     throw new Exception("Element is Not a Number");
                             }
                             
                             )
                             .ToArray();
            
            return iNumbers;
        }
    }
}
