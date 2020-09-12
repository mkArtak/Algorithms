using System;
using System.Collections.Generic;
using System.Text;

namespace AM.Core.Algorithms.StringManipulation.RegularExpressions
{
    public class RegexUtilities // WIP
    {
        private static readonly char[] patternNormalizationArray = new char[] { WellKnownPatternCharacters.Star };

        /// This algorithm won't support the `.*` case. need to 
        /// <summary>
        /// Validates, whether the <code cref="input"/> string matches the specified <see cref="pattern"/>.
        /// </summary>
        /// <param name="input">The input string to match</param>
        /// <param name="pattern">The regular expression pattern.</param>
        /// <returns>true, if the string matches the pattern. false - otherwise</returns>
        /// <remarks>The pattern supports any characters from a-z as well as characters `.` and `*` indicating a single and multi-character match.
        /// Below is the algorith this method uses to match the pattern.
        ///          1. Normalize the pattern to simplify processing(Ex. 'c*cc*cc' => 'cccc*')
        ///          2. Split the pattern by '*' into multiple pattern sections
        ///          3. Starting from the last pattern section, try matching it from the end of the string.
        ///          4. If current section match, remember the position from the end, till which the input string matched with the pattern, and repeat the same evaluation process with the next pattern section(from the end).
        ///          5. If a section didn't match, return false, as that means the input string didn't match the pattern.
        ///          6. After going through all the pattern sections and all matching make sure that we went through all the input string and no characters left to be evaluated.
        ///          7. If any characters left to be evaluated, pattern didn't match.
        ///          8. Otherwise we've got a successful match.
        /// </remarks>
        public static bool IsMatch(string input, string pattern)
        {
            if (pattern == null)
                throw new ArgumentNullException();

            if (pattern.Length == 0)
                return true;

            if (pattern[0] == WellKnownPatternCharacters.Star)
                throw new ArgumentException("Pattern string cannot start with a '*'");

            var patternSections = NormalizePattern(pattern);
            int inputMatchingPosition = input.Length - 1;
            for (int i = patternSections.Length - 1; i > 0; i--)
            {
                if (!SectionMatchesPattern(input, inputMatchingPosition, patternSections[i], out int newEndPosition))
                {
                    return false;
                }

                inputMatchingPosition = newEndPosition;
            }

            return inputMatchingPosition == 0;
        }

        /// <summary>
        /// Validates whether a matching string found ending at the <paramref name="endIndex"/> position in the <paramref name="input"/> string.
        /// </summary>
        /// <param name="input">The input string to validate for a match.</param>
        /// <param name="endIndex">The end position in the <paramref name="input"/> string where a match should be looked at.</param>
        /// <param name="patternSection">A sectoin of a regular expression pattern, which ends with a <see cref="WellKnownPatternCharacters.Star"/> character.</param>
        /// <param name="matchStartPosition">If a match is found, this parameter will be set to the value of start position of the found match.</param>
        /// <returns>true, if a match is found. false - otherwise.</returns>
        private static bool SectionMatchesPattern(string input, int endIndex, string patternSection, out int matchStartPosition)
        {
            int currentPatternIndex = patternSection.Length;
            int currentInputIndex = endIndex;
            while (input[--currentInputIndex] == input[endIndex]) ;
            int repetitionsInInput = endIndex - currentInputIndex - 1;
            while (patternSection[patternSection.Length - 1] == patternSection[--currentPatternIndex]) ;
            int repetitionsRequiredByPattern = patternSection.Length - 1 - currentPatternIndex;
            if (repetitionsRequiredByPattern > repetitionsInInput)
            {
                matchStartPosition = -1;
                return false;
            }

            if (patternSection.Length - 1 - repetitionsRequiredByPattern != endIndex - currentInputIndex)
            {
                matchStartPosition = -1;
                return false;
            }

            for (; currentPatternIndex > 0 && currentInputIndex > 0; currentPatternIndex--)
            {
                if (!CharactersMatch(input[currentInputIndex--], patternSection, currentPatternIndex))
                {
                    matchStartPosition = -1;
                    return false;
                }
            }

            matchStartPosition = currentInputIndex;
            return true;
        }

        private static bool CharactersMatch(char input, string pattern, int patternIndex)
        {
            bool result = false;

            char patternChar = pattern[patternIndex];
            if (patternChar == WellKnownPatternCharacters.Dot)
            {
                result = true;
            }
            else if (patternChar == WellKnownPatternCharacters.Star)
            {
                result = CharactersMatch(input, pattern, patternIndex - 1);
            }
            else
            {
                result = input == patternChar;
            }

            return result;
        }

        /// <summary>
        /// Splits the pattern into sections by the '*' character.
        /// </summary>
        /// <param name="pattern">The pattern to split into sections.</param>
        /// <returns>Sections of the pattern</returns>
        /// <remarks>This method removes the '*' characters. This is key as this normalizes the pattern. The following '**' example does make no sense as it can be replaced with a single '*' only.</remarks>
        private static string[] NormalizePattern(string pattern)
        {
            // TODO: Normalize a pattern like this 'cc*cccc*c*' to become simple 'ccccc*', as these are equal patterns
            return pattern.Split(patternNormalizationArray, StringSplitOptions.RemoveEmptyEntries);
        }

        private static class WellKnownPatternCharacters
        {
            public static char Star = '*';

            public static char Dot = '.';
        }
    }
}
