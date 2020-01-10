using System;
using System.Collections.Generic;
using System.Linq;

namespace AM.Core.Algorithms.Numbers
{
    public static class ClosestSums
    {
        /// <summary>
        /// This is implementation of the LeetCode 3Sum-closest problem: https://leetcode.com/problems/3sum-closest/submissions/
        /// </summary>
        /// <param name="numbers">The numbers array</param>
        /// <param name="target">The target number to get the sum close to</param>
        /// <returns>The closest possible sum</returns>
        public static int GetClosestTrieSum(int[] numbers, int target)
        {
            if (numbers is null)
            {
                throw new ArgumentNullException();
            }

            if (numbers.Length < 3)
            {
                throw new ArgumentException();
            }

            //This algorithm can be further optimized by using an in-place sorting instead of the below one, as the below call allocates memory for the new array
            numbers = numbers.OrderBy(i => i).ToArray();

            int result = Int32.MaxValue;
            int diff = Int32.MaxValue;
            for (int i = 0; i < numbers.Length; i++)
            {
                // this is our base number. 
                int leftIndex = i + 1;
                int rightIndex = numbers.Length - 1;
                while (leftIndex < rightIndex)
                {
                    int sum = numbers[i] + numbers[leftIndex] + numbers[rightIndex];

                    if (sum == target)
                    {
                        return target;
                    }

                    if (sum < target)
                    {
                        leftIndex++;
                        var currentDiff = target - sum;
                        if (currentDiff < diff)
                        {
                            diff = currentDiff;
                            result = sum;
                        }
                    }
                    else
                    {
                        rightIndex--;

                        int currentDiff = sum - target;
                        if (currentDiff < diff)
                        {
                            diff = currentDiff;
                            result = sum;
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Finds all unique quadruples of numbers, which sum up to the given <paramref name="target"/> value.
        /// </summary>
        /// <param name="nums">The numbers array.</param>
        /// <param name="target">The target value to sum up to.</param>
        /// <leetcode>https://leetcode.com/problems/4sum</leetcode>
        /// <returns>A list of all matching quadruples.</returns>
        public static IList<IList<int>> FourSum(int[] nums, int target)
        {
            IList<IList<int>> result = new List<IList<int>>();
            if (nums == null || nums.Length < 4)
                return result;

            int[] sortedNums = nums.OrderBy(i => i).ToArray();
            for (int i = 0; i < sortedNums.Length - 3; i++)
            {
                if (i > 0 && sortedNums[i] == sortedNums[i - 1])
                    continue;

                for (int j = i + 1; j < sortedNums.Length - 2; j++)
                {
                    if (j > i + 1 && sortedNums[j] == sortedNums[j - 1])
                        continue;

                    int leftIndex = j + 1;
                    int rightIndex = sortedNums.Length - 1;
                    int pairSum = sortedNums[i] + sortedNums[j];
                    do
                    {
                        int sum = pairSum + sortedNums[leftIndex] + sortedNums[rightIndex];
                        if (sum == target)
                        {
                            int leftValue = sortedNums[leftIndex];
                            result.Add(new List<int> { sortedNums[i], sortedNums[j], sortedNums[leftIndex], sortedNums[rightIndex] });
                            while (sortedNums[++leftIndex] == leftValue && leftIndex < rightIndex) ;
                            rightIndex--;
                        }
                        else if (sum < target)
                        {
                            leftIndex++;
                        }
                        else
                        {
                            rightIndex--;
                        }
                    } while (leftIndex < rightIndex);
                }
            }

            return result;
        }
    }
}
