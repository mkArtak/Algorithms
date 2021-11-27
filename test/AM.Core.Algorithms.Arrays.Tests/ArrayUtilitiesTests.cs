using AM.Core.Algorithms.Arrays;
using System;
using Xunit;

namespace AM.Core.Algorithms.Combinatorics.Tests
{
    public class ArraysUtilitiesTests
    {
        [Fact]
        public void FindMedianSortedArrays_Succeeds()
        {
            var array1 = new[] { 1, 2 };
            var array2 = new[] { 3, 4 };

            var result = ArrayUtilities.FindMedianSortedArrays(array1, array2);
            Assert.Equal(2.5, result);
        }

        [Fact]
        public void FindMedianSortedArrays2_Succeeds()
        {
            var array1 = new[] { 1, 2 };
            var array2 = new[] { 3, 4 };

            var result = ArrayUtilities.FindMedianSortedArrays2(array1, array2);
            Assert.Equal(2.5, result);
        }

        [Fact]
        public void FindMedianSortedArrays2_SucceedsForShortArrays()
        {
            var array1 = new[] { 1, 3 };
            var array2 = new[] { 2 };

            var result = ArrayUtilities.FindMedianSortedArrays2(array1, array2);
            Assert.Equal(2, result);
        }
    }
}
