using System;
using Xunit;

namespace AM.Core.Algorithms.StringManipulation.Tests
{
    public class PolindromUtilitiesTests
    {
        [Fact]
        public void IsPlindrome_FailsForNullArgument()
        {
            Assert.Throws<ArgumentNullException>(() => PolindromUtilities.IsPolindrome(null));
        }

        [Fact]
        public void IsPolindrome_ReturnsTrueForEmptyString()
        {
            Assert.True(PolindromUtilities.IsPolindrome(string.Empty));
        }

        [Fact]
        public void IsPolindrome_ReturnsFalseForNonPolindromeString()
        {
            Assert.False(PolindromUtilities.IsPolindrome("abcd"));
        }

        [Fact]
        public void IsPolindrome_ReturnsTrueForPolindromeString()
        {
            Assert.True(PolindromUtilities.IsPolindrome("abba"));
        }
    }
}
