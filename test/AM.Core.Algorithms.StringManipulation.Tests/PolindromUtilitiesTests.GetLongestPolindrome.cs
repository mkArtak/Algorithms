using Xunit;

namespace AM.Core.Algorithms.StringManipulation.Tests
{
    public partial class PolindromUtilities_GetLongestPolindrome2_Tests
    {
        [Fact]
        public void GetLongestPolindrome2_ReturnsInputForSingleCharacter()
        {
            const string input = "a";
            Assert.Equal(input, PolindromUtilities.GetLongestPolindrome2(input));
        }

        [Fact]
        public void GetLongestPolindrome2_ReturnsEmptyForEmptyInput()
        {
            Assert.Equal(string.Empty, PolindromUtilities.GetLongestPolindrome2(string.Empty));
        }

        [Fact]
        public void GetLongestPolindrome2_ReturnsSingleCharacterForTwoCharacterPolindrome()
        {
            Assert.Equal("a", PolindromUtilities.GetLongestPolindrome2("ab"));
        }

        [Theory]
        [InlineData("aa")]
        [InlineData("aaa")]
        [InlineData("aaaa")]
        public void GetLongestPolindrome2_ReturnsFullStringForSameCharacters(string input)
        {
            Assert.Equal(input, PolindromUtilities.GetLongestPolindrome2(input));
        }

        [Fact]
        public void GetLongestPolindrome2_Succeeds_ForSinglePolindrome()
        {
            const string polindrome = "abccba";
            const string input = "zza" + polindrome + "bbv";
            Assert.Equal(polindrome, PolindromUtilities.GetLongestPolindrome2(input));
        }

        [Theory]
        [InlineData("_abba+cdbbdc-", "cdbbdc")]
        [InlineData("cbbd", "bb")]
        public void GetLongestPolindrome2_Succeeds_ForTwoPolindrome(string input, string expectedOutput)
        {
            Assert.Equal(expectedOutput, PolindromUtilities.GetLongestPolindrome2(input));
        }
    }
}
