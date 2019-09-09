using System;
using System.Collections.Generic;
using System.Linq;

namespace AM.Core.Algorithms.Numbers
{
    public static class ZeroSumNumbers
    {
        /// <summary>
        /// This is the LeetCode 3Sum problem implementation: https://leetcode.com/problems/3sum/
        /// </summary>
        /// <param name="numbers">The input numbers</param>
        /// <returns>The unique list of tries which sume to zero.</returns>
        public static IList<IList<int>> GetZeroSumTries(int[] numbers)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException();
            }

            IList<IList<int>> result = new List<IList<int>>();

            numbers = numbers.OrderBy(i => i).ToArray();

            // Filter out the elements from the array, which won't be used in the result in any way
            // Assume the elements go like A1, A2, ... Amin, Amin+1, ... Amax, Amax+1, ... An
            // 
            for (int i = 0; i < numbers.Length; i++)
            {
                int leftIndex = i + 1;
                int rightIndex = numbers.Length - 1;

                while (leftIndex < rightIndex)
                {
                    int sum = numbers[i] + numbers[leftIndex] + numbers[rightIndex];
                    if (sum == 0)
                    {
                        result.Add(new int[] { numbers[i], numbers[leftIndex], numbers[rightIndex] });

                        // Skip over the repeating numbers. We can do this as the list is ordered.
                        SkipWhile(numbers, ref leftIndex, 1);
                        SkipWhile(numbers, ref rightIndex, -1);

                        leftIndex++;
                        rightIndex--;
                        continue;
                    }
                    else if (sum < 0)
                    {
                        leftIndex++;
                    }
                    else
                    {
                        rightIndex--;
                    }
                }

                SkipWhile(numbers, ref i, 1);
            }

            return result;
        }

        private static void SkipWhile(int[] array, ref int index, int moveDirection)
        {
            int nextIndex = index;
            while (nextIndex >= 0 && nextIndex < array.Length && array[index] == array[nextIndex])
            {
                index = nextIndex;
                nextIndex += moveDirection;
            }
        }
    }
}
