using System;

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
    }
}
