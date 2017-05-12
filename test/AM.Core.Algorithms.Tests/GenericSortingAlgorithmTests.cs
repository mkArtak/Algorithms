using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AM.Core.Algorithms.Tests
{
    internal static class GenericSortingAlgorithmTests
    {
        public static void ValidateSort_LeavesASortedArraySourted(Action<int[]> sortLogic)
        {
            int[] sourceArray = new[] { 1, 2, 3, 4, 5, 6 };
            int[] actualArray = new int[sourceArray.Length];
            sourceArray.CopyTo(actualArray, 0);

            sortLogic(actualArray);

            AssertEqualArrays(sourceArray, actualArray);
        }

        public static void Validate_SortsAnUnsortedArray(Action<int[]> sortLogic)
        {
            int[] actualArray = new[] { 3, 2, 1 };

            sortLogic(actualArray);

            AssertEqualArrays(new[] { 1, 2, 3 }, actualArray);
        }

        public static void Validate_SortEmptyArraySucceeds(Action<int[]> sortLogic)
        {
            sortLogic(new int[] { });
        }

        /// <summary>
        /// Ensures that the specified arrays have the same elements in the same order.
        /// </summary>
        private static void AssertEqualArrays(int[] sourceArray, int[] actualArray)
        {
            Assert.AreEqual(sourceArray.Length, actualArray.Length);

            for (int i = 0; i < sourceArray.Length; i++)
            {
                Assert.AreEqual(sourceArray[i], actualArray[i]);
            }
        }
    }
}
