using Xunit;

namespace AM.Core.Algorithms.Numbers.Tests
{
    public class ZeroSumNumbersTests
    {
        [Fact]
        public void Sum_ForZero()
        {
            int[] input = new int[] { 0, 0, 0, 0 };
            var result = ZeroSumNumbers.GetZeroSumTries(input);

            Assert.Equal(1, result.Count);

            Assert.All(result[0], i => Assert.Equal(0, i));
        }

        [Fact]
        public void Sum_Succeeds()
        {
            int[] input = new int[] { -4, -2, 1, -5, -4, -4, 4, -2, 0, 4, 0, -2, 3, 1, -5, 0 };

            var result = ZeroSumNumbers.GetZeroSumTries(input);

            Assert.Equal(6, result.Count);
            Assert.Contains(new[] { -5, 1, 4 }, result);
            Assert.Contains(new[] { -4, 0, 4 }, result);
            Assert.Contains(new[] { -4, 1, 3 }, result);
            Assert.Contains(new[] { -2, -2, 4 }, result);
            Assert.Contains(new[] { -2, 1, 1 }, result);
            Assert.Contains(new[] { 0, 0, 0 }, result);
        }
    }
}
