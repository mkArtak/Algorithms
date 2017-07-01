using System;
using Xunit;

namespace AM.Core.Algorithms.Combinatorics.Tests
{
    public class PermutationsUtilitiesTests
    {
        [Fact]
        public void GetSortedPermutationAt_ReturnsExpectedValue()
        {
            int[] digits = new[] { 1, 2, 3 };

            // Here is the full set of the permutations from the above listed digits
            /*
             * 123
             * 132
             * 213
             * 231
             * 312
             * 321
             * */

            Assert.Equal(123, PermutationsUtilities.GetSortedPermutationAt(digits, 0));
            Assert.Equal(231, PermutationsUtilities.GetSortedPermutationAt(digits, 3));
            Assert.Equal(321, PermutationsUtilities.GetSortedPermutationAt(digits, 5));
        }

        [Fact]
        public void GetSortedPermutationAt_ThrowsForOutOfRangeIndex()
        {
            int[] digits = new[] { 1, 2, 3 };

            Assert.Throws<ArgumentOutOfRangeException>(() => PermutationsUtilities.GetSortedPermutationAt(digits, 6));
        }
    }
}
