using Xunit;

namespace AM.Core.Algorithms.Numbers.Tests
{
    public class Closest3SumTests
    {
        [Fact]
        public void GetClosestTrieSum_Succeeds()
        {
            int[] testInput = new int[] { -1, 2, 1, -4 };
            int result = Closest3Sum.GetClosestTrieSum(testInput, 1);

            Assert.Equal(2, result);
        }
    }
}
