using AM.Core.Algorithms.Search;
using AM.Core.DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AM.Core.Algorithms.Tests
{
    [TestClass]
    public class HeapSortTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void HeapSort_ThrowsForNullArgument()
        {
            new Heap<int>(null, HeapTypes.MaxHeap);
        }

        [TestMethod]
        public void HeapSort_LeavesASortedArraySorted()
        {
            GenericSortingAlgorithmTests.ValidateSort_LeavesASortedArraySourted(new HeapSort<int>().Sort);
        }

        [TestMethod]
        public void HeapSort_SortsAnUnsortedArray()
        {
            GenericSortingAlgorithmTests.Validate_SortsAnUnsortedArray(new HeapSort<int>().Sort);
        }

        [TestMethod]
        public void HeapSort_SucceedsForEmptyArray()
        {
            GenericSortingAlgorithmTests.Validate_SortEmptyArraySucceeds(new HeapSort<int>().Sort);
        }
    }
}
