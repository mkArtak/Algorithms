using System;
using System.Collections.Generic;

namespace AM.Core.Algorithms.StringManipulation
{
    public static class PermutationsGenerator
    {
        public static IEnumerable<string> GetPermutations(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            return GetPermutations(input, string.Empty);
        }

        private static IEnumerable<string> GetPermutations(string input, string prefix)
        {
            if (input.Length == 0)
            {
                yield return prefix;
                yield break;
            }

            for (int i = 0; i < input.Length; i++)
            {
                string rem = input.Substring(0, i) + input.Substring(i + 1);
                foreach (string item in GetPermutations(rem, prefix + input[i]))
                {
                    yield return item;
                }
            }
        }
    }
}
