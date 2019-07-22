using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToWords
{
    class Program
    {
        /// <summary>
        /// The entry point for the application.
        /// </summary>
        /// <param name="args"> A list of arguments will be passed when starting this program</param>
        static void Main(string[] args)
        {
            string result = string.Empty;
            int number = 56945781; // Number to be converted

            try
            {
                // TODO: Covert the number to word format       
                result = ConvertNumberToWordsUpToMillions(number);
            }
            catch (Exception ex)
            {
                result = ex.Message + ex.InnerException + ex.StackTrace + ex.Source + ex.Data;
            }
            finally
            {
                Console.WriteLine("The result of {0} in word format is '{1}'.", number, result);
                Console.WriteLine(string.Empty);
                Console.WriteLine("Press any key to close this window.....");
                Console.Read();
            }
        }

        /// <summary>
        /// Converts the number to word format up to millions.i.e 999,999,999.
        /// </summary>
        /// <param name="number">Requires integer argument</param>
        /// <returns>Returns the integer argument in word format</returns>
        static string ConvertNumberToWordsUpToMillions(int number)
        {
            string words = string.Empty;

            try
            {
                if (number < -999999999 || number > 999999999)
                {
                    throw new NotSupportedException("Invalid number. The number allowed up to 999,999,999.");
                }

                if (number == 0) return "zero";
                if (number < 0) return "minus " + ConvertNumberToWordsUpToMillions(Math.Abs(number));

                if ((number / 1000000) > 0)
                {
                    words += ConvertNumberToWordsUpToMillions(number / 1000000) + " million ";
                    number %= 1000000;
                }
                if ((number / 1000) > 0)
                {
                    words += ConvertNumberToWordsUpToMillions(number / 1000) + " thousand ";
                    number %= 1000;
                }
                if ((number / 100) > 0)
                {
                    words += ConvertNumberToWordsUpToMillions(number / 100) + " hundred ";
                    number %= 100;
                }

                if (number > 0)
                {
                    if (words != "") words += "and ";

                    var unitsRange = new[]   
                    {  
                        "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"  
                    };
                    var tensRange = new[]   
                    {  
                        "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety"  
                    };

                    if (number < 20)
                    {
                        words += unitsRange[number];
                    }
                    else
                    {
                        words += tensRange[number / 10];
                        if ((number % 10) > 0)
                        {
                            words += " " + unitsRange[number % 10];
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
            return words;
        }
    }
}
