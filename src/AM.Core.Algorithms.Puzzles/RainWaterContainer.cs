using System;

namespace AM.Core.Algorithms.Puzzles
{
    /// <summary>
    /// https://leetcode.com/problems/container-with-most-water/
    /// </summary>
    public class RainWaterContainer
    {
        public int GetMaxVolume(int[] heights)
        {
            int leftIndex = 0;
            int rightIndex = heights.Length - 1;

            int maxVolume = 0;
            do
            {
                int leftHeight = heights[leftIndex];
                int rightHeight = heights[rightIndex];

                int volume = (rightIndex - leftIndex) * Math.Min(leftHeight, rightHeight);

                if (volume > maxVolume)
                    maxVolume = volume;

                if (leftHeight < rightHeight)
                {
                    do
                    {
                        leftIndex++;
                    } while (leftIndex < rightIndex && heights[leftIndex] <= leftHeight);
                }
                else if (rightHeight < leftHeight)
                {
                    do
                    {
                        rightIndex--;
                    } while (leftIndex < rightIndex && heights[rightIndex] <= rightHeight);
                }
                else
                {
                    leftIndex++;
                    rightIndex--;
                }
            }
            while (leftIndex < rightIndex);

            return maxVolume;
        }
    }
}
