using System;

namespace DoubleConverter
{
    /// <summary>
    /// Class for working with polynomials
    /// </summary>
    public class Polynomial
    {
        private readonly double[] coefficients = { };

        /// <summary>
        /// Initializes a new instance of the Polynomial class
        /// </summary>
        /// <param name="coefficients">array of coefficients</param>
        /// <exception cref="ArgumentNullException">Thrown when the array is null</exception>
        /// <exception cref="ArgumentException">Thrown when the array is empty</exception>
        public Polynomial(params double[] coefficients)
        {
            if (coefficients == null)
            {
                throw new ArgumentNullException("Input array of coefficients can not be null", nameof(coefficients));
            }

            if (coefficients.Length == 0)
            {
                throw new ArgumentException("Input array of coefficients can not be empty", nameof(coefficients));
            }

            this.coefficients = coefficients;
        }

        /// <summary>
        /// Gets array of coefficients
        /// </summary>
        public double[] Coefficients
        {
            get
            {
                return this.coefficients;
            }
        }

        private double this[int n]
        {
            get { return this.coefficients[n]; }
            set { this.coefficients[n] = value; }
        }

        /// <summary>
        /// Method overrides operator * - multiplication by given number
        /// </summary>
        /// <param name="polynomial">input instance with type Polynomial</param>
        /// <param name="number">input number with type double</param>
        /// <returns>the multiplication of each coefficient by given number</returns>
        public static Polynomial operator *(Polynomial polynomial, double number)
        {
            var polynomialAfterMultiplication = new Polynomial(polynomial.coefficients);

            for (int i = 0; i < polynomialAfterMultiplication.coefficients.Length; i++)
            {
                polynomialAfterMultiplication.coefficients[i] *= number;
            }

            return polynomialAfterMultiplication;
        }

        /// <summary>
        /// Method overrides operator / - division by given number
        /// </summary>
        /// <param name="polynomial">input instance with type Polynomial</param>
        /// <param name="number">input number with type double</param>
        /// <returns>the division of each coefficient by given number</returns>
        /// <exception cref="ArgumentException">Thrown when input number equals zero</exception>
        public static Polynomial operator /(Polynomial polynomial, double number)
        {
            if (number == 0)
            {
                throw new ArgumentException("Input number can not be zero", nameof(number));
            }

            var polynomialAfterMultiplication = new Polynomial(polynomial.coefficients);

            for (int i = 0; i < polynomialAfterMultiplication.coefficients.Length; i++)
            {
                polynomialAfterMultiplication.coefficients[i] /= number;
            }

            return polynomialAfterMultiplication;
        }

        /// <summary>
        /// Method overrides operator * - addition instance by instance
        /// </summary>
        /// <param name="polynomialFirst">first instance with type Polynomial</param>
        /// <param name="polynomialSecond">second instance with type Polynomial</param>
        /// <returns>the result of addition</returns>
        public static Polynomial operator +(Polynomial polynomialFirst, Polynomial polynomialSecond)
        {
            int maxLenght = Math.Max(polynomialFirst.coefficients.Length, polynomialSecond.coefficients.Length);

            var polynomialAfterAddition = new Polynomial(new double[maxLenght]);

            for (int i = 0; i < polynomialAfterAddition.coefficients.Length; i++)
            {
                double firstTemp = 0;
                double secondTemp = 0;

                if (i < polynomialFirst.coefficients.Length)
                {
                    firstTemp = polynomialFirst[i];
                }

                if (i < polynomialSecond.coefficients.Length)
                {
                    secondTemp = polynomialSecond[i];
                }

                polynomialAfterAddition[i] = firstTemp + secondTemp;
            }

            return polynomialAfterAddition;
        }

        /// <summary>
        /// Method overrides operator * - multiplication instance by instance
        /// </summary>
        /// <param name="polynomialFirst">first instance with type Polynomial</param>
        /// <param name="polynomialSecond">second instance with type Polynomial</param>
        /// <returns>the result of multiplication</returns>
        public static Polynomial operator *(Polynomial polynomialFirst, Polynomial polynomialSecond)
        {
            var polymonAfterMultiplication = new Polynomial(new double[polynomialFirst.coefficients.Length + polynomialSecond.coefficients.Length - 1]);

            for (int i = 0; i < polynomialFirst.coefficients.Length; i++)
            {
                for (int j = 0; j < polynomialSecond.coefficients.Length; j++)
                {
                    polymonAfterMultiplication[i + j] += polynomialFirst[i] * polynomialSecond[j];
                }
            }

            return polymonAfterMultiplication;
        }

        /// <summary>
        /// Method overrides operator == (equality)
        /// </summary>
        /// <param name="polynomialFirst">first instance with type Polynomial</param>
        /// <param name="polynomialSecond">second instance with type Polynomial</param>
        /// <returns>true if operands of the method are equal, false otherwise</returns>
        public static bool operator ==(Polynomial polynomialFirst, Polynomial polynomialSecond)
        {
            if (polynomialFirst.Equals(polynomialSecond))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Method overrides operator != (inequality)
        /// </summary>
        /// <param name="polynomialFirst">first instance with type Polynomia</param>
        /// <param name="polynomialSecond">second instance with type Polynomial</param>
        /// <returns></returns>
        public static bool operator !=(Polynomial polynomialFirst, Polynomial polynomialSecond)
        {
            if (!polynomialFirst.Equals(polynomialSecond))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Method overrides virtual method ToString()
        /// </summary>
        /// <returns>string that represents polynomial with input coefficients</returns>
        public override string ToString()
        {
            string polynomString = $"{coefficients[0]}";
            for (int i = 1; i < this.coefficients.Length; i++)
            {
                polynomString += $" + ({coefficients[i]})*x^{i}";
            }

            return polynomString;
        }

        /// <summary>
        /// Method overrides virtual method Equals()
        /// </summary>
        /// <param name="polynomial">polynomial instance</param>
        /// <returns>true if each coefficient of given instance equals appropriate coefficient of current instance</returns>
        public override bool Equals(object polynomial)
        {
            if (this.GetHashCode() != polynomial.GetHashCode())
            {
                return false;
            }

            for (int i = 0; i < this.coefficients.Length; i++)
            {
                if (this.coefficients[i] != ((Polynomial)polynomial).coefficients[i])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Method overrides virtual method GetHashCode()
        /// </summary>
        /// <returns>code that corresponds to sum of coefficients</returns>
        public override int GetHashCode()
        {
            double code = this.coefficients[0];
            for (int i = 1; i < this.coefficients.Length; i++)
            {
                code += this.coefficients[i];
            }

            return (int)code;
        }
    }
}
