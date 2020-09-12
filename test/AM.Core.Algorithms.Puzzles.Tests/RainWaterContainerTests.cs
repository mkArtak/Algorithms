using Xunit;

namespace AM.Core.Algorithms.Puzzles.Tests
{
    public class RainWaterContainerTests
    {
        [Fact]
        public void GetMaxVolume_SucceedsForFlatHeights()
        {
            int[] heights = new[] { 1, 1, 1, 1, 1, 1, 1 };

            Assert.Equal(6, new RainWaterContainer().GetMaxVolume(heights));
        }

        [Theory]
        [InlineData(2, new[] { 1, 2, 3 })]
        public void GetMaxVolume_SucceedsForFlatHeights_Custom(int volume, int[] heights)
        {
            Assert.Equal(volume, new RainWaterContainer().GetMaxVolume(heights));
        }
    }
}
