using AM.Core.Algorithms.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AM.Core.Algorithms.Tests
{
    [TestClass]
    public class MergeSortTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MergeSort_ThrowsForNullArgument()
        {
            MergeSort.Sort(null);
        }

        [TestMethod]
        public void MergeSort_LeavesASortedArraySorted()
        {
            GenericSortingAlgorithmTests.ValidateSort_LeavesASortedArraySourted(MergeSort.Sort);
        }

        [TestMethod]
        public void MergeSort_SortsAnUnsortedArray()
        {
            GenericSortingAlgorithmTests.Validate_SortsAnUnsortedArray(MergeSort.Sort);
        }

        [TestMethod]
        public void MergeSort_SucceedsForEmptyArray()
        {
            GenericSortingAlgorithmTests.Validate_SortEmptyArraySucceeds(MergeSort.Sort);
        }
    }
}
