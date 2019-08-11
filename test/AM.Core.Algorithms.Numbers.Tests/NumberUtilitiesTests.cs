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
    }
}
