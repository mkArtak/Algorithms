using Xunit;

namespace AM.Core.Algorithms.Numbers.Tests
{
    public class ClosestSumsTests
    {
        [Fact]
        public void GetClosestTrieSum_Succeeds()
        {
            int[] testInput = new int[] { -1, 2, 1, -4 };
            int result = ClosestSums.GetClosestTrieSum(testInput, 1);

            Assert.Equal(2, result);
        }

        [Fact]
        public void FourSum_SucceedsForZeroInput()
        {
            int[] nums = new[] { 0, 0, 0, 0 };
            var result = ClosestSums.FourSum(nums, 0);

            Assert.Equal(1, result.Count);
            Assert.All(result[0], i => Assert.Equal(0, i));
        }

        [Fact]
        public void FourSum_Succeeds()
        {
            int[] nums = new[] { 1, 0, -1, 0, -2, 2 };
            var result = ClosestSums.FourSum(nums, 0);


            Assert.Equal(3, result.Count);
            Assert.Equal(new int[] { -2, -1, 1, 2 }, result[0]);
            Assert.Equal(new int[] { -2, 0, 0, 2 }, result[1]);
            Assert.Equal(new int[] { -1, 0, 0, 1 }, result[2]);
        }

        [Fact]
        public void FourSum_SucceedsForComplexInput()
        {
            int[] nums = new[] { -3, -2, -1, 0, 0, 1, 2, 3 };
            var result = ClosestSums.FourSum(nums, 0);


            Assert.Equal(8, result.Count);
            Assert.Equal(new int[] { -3, -2, 2, 3 }, result[0]);
            Assert.Equal(new int[] { -3, -1, 1, 3 }, result[1]);
            Assert.Equal(new int[] { -3, 0, 0, 3 }, result[2]);
            Assert.Equal(new int[] { -3, 0, 1, 2 }, result[3]);
            Assert.Equal(new int[] { -2, -1, 0, 3 }, result[4]);
            Assert.Equal(new int[] { -2, -1, 1, 2 }, result[5]);
            Assert.Equal(new int[] { -2, 0, 0, 2 }, result[6]);
            Assert.Equal(new int[] { -1, 0, 0, 1 }, result[7]);
        }
    }
}
