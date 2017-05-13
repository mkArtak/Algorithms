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
        public void QuickSort_ThrowsForNullArgument()
        {
            new QuickSort<int>().Sort(null);
        }

        [TestMethod]
        public void QuickSort_LeavesASortedArraySorted()
        {
            GenericSortingAlgorithmTests.ValidateSort_LeavesASortedArraySourted(new QuickSort<int>().Sort);
        }

        [TestMethod]
        public void QuickSort_SortsAnUnsortedArray()
        {
            GenericSortingAlgorithmTests.Validate_SortsAnUnsortedArray(new QuickSort<int>().Sort);
        }

        [TestMethod]
        public void QuickSort_SucceedsForEmptyArray()
        {
            GenericSortingAlgorithmTests.Validate_SortEmptyArraySucceeds(new QuickSort<int>().Sort);
        }
    }
}
