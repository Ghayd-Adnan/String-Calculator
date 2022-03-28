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
        public char delimiters;


        public int Add(string numbers)
        {
            sum = 0;
            if (string.IsNullOrEmpty(numbers)) return sum;
            ConvertToIntegers(numbers);
            foreach (var i in iNumbers)
            {
                sum = sum + i;  
            }
            return sum;
        }
        public void ConvertToIntegers(string numbers) {
            numbers = DelimitersCheck(numbers);
            iNumbers = numbers.Split(delimiters, '\n')
                            .Select(x => {
                                if (Int32.TryParse(x, out var num)) return num;
                                else
                                    throw new Exception("Element is Not a Number");
                            })
                            .ToArray();

            
        }
        public string DelimitersCheck(string numbers) {
            delimiters = ',';
            if (numbers.StartsWith("//")) {
                delimiters = numbers[2];
                numbers = numbers.Substring(4);
            }
          return numbers;
        
        }
    }
}
