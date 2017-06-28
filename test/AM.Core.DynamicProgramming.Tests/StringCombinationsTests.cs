using System;
using System.Linq;
using Xunit;

namespace AM.Core.Algorithms.DynamicProgramming.Tests
{
    public class StringCombinationsTests
    {
        [Fact]
        public void GetCombinations_ReturnsAll()
        {
            string[] result = StringCombinations.GetCombinations(new[] { "ab", "cd" });

            Assert.Equal(4, result.Length);
        }

        [Fact]
        public void GetCombinations_ReturnsEmptyArray()
        {
            string[] result = StringCombinations.GetCombinations(new[] { "" });

            Assert.Equal(0, result.Length);
        }

        [Fact]
        public void GetCombinations_ReturnsSourcecForSingleElementArray()
        {
            string[] result = StringCombinations.GetCombinations(new[] { "ab" });

            Assert.Equal(2, result.Length);
            Assert.True(result.Contains("a"));
            Assert.True(result.Contains("b"));
        }

        [Fact]
        public void GetCombinations_ThrowsForNullArgument()
        {
            Assert.Throws<ArgumentNullException>(() => StringCombinations.GetCombinations(null));
        }
    }
}
