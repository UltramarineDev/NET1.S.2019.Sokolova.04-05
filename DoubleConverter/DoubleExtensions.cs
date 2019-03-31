using System;
using System.Collections.Generic;

namespace DoubleConverter
{
    /// <summary>
    /// Double extensions class
    /// </summary>
    public static class DoubleExtensions
    {

        /// <summary>
        /// Extension method that check if the array is null
        /// </summary>
        /// <param name="arrayOfDouble">array of doubles</param>
        /// <returns>false if the input array is not null</returns>
        /// <exception cref="ArgumentNullException">Thrown when array is null</exception>
        public static bool IsNull(this double[] arrayOfDouble)
        {
            if (arrayOfDouble == null)
            {
                throw new ArgumentNullException(nameof(arrayOfDouble), "Array can not be null");
            }

            return false;
        }

        /// <summary>
        /// Extension method that check if the array is empty
        /// </summary>
        /// <param name="arrayOfDouble">array of doubles</param>
        /// <returns>false if the input array is not empty</returns>
        /// <exception cref="ArgumentException">Thrown when array is empty</exception>
        public static bool IsEmpty(this double[] arrayOfDouble)
        {
            if (arrayOfDouble.Length == 0)
            {
                throw new ArgumentException("Array can not be empty", nameof(arrayOfDouble));
            }

            return false;
        }

        /// <summary>
        /// Transform array of doubles to array of their written digits 
        /// </summary>
        /// <param name="arrayOfDouble">input array of doubles</param>
        /// <returns>array of strings</returns>
        public static string[] Transform(this double[] arrayOfDouble)
        {
            arrayOfDouble.IsNull();
            arrayOfDouble.IsEmpty();

            string[] arrayOfStrings = new string[arrayOfDouble.Length];

            for (int i = 0; i < arrayOfDouble.Length; i++)
            {
                arrayOfStrings[i] = Transformer.TransformToWords(arrayOfDouble[i]);
            }

            return arrayOfStrings;
        }

        /// <summary>
        /// Gets string of bits according to IEEE 754
        /// </summary>
        /// <param name="number">input number</param>
        /// <returns>string with number in binary format</returns>
        public static string GetIEEEBinaryString(this double number)
        {

            int sign = 0;
            if (number < 0)
            {
                sign = 1;
                number = -number;
            }

            var integerPart = (ulong)Math.Truncate(number);

            List<byte> bitsOfIntegerPart = ConvertToBits(integerPart);

            int exponent = 1023 + bitsOfIntegerPart.Count - 1;
            List<byte> bitsOfExponenta = ConvertToBits((ulong)exponent);

            int lenghtOfDouble = 63 - bitsOfExponenta.Count - (bitsOfIntegerPart.Count - 1);
            var doublePart = number - integerPart;
            List<byte> bitsOfMantissa = new List<byte>();

            for (int i = 0; i < lenghtOfDouble; i++)
            {
                doublePart = doublePart * 2;

                if ((ulong)Math.Truncate(doublePart) == 1)
                {
                    bitsOfMantissa.Add(1);
                    doublePart = doublePart - (ulong)Math.Truncate(doublePart);
                    continue;
                }

                bitsOfMantissa.Add(0);
            }

            string stringResult = sign.ToString();

            for (int i = 0; i < bitsOfExponenta.Count; i++)
            {
                stringResult += bitsOfExponenta[i].ToString();
            }

            for (int i = 1; i < bitsOfIntegerPart.Count; i++)
            {
                stringResult += bitsOfIntegerPart[i].ToString();
            }

            for (int i = 0; i < bitsOfMantissa.Count; i++)
            {
                stringResult += bitsOfMantissa[i].ToString();
            }

            return stringResult;
        }

        private static List<byte> ConvertToBits(ulong numberDivided)
        {
            List<byte> bits = new List<byte>();
            while (numberDivided > 0)
            {
                bits.Insert(0, (byte)((numberDivided) & 1));
                numberDivided = numberDivided >> 1;
            }
            return bits;
        }
    }
}
