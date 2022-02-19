using Xunit;

namespace AM.Core.Algorithms.Numbers.Tests
{
    public class DigitsStripperTests
    {
        [InlineData("12345", 2, "123")]
        [InlineData("10345", 1, "345")]
        [InlineData("10", 1, "0")]
        [Theory]
        public void RemoveKdigits_Succeeds(string number, int key, string expectation)
        {
            var result = DigitsStripper.RemoveKdigits(number, key);
            Assert.Equal(expectation, result);
        }
    }
}
