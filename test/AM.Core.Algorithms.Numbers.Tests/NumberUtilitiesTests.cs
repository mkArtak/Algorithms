using System;
using Xunit;

namespace AM.Core.Algorithms.Numbers.Tests
{
    public class NumberUtilitiesTests
    {
        [Fact]
        public void Reverse_Succeeds()
        {
            Assert.Equal(4321, NumberUtilities.Reverse(1234));
        }

        [Fact]
        public void Reverse_SucceedsForNegativeNumbers()
        {
            Assert.Equal(-4321, NumberUtilities.Reverse(-1234));
        }

        [Fact]
        public void Reverse_Returns0For0()
        {
            Assert.Equal(0, NumberUtilities.Reverse(0));
        }

        [Fact]
        public void Reverse_ThrowsForTooBigNumber()
        {
            const int input = 1534236469;
            Assert.Equal(0, NumberUtilities.Reverse(input));
        }

        [Fact]
        public void ToInt_SucceedsForPositiveNumber()
        {
            Assert.Equal(1234, NumberUtilities.ToInt("1234"));
        }

        [Fact]
        public void ToInt_SucceedsForPositiveNumberWithSignPrefix()
        {
            Assert.Equal(1234, NumberUtilities.ToInt("+1234"));
        }

        [Fact]
        public void ToInt_SucceedsForNegativeNumber()
        {
            Assert.Equal(-1234, NumberUtilities.ToInt("-1234"));
        }

        [Fact]
        public void ToInt_SucceedsForPositiveNumberWithEmptyPrefix()
        {
            Assert.Equal(1234, NumberUtilities.ToInt("      1234"));
        }

        [Fact]
        public void ToInt_SucceedsForNegativeNumberWithEmptyPrefix()
        {
            Assert.Equal(-1234, NumberUtilities.ToInt("      -1234"));
        }

        [Theory]
        [InlineData("0")]
        [InlineData("+0")]
        [InlineData("   +0    ")]
        [InlineData("   +0asdfasdf")]
        [InlineData("   +0  ")]
        [InlineData("   -0  ")]
        [InlineData("-0  ")]
        [InlineData("-0")]
        public void ToInt_SucceedsForZero(string input)
        {
            Assert.Equal(0, NumberUtilities.ToInt(input));
        }

        [Theory]
        [InlineData("--")]
        [InlineData(" ")]
        public void ToInt_ReturnsZeroForNonDigitsInput(string input)
        {
            Assert.Equal(0, NumberUtilities.ToInt(input));
        }

        [Theory]
        [InlineData(1, "I")]
        [InlineData(2, "II")]
        [InlineData(100, "C")]
        [InlineData(744, "DCCXLIV")]
        public void ConvertIntToRoman_ConvertsCorrectly(int input, string expectedValue)
        {
            Assert.Equal(expectedValue, NumberUtilities.ConvertIntToRoman(input));
        }

        [Theory]
        [InlineData(7, 15, 2)]
        [InlineData(-2, 7, -3)]
        [InlineData(0, 1, 2)]
        [InlineData(-1, -1, 1)]
        [InlineData(2, -2147483648, -1017100424)]
        [InlineData(-5, -5, 1)]
        [InlineData(1073741823, 2147483647, 2)]
        [InlineData(-2147483648, -2147483648, 1)]
        public void DivideNumbers(int result, int divider, int divisor)
        {
            Assert.Equal(result, NumberUtilities.DivideNumbers(divider, divisor));
        }

        [Fact]
        public void DivideNumbers_ResultsInOneForSameArguments()
        {
            Assert.Equal(1, NumberUtilities.DivideNumbers(42, 42));
        }

        [Fact]
        public void DivideNumbers_ResultsInNegativeOneForNegativeDivident()
        {
            Assert.Equal(-1, NumberUtilities.DivideNumbers(-42, 42));
        }

        [Fact]
        public void DivideNumbers_ResultsInNegativeOneForNegativeDivisor()
        {
            Assert.Equal(-1, NumberUtilities.DivideNumbers(42, -42));
        }

        [Fact]
        public void DivideNumbers_HandlesOverflow()
        {
            Assert.Equal(Int32.MaxValue, NumberUtilities.DivideNumbers(Int32.MinValue, -1));
        }
    }
}
