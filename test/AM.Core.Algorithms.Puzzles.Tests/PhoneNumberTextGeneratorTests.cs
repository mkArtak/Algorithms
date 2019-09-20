using Xunit;

namespace AM.Core.Algorithms.Puzzles.Tests
{
    public class PhoneNumberTextGeneratorTests
    {
        [Fact]
        public void GetAllCombinations_Succeeds()
        {
            string input = "23";

            string[] expectedResult = new[] { "ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf" };

            PhoneNumberTextGenerator sut = new PhoneNumberTextGenerator();
            var actualResult = sut.GetAllCombinations(input);

            Assert.Equal(expectedResult, actualResult);
        }
    }
}
