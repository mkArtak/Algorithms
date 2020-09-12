using System;
using Xunit;

namespace AM.Core.Algorithms.StringManipulation.Tests
{
    public class StringUtilitiesTests
    {
        [Fact]
        public void Swap_SwapsCharacters()
        {
            const string input = "abcdefg";

            string actual = StringUtilities.Swap(input, 1, 5);

            Assert.Equal("afcdebg", actual);
        }

        [Fact]
        public void Swap_ThrowsForEmptyString()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => StringUtilities.Swap(string.Empty, 0, 0));
        }

        [Fact]
        public void Reverse_ReversesString()
        {
            const string input = "abcdefg";

            Assert.Equal("gfedcba", StringUtilities.Reverse(input));
        }

        [Fact]
        public void Reverse_SucceedsForEmptyString()
        {
            Assert.Equal(String.Empty, StringUtilities.Reverse(String.Empty));
        }

        [Fact]
        public void Reverse_ThrowsForNullArgument()
        {
            Assert.Throws<ArgumentNullException>(() => StringUtilities.Reverse(null));
        }

        [Fact]
        public void ReverseByWords_SucceedsForEmptyString()
        {
            Assert.Equal(String.Empty, StringUtilities.ReverseByWords(String.Empty));
        }

        [Fact]
        public void ReverseByWords_Succeeds()
        {
            const string input = "lap tap gap";

            string actual = StringUtilities.ReverseByWords(input);
            Assert.Equal("gap tap lap", actual);
        }

        [Fact]
        public void ReverseByWords_ThrowsForNullArgument()
        {
            Assert.Throws<ArgumentNullException>(() => StringUtilities.ReverseByWords(null));
        }

        [Fact]
        public void ReversVowels_TwoDigitInput_Succeeds()
        {
            Assert.Equal("Aa", StringUtilities.ReverseVowels("aA"));
        }
    }
}
