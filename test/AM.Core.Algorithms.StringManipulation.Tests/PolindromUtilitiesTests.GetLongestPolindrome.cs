using Xunit;

namespace AM.Core.Algorithms.StringManipulation.Tests
{
    public partial class PolindromUtilities_GetLongestPolindrome_Tests
    {
        [Fact]
        public void GetLongestPolindrome_ReturnsInputForSingleCharacter()
        {
            const string input = "a";
            Assert.Equal(input, PolindromUtilities.GetLongestPolindrome(input));
        }

        [Fact]
        public void GetLongestPolindrome_ReturnsEmptyForEmptyInput()
        {
            Assert.Equal(string.Empty, PolindromUtilities.GetLongestPolindrome(string.Empty));
        }

        [Fact]
        public void GetLongestPolindrome_ReturnsSingleCharacterForTwoCharacterPolindrome()
        {
            Assert.Equal("a", PolindromUtilities.GetLongestPolindrome("ab"));
        }

        [Theory]
        [InlineData("aa")]
        [InlineData("aaa")]
        [InlineData("aaaa")]
        public void GetLongestPolindrome_ReturnsFullStringForSameCharacters(string input)
        {
            Assert.Equal(input, PolindromUtilities.GetLongestPolindrome(input));
        }

        [Fact]
        public void GetLongestPolindrome_Succeeds_ForSinglePolindrome()
        {
            const string polindrome = "abccba";
            const string input = "zza" + polindrome + "bbv";
            Assert.Equal(polindrome, PolindromUtilities.GetLongestPolindrome(input));
        }

        [Fact]
        public void GetLongestPolindrome_Succeeds_ForTwoPolindrome()
        {
            const string polindrome1 = "abccba";
            const string polindrome2 = "abcdnbndcba";
            const string input = "zza" + polindrome1 + "bbv" + polindrome2;
            Assert.Equal(polindrome2, PolindromUtilities.GetLongestPolindrome(input));
        }
    }
}
