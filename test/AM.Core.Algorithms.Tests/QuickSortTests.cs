using AM.Core.Algorithms.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AM.Core.Algorithms.Tests
{
    [TestClass]
    public class QuickSortTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Sort_ThrowsForNullArgument()
        {
            QuickSort.Sort(null);
        }

        [TestMethod]
        public void Sort_LeavesASortedArraySorted()
        {
            int[] sourceArray = new[] { 1, 2, 3 };
            int[] actualArray = new int[sourceArray.Length];
            sourceArray.CopyTo(actualArray, 0);

            QuickSort.Sort(actualArray);

            AssertEqualArrays(sourceArray, actualArray);
        }

        [TestMethod]
        public void Sort_SortsAnUnsortedArray()
        {
            int[] actualArray = new[] { 3, 2, 1 };

            QuickSort.Sort(actualArray);

            AssertEqualArrays(new[] { 1, 2, 3 }, actualArray);
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
