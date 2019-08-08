using AM.Core.Algorithms.StringManipulation.Converters;
using Xunit;

namespace AM.Core.Algorithms.StringManipulation.Tests.Converters
{
    public abstract class ZigZagConverterTestsBase<T> where T : IZigZagStringConverter, new()
    {
        private readonly T sut;

        public ZigZagConverterTestsBase()
        {
            this.sut = new T();
        }

        [Fact]
        public void Convert_SucceedsForTwoRows()
        {
            const string input = "abcdefg";

            Assert.Equal("acegbdf", sut.Convert(input, 2));
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
            Assert.Equal(expectedResult, sut.Convert(input, numberOfRows));
        }
    }
}
