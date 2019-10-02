using System;
using System.Collections.Generic;
using System.Text;

namespace AM.Core.Algorithms.StringManipulation.RegularExpressions
{
    public class RegexUtilities
    {
        /// <summary>
        /// Validates, whether the <code cref="input"/> string matches the specified <see cref="pattern"/>.
        /// </summary>
        /// <param name="input">The input string to match</param>
        /// <param name="pattern">The regular expression pattern.</param>
        /// <returns>true, if the string matches the pattern. false - otherwise</returns>
        /// <remarks>The pattern supports any characters from a-z as well as characters `.` and `*` indicating a single and multi-character match.</remarks>
        public static bool IsMatch(string input, string pattern)
        {
            // Algorithm 1:
            // Each character in pattern represents an expecation.
            // Go through each one and see whether there is a match on the input string

            if (input == null || pattern == null)
            {
                throw new ArgumentNullException();
            }

            if (input.Length == 0)
            {
                return pattern.Length == 0;
            }
            else if (pattern.Length == 0)
            {
                return false;
            }

            if (pattern[0] == '*')
            {
                throw new ArgumentException("* not allowed as the first character of a pattern, as it has no meaning");
            }

            int currentInputIndex = 0;
            int currentPatternIndex = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if(!CharactersMatch(input[i], pattern, currentPatternIndex))
                {

                }
            }


            // Algorithm 2:
            // abccccdf
            // abc*.cdf
            // Algorithm
            // 1. Split the pattern by '*'
            // 2. for each `non-pattern` section - map to the input string appropriate section and validate
            // 3. If succeeds, map the * sections with leftover pieces and validate (those sould all be of the same character or empty

            return true;
        }

        private static bool IsSpecialCharacter(char c)
        {
            return c == '*' || c == '.';
        }

        private static bool CharactersMatch(char input, string pattern, int patternIndex)
        {
            bool result = false;

            char patternChar = pattern[patternIndex];
            if (patternChar == '.')
            {
                result = true;
            }
            else if (patternChar == '*')
            {
                result = CharactersMatch(input, pattern, patternIndex - 1);
            }
            else
            {
                result = input == patternChar;
            }

            return result;
        }
    }
}
