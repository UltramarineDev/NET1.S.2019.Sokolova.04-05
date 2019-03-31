using System;
using NUnit.Framework;
using DoubleConverter;

namespace DoubleConverter.Tests
{
    public class PolynomialTests
    {
        [TestCase(new double[] { -5, 0, 123, 6.45, 9, -9.9675, -21, 43.9 }, ExpectedResult =
            "-5 + (0)*x^1 + (123)*x^2 + (6,45)*x^3 + (9)*x^4 + (-9,9675)*x^5 + (-21)*x^6 + (43,9)*x^7")]
        [TestCase(new double[] { 0, 8, 6, 0 }, ExpectedResult = "0 + (8)*x^1 + (6)*x^2 + (0)*x^3")]
        [TestCase(new double[] { 0 }, ExpectedResult = "0")]
        [TestCase(new double[] { 9, -8.76532, 0.000008 }, ExpectedResult = "9 + (-8,76532)*x^1 + (8E-06)*x^2")]
        public string ToStringTests(double[] coefficients)
        {
            Polynomial polynomial = new Polynomial(coefficients);
            return polynomial.ToString();
        }

        [TestCase(new double[] { 9, 0, -9.876, -0.9, 7, 30000, -0.00008 }, new double[] { 9, 0, -9.876, -0.9, 7, 30000, -0.00008 }, ExpectedResult = true)]
        [TestCase(new double[] { 9, 1, 3, -9.542 }, new double[] { 9, 1, 3 }, ExpectedResult = false)]
        [TestCase(new double[] { 0 }, new double[] { 0 }, ExpectedResult = true)]
        [TestCase(new double[] { 1, 1, 1, 1 }, new double[] { 2, 2 }, ExpectedResult = false)]
        public bool EqualsTests(double[] firstInstanceCoefficients, double[] secondInstanceCoefficients)
        {
            Polynomial polynomialFirst = new Polynomial(firstInstanceCoefficients);
            Polynomial polynomialSecond = new Polynomial(secondInstanceCoefficients);
            return polynomialFirst.Equals(polynomialSecond);
        }

        [TestCase(new double[] { 9, 7, 0.0008, 4, 1 }, ExpectedResult = 21)]
        [TestCase(new double[] { -9.432, 0.098, 4, 10000 }, ExpectedResult = 9994)]
        [TestCase(new double[] { 9765, -0.8765, 1, 234, 765 }, ExpectedResult = 10764)]
        public int GetHashCodeTests(double[] coefficiens)
        {
            Polynomial polynomial = new Polynomial(coefficiens);
            return polynomial.GetHashCode();
        }

        public void OverrideOperatorMultiplyByNumberTests_MultiplyByZero_NewInstance()
        {
            Polynomial polynomialFirst = new Polynomial(new double[] { -5, 0, 123, 6.45, 9, -9.9675, -21, 43.9 });
            Polynomial expected = new Polynomial(new double[] { 0, 0, 0, 0, 0, 0, 0, 0 });
            Polynomial actual = polynomialFirst * 0.0;
            Assert.IsTrue(expected.Equals(actual));
        }

        public void OverrideOperatorMultiplyByNumberTests_MultiplyByPositiveDouble_NewInstance()
        {
            Polynomial polynomialFirst = new Polynomial(new double[] { 1, 1, 1, 1, 3, -9, 87.8 });
            Polynomial expected = new Polynomial(new double[] { 0.1, 0.1, 0.1, 0.1, 0.3, -0.9, 8.78 });
            Polynomial actual = polynomialFirst * 0.1;
            Assert.IsTrue(expected.Equals(actual));
        }

        public void OverrideOperatorMultiplyByNumberTests_MultiplyByNegativeDouble_NewInstance()
        {
            Polynomial polynomialFirst = new Polynomial(new double[] { 0, -5, 123, -9, 6.43 });
            Polynomial expected = new Polynomial(new double[] { 0, 0.25, -6.15, 0.45, -0.3215 });
            Polynomial actual = polynomialFirst * (-0.05);
            Assert.IsTrue(expected.Equals(actual));
        }

        [Test]
        public void Polynomial_ArrayIsNull_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new Polynomial(null));
        }

        [Test]
        public void Polynomial_ArrayIsEmpty_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Polynomial(new double[] { }));
        }
    }
}
