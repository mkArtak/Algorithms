using Xunit;

namespace AM.Core.Algorithms.StringManipulation.Tests
{
    public class ZigZagConverterTests
    {
        [Fact]
        public void Convert_SucceedsForTwoRows()
        {
            const string input = "abcdefg";

            Assert.Equal("acegbdf", ZigZagConverter.Convert(input, 2));
        }

        [Theory]
        [InlineData("abc", 1, "abc")]
        [InlineData("abcde", 3, "aebdc")]
        [InlineData("ab", 2, "ab")]
        [InlineData("abc", 2, "acb")]
        [InlineData("abcde", "2", "acebd")]
        [InlineData("abcdef", 3, "aebdfc")]
        [InlineData("PAYPALISHIRING", 5, "PHASIYIRPLIGAN")]
        public void Convert_Succeeds(string input, int numberOfRows, string expectedResult)
        {
            Assert.Equal(expectedResult, ZigZagConverter.Convert(input, numberOfRows));
        }
    }
}
