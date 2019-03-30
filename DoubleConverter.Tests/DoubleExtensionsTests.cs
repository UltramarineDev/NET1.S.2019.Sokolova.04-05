using System;
using NUnit.Framework;

namespace DoubleConverter.Tests
{
    public class DoubleExtensionsTests
    {
        [TestCase(new double[] { -87, 0.98, 0, 65, -9.7, 6 }, ExpectedResult = new string[] { "minus eight seven", "zero point nine eight", "zero", "six five", "minus nine point seven", "six" })]
        [TestCase(new double[] { 0 }, ExpectedResult = new string[] { "zero" })]
        [TestCase(new double[] { 0.34, 1, -9, 0.9001, 0.0003 }, ExpectedResult = new string[] { "zero point three four", "one", "minus nine", "zero point nine zero zero one", "zero point zero zero zero three" })]
        [TestCase(new double[] { 0, -0.09, 0.0005, -0.009, 98, 0, -1 }, ExpectedResult = new string[] { "zero", "minus zero point zero nine", "zero point zero zero zero five", "minus zero point zero zero nine", "nine eight", "zero", "minus one" })]
        [TestCase(new double[] { -1.1, -5432, 123, 4 }, ExpectedResult = new string[] { "minus one point one", "minus five four three two", "one two three", "four" })]
        public string[] TransformTests(double[] arrayOfDouble)
            => arrayOfDouble.Transform();

        [Test]
        public void Transform_ArrayIsNull_ThrowArgumentNullException()
        {
            double[] arrayNull = null;
            Assert.Throws<ArgumentNullException>(() => arrayNull.IsNull());
        }

        [Test]
        public void Transform_ArrayIsEmpty_ThrowArgumentException()
        {
            double[] arrayNull = new double[] { };
            Assert.Throws<ArgumentException>(() => arrayNull.IsEmpty());
        }

        [TestCase(-255.255, ExpectedResult = "1100000001101111111010000010100011110101110000101000111101011100")]
        [TestCase(255.255, ExpectedResult = "0100000001101111111010000010100011110101110000101000111101011100")]
        [TestCase(4294967295.0, ExpectedResult = "0100000111101111111111111111111111111111111000000000000000000000")]
        [TestCase(double.MinValue, ExpectedResult = "1111111111101111111111111111111111111111111111111111111111111111")]
        [TestCase(double.MaxValue, ExpectedResult = "0111111111101111111111111111111111111111111111111111111111111111")]
        [TestCase(double.Epsilon, ExpectedResult = "0000000000000000000000000000000000000000000000000000000000000001")]
        [TestCase(double.NaN, ExpectedResult = "1111111111111000000000000000000000000000000000000000000000000000")]
        [TestCase(double.NegativeInfinity, ExpectedResult = "1111111111110000000000000000000000000000000000000000000000000000")]
        [TestCase(double.PositiveInfinity, ExpectedResult = "0111111111110000000000000000000000000000000000000000000000000000")]
        [TestCase(-0.0, ExpectedResult = "1000000000000000000000000000000000000000000000000000000000000000")]
        [TestCase(0.0, ExpectedResult = "0000000000000000000000000000000000000000000000000000000000000000")]
        public string GetIEEEBinaryStringTests(double number)
            => number.GetIEEEBinaryString();
    }
}
