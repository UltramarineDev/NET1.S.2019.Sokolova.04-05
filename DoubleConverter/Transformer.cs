using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

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
            Dictionary<char, string> dictionary = GetDictionary();

            if (double.IsInfinity(number))
            {
                return "number is infinity";
            }

            if (double.IsNaN(number))
            {
                return "not a number";
            }

            string numberString = number.ToString("G", CultureInfo.InvariantCulture);

            var resultString = new StringBuilder();

            foreach (var symbol in numberString)
            {
                resultString.Append($"{dictionary[symbol]} ");
            }

            return resultString.ToString().Trim();
        }

        private static Dictionary<char, string> GetDictionary()
            => new Dictionary<char, string>
            {
                ['0'] = "zero",
                ['1'] = "one",
                ['2'] = "two",
                ['3'] = "three",
                ['4'] = "four",
                ['5'] = "five",
                ['6'] = "six",
                ['7'] = "seven",
                ['8'] = "eight",
                ['9'] = "nine",
                ['+'] = "plus",
                ['-'] = "minus",
                ['.'] = "point",
                ['e'] = "exponent"
            };
    }
}
