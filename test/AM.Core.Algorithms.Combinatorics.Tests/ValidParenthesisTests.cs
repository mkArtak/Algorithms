using Xunit;

namespace AM.Core.Algorithms.Combinatorics.Tests
{
    public class ValidParenthesisTests
    {
        [Fact]
        public void GetValidPermuations_SucceedsForSingleSet()
        {
            var result = ValidParenthesis.GenerateParenthesis(1);

            Assert.Equal(1, result.Count);

            Assert.Equal("()", result[0]);
        }

        [Fact]
        public void GetValidPermuations_SucceedsForDoubleSet()
        {
            var result = ValidParenthesis.GenerateParenthesis(2);

            Assert.Equal(2, result.Count);

            Assert.Contains("()()", result);
            Assert.Contains("(())", result);
        }
    }
}
