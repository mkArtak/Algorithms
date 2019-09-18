using System;
using System.Linq;

namespace AM.Core.Algorithms.Numbers
{
    public static class Closest3Sum
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

                        //closestSum = sum;
                        //leftIndex++;
                        //rightIndex--;
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
    }
}
