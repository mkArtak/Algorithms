using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace AM.Core.Algorithms.StringManipulation.Tests
{
    public class PermutationsGeneratorTests
    {
        [Fact]
        public void GetPermutations_ThrowsForNullArgumnet()
        {
            Assert.Throws<ArgumentNullException>(() => PermutationsGenerator.GetPermutations(null));
        }

        [Fact]
        public void GetPermutations_ReturnsSingleCharacter()
        {
            const char onlyCharacter = 'c';
            IList<string> result = PermutationsGenerator.GetPermutations(onlyCharacter.ToString()).ToList();
            Assert.Equal(1, result.Count);
            Assert.Equal(onlyCharacter, result.Single()[0]);
        }

        [Fact]
        public void GetPermutations_ReturnsEmptyStringForEmptyInput()
        {
            IList<string> permutations = PermutationsGenerator.GetPermutations(string.Empty).ToList();
            Assert.Equal(1, permutations.Count);
            Assert.Equal(string.Empty, permutations[0]);
        }

        [Fact]
        public void GetPermutations_ReturnsAllPossiblePermutations()
        {
            IList<string> result = PermutationsGenerator.GetPermutations("abc").ToList();
            Assert.Equal(6, result.Count);
            Assert.True(result.Contains("abc"));
            Assert.True(result.Contains("acb"));
            Assert.True(result.Contains("bac"));
            Assert.True(result.Contains("bca"));
            Assert.True(result.Contains("cab"));
            Assert.True(result.Contains("cba"));
        }
    }
}
