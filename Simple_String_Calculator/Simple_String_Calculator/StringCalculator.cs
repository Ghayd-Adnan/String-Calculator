using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Simple_String_Calculator
{
    internal class StringCalculator
    {
        public int[] iNumbers { get; set; }
        public int[] negativeNumbers { get; set; }
        public int sum;
        public char delimiters;
       


        public int Add(string numbers)
        {
            sum = 0;
            if (string.IsNullOrEmpty(numbers)) return sum;
            ConvertToIntegers(numbers);
            NegativeNumberCheck();
            if (negativeNumbers.Length ==0 ) {
                foreach (var i in IgnoreBigNum())
                {
                    sum = sum + i;
                }
                
            }
            else {
               
                string msg= "Negative Not Allowed: "+ string.Join(", ",negativeNumbers);
                throw new Exception (msg);

            }
            return sum;

        }
        public void NegativeNumberCheck() {
            negativeNumbers = iNumbers.Where(i=> i < 0).ToArray();
                   
        }
        public int[] IgnoreBigNum() {
            int [] nums = iNumbers.Where(i => i <1001 ).ToArray();
            return nums;
        }
        public void ConvertToIntegers(string numbers) {
            numbers = Delimiters(numbers);
            iNumbers = numbers.Split(delimiters, '\n')
                            .Select(x => {
                                if (Int32.TryParse(x, out var num)) return num;
                                else
                                    throw new Exception("Element is Not a Number");
                                    
                            })
                            .ToArray();

            
        }
        public string Delimiters(string numbers) {
            delimiters = ',';
            if (numbers.StartsWith("//")) {
                delimiters = numbers[2];
                numbers = numbers.Substring(4);
            }
          return numbers;
        
        }
    }
}
