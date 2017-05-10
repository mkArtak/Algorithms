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
            QuickSort.Sort(null);
        }

        [TestMethod]
        public void QuickSort_LeavesASortedArraySorted()
        {
            GenericSortingAlgorithmTests.ValidateSort_LeavesASortedArraySourted(QuickSort.Sort);
        }

        [TestMethod]
        public void QuickSort_SortsAnUnsortedArray()
        {
            GenericSortingAlgorithmTests.Validate_SortsAnUnsortedArray(QuickSort.Sort);
        }
    }
}
