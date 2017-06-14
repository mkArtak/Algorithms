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

        [Fact]
        public void GetCharacterIndexToRemoveToMakePolindrom_FailsForNullArgument()
        {
            Assert.Throws<ArgumentNullException>(() => PolindromUtilities.GetCharacterIndexToRemoveToMakePolindrom(null));
        }

        [Fact]
        public void GetCharacterIndexToRemoveToMakePolindrom_Returns0ForSingleCharacterString()
        {
            Assert.Equal(0, PolindromUtilities.GetCharacterIndexToRemoveToMakePolindrom("a"));
        }

        [Fact]
        public void GetCharacterIndexToRemoveToMakePolindrom_Returns0ForDoubleCharacterString()
        {
            Assert.Equal(0, PolindromUtilities.GetCharacterIndexToRemoveToMakePolindrom("ab"));
        }

        [Fact]
        public void GetCharacterIndexToRemoveToMakePolindrom_ReturnsIndexOfCharacterToRemove()
        {
            Assert.Equal(2, PolindromUtilities.GetCharacterIndexToRemoveToMakePolindrom("abBcdfdcba"));
        }

        [Fact]
        public void GetCharacterIndexToRemoveToMakePolindrom_FailsForStringWhereMoreThanOneCharactersNeedToBeremoved()
        {
            Assert.Throws<ArgumentException>(() => PolindromUtilities.GetCharacterIndexToRemoveToMakePolindrom("abBfcdfdcba"));
        }
    }
}
