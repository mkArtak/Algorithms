using System.Collections;

namespace AM.Core.Algorithms.Puzzles
{
    public class IslandPerimiterFinder
    {
        private const int Soil = 1;
        private const int Water = 0;

        public int IslandPerimeter(int[][] grid)
        {
            // Find the island
            for (var i = 0; i < grid.GetLength(0); i++)
            {
                for (var j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == Soil)
                    {
                        // We've landed on an island.
                        // Discover it and calculate the perimiter as we navigate it.
                        BitArray visitTracker = new BitArray(grid.Length * grid[0].Length);
                        return GetPerimiter(grid, visitTracker, i, j);
                    }
                }
            }

            return 0;
        }

        private int GetPerimiter(int[][] grid, BitArray visitTracker, int i, int j)
        {
            if (i < 0 || j < 0 || i >= grid.Length || j >= grid[i].Length || grid[i][j] == Water)
            {
                // Returning 1 as we came here from a solid cell and that side is a shore
                return 1;
            }

            var key = i * grid[i].Length + j;
            if (visitTracker.Get(key))
            {
                return 0;
            }

            visitTracker.Set(key, true);

            int perimiter = 0;

            // Top
            perimiter += GetPerimiter(grid, visitTracker, i - 1, j);

            // Right
            perimiter += GetPerimiter(grid, visitTracker, i, j + 1);

            // Bottom
            perimiter += GetPerimiter(grid, visitTracker, i + 1, j);

            // Left
            perimiter += GetPerimiter(grid, visitTracker, i, j - 1);

            return perimiter;
        }
    }
}
