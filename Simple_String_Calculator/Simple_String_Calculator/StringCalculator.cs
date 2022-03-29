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
        public static Nullable<int> nullValue = null;

        public int Add(string numbers)
        {
            try
            {
                sum = 0;
                if (string.IsNullOrEmpty(numbers)) return sum;
                ConvertToIntegers(numbers);
                int[] ignoreBigNumbers = IgnoreBigNum();
                NegativeNumberCheck();
                if (negativeNumbers.Length == 0)
                {
                    foreach (var i in ignoreBigNumbers)
                    {
                        sum = sum + i;
                    }

                }
                else
                     throw new Exception();


                
                return sum;
            }
            catch {
                Console.WriteLine("Negative Not Allowed: " + string.Join(", ", negativeNumbers));
                return sum;
            }
                
            
        }
        private void NegativeNumberCheck() {
            negativeNumbers = iNumbers.Where(i=> i < 0).ToArray();
                   
        }
        private int[] IgnoreBigNum() {
            int [] nums = iNumbers.Where(i => i <1001 ).ToArray();
            return nums;
        }
        private void ConvertToIntegers(string numbers)
        {
            try
            {
                numbers = ExtractDelimiters(numbers);

                iNumbers = numbers.Split(delimiters, '\n')
                                    .Select(x =>
                                    {
                                        if (Int32.TryParse(x, out var num)) return num;
                                        else
                                            throw new Exception();

                                    })
                                    .ToArray();
            }
            catch {
                Console.WriteLine("Element is Not a Number");
            }
           
           
        }
        private string ExtractDelimiters(string numbers) {
            try
            {
                if (numbers.Length < 3 && numbers.StartsWith("//"))
                {
                    throw new Exception();

                }
                else
                {
                    delimiters = ',';
                    if (numbers.StartsWith("//"))
                    {
                        delimiters = numbers[2];
                        numbers = numbers.Substring(4);
                    }
                    return numbers;
                }
            }
            catch {
                   
                Console.WriteLine("Error You Does Not Enter Any Number");
                string zero = "0";
                return zero;
            }


        }
    }
}
