using AM.Core.Algorithms.StringManipulation.Encoders;
using System;
using Xunit;

namespace AM.Core.Algorithms.StringManipulation.Tests.Encoders
{
    public class RepetitiveStringEncoderTests
    {
        [Fact]
        public void Decode_ReturnsSimpleStringAsIs()
        {
            const string input = "abcdef";

            RepetitiveStringEncoder sut = new RepetitiveStringEncoder();
            Assert.Equal(input, sut.Decode(input));
        }

        [Fact]
        public void Decode_ReturnsEmptyString()
        {
            RepetitiveStringEncoder sut = new RepetitiveStringEncoder();
            Assert.Equal(string.Empty, sut.Decode(string.Empty));
        }

        [Fact]
        public void Decode_ReturnsSingleLevelDecodedString()
        {
            const string input = "ab2[cd]ef";

            RepetitiveStringEncoder sut = new RepetitiveStringEncoder();
            Assert.Equal("abcdcdef", sut.Decode(input));
        }

        [Fact]
        public void Decode_ReturnsMultiLevelDecodedString()
        {
            const string input = "ab2[cd4[a]]ef";

            RepetitiveStringEncoder sut = new RepetitiveStringEncoder();
            Assert.Equal("abcdaaaacdaaaaef", sut.Decode(input));
        }

        [Fact]
        public void Decode_ThrowsForNullIput()
        {
            RepetitiveStringEncoder sut = new RepetitiveStringEncoder();
            Assert.Throws<ArgumentNullException>(() => sut.Decode(null));
        }

        [Theory]
        [InlineData("ab[cd]")]
        [InlineData("ab2")]
        [InlineData("ab2[")]
        [InlineData("ab2]")]
        [InlineData("ab2[df[]")]
        public void Decode_ThrowsForInvalidInput(string invalidInput)
        {
            RepetitiveStringEncoder sut = new RepetitiveStringEncoder();
            Assert.Throws<FormatException>(() => sut.Decode(invalidInput));
        }
    }
}
