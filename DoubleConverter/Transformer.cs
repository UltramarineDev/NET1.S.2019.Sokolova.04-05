using System;
using System.Globalization;

namespace DoubleConverter
{
    /// <summary>
    /// Transformer class
    /// </summary>
    public static class Transformer
    {
        /// <summary>
        /// Transform input double to their written numbers
        /// </summary>
        /// <param name="number">input double</param>
        /// <returns>string of written digits</returns>
        public static string TransformToWords(double number)
        {
            string[] writtenDigits = new string[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            string resultString = string.Empty;
            string numberString = number.ToString("G", CultureInfo.InvariantCulture);

            for (int i = 0; i < numberString.Length; i++)
            {
                if (numberString[i].Equals('-'))
                {
                    resultString += "minus" + " ";
                    continue;
                }

                if (numberString[i].Equals('.'))
                {
                    resultString += "point" + " ";
                    continue;
                }

                resultString += writtenDigits[(int)char.GetNumericValue(numberString[i])] + " ";
            }

            return resultString.Trim();
        }
    }
}
