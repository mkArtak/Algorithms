using Xunit;

namespace AM.Core.Algorithms.Puzzles.Tests
{
    public class IslandPerimiterFinderTests
    {
        [Fact]
        public void IslandPerimeter_Returns0ForNoIsland()
        {
            int[][] grid = new int[3][]
            {
                new []{ 0, 0 , 0},
                new []{ 0, 0 , 0},
                new []{ 0, 0 , 0}
            };

            var sut = new IslandPerimiterFinder();
            Assert.Equal(0, sut.IslandPerimeter(grid));
        }

        [Fact]
        public void IslandPerimeter_Returns_4_ForSingleCellIsland()
        {
            int[][] grid = new int[3][]
            {
                new []{ 0, 0 , 0},
                new []{ 0, 1 , 0},
                new []{ 0, 0 , 0}
            };

            var sut = new IslandPerimiterFinder();
            Assert.Equal(4, sut.IslandPerimeter(grid));
        }

        [Fact]
        public void IslandPerimeter_Test()
        {
            int[][] grid = new int[2][]
            {
                new []{ 0 },
                new []{ 1 }
            };

            var sut = new IslandPerimiterFinder();
            Assert.Equal(4, sut.IslandPerimeter(grid));
        }

        [Fact]
        public void IslandPerimeter_Succeeds()
        {
            int[][] grid = new int[4][]
            {
                new []{ 0, 1, 0 , 0},
                new []{ 1, 1 , 1, 0},
                new []{ 0, 1 , 0, 0},
                new []{ 1, 1 , 0, 0}
            };

            var sut = new IslandPerimiterFinder();
            Assert.Equal(16, sut.IslandPerimeter(grid));
        }
    }
}
