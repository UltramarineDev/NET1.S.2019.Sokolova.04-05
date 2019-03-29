using NUnit.Framework;

namespace DoubleConverter.Tests
{
    public class TransformerTests
    {
        [TestCase(-23.809, ExpectedResult = "minus two three point eight zero nine")]
        [TestCase(3.006, ExpectedResult = "three point zero zero six")]
        [TestCase(0.0023, ExpectedResult = "zero point zero zero two three")]
        [TestCase(-0.07894, ExpectedResult = "minus zero point zero seven eight nine four")]
        [TestCase(12340.6, ExpectedResult = "one two three four zero point six")]
        [TestCase(0.0001, ExpectedResult = "zero point zero zero zero one")]
        [TestCase(543.08, ExpectedResult = "five four three point zero eight")]
        [TestCase(-543.07, ExpectedResult = "minus five four three point zero seven")]
        [TestCase(328, ExpectedResult = "three two eight")]
        [TestCase(0, ExpectedResult = "zero")]
        [TestCase(651, ExpectedResult = "six five one")]
        public string TransformToWordsTests(double number)
            => Transformer.TransformToWords(number);
    }
}
