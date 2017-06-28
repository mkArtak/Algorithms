using System;

namespace AM.Core.Algorithms.DynamicProgramming
{
    public static class UniquePathsCalculator
    {
        /// <summary>
        /// Calculates the number of unique paths, which can be taken to move from top-left corner of an mxn matrix to the bottom-right corner.
        /// The algorithm stored the number of paths leading to the cell in it. So for each cell - the number of paths is "number of paths which took to the upper cell" + "the number of paths which took to the left cell"
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int GetNumberOfUniquePaths(int m, int n)
        {
            if (m == 0 || n == 0) return 0;
            if (m == 1 || n == 1) return 1;

            int[,] dp = new int[m, n];

            //left column
            for (int i = 0; i < m; i++)
            {
                dp[i, 0] = 1;
            }

            //top row
            for (int j = 0; j < n; j++)
            {
                dp[0, j] = 1;
            }

            //fill up the dp table
            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
                }
            }

            return dp[m - 1, n - 1];
        }
    }
}
