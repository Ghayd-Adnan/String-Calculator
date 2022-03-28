using System;

namespace Simple_String_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringCalculator str_cal = new StringCalculator();
            Console.WriteLine("The Result = " + str_cal.Add("//;\n2;5;7"));

           
        }
    }
}