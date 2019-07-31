using System;

namespace AM.Core.Algorithms.StringManipulation
{
    public static class PolindromUtilities
    {
        public static bool IsPolindrome(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            if (input.Length > 1)
            {
                int currentIndex = 0;
                int mirrorIndex = input.Length - 1;

                do
                {
                    if (input[currentIndex] != input[mirrorIndex])
                    {
                        return false;
                    }

                } while (++currentIndex < --mirrorIndex);
            }

            return true;
        }

        public static int GetCharacterIndexToRemoveToMakePolindrom(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            int stepBackIndex = 0;

            if (input.Length > 1)
            {
                int failures = 0;
                int currentIndex = 0;
                int mirrorIndex = input.Length - 1;

                while (true)
                {
                    if (input[currentIndex] != input[mirrorIndex])
                    {
                        if (failures == 0)
                        {
                            // We found the first inequalities.
                            // There are two options to remove either one of the characters we're pointing to.
                            stepBackIndex = currentIndex;
                            currentIndex++;
                            failures++;
                        }
                        else if (failures == 1)
                        {
                            // We've already removed one character but hit another failure. We need to step back and remove the other character
                            currentIndex = stepBackIndex;
                            mirrorIndex = input.Length - currentIndex - 1;

                            // The character to try to remove is at mirrorIndex
                            stepBackIndex = mirrorIndex--;
                            failures++;
                        }
                        else
                        {
                            throw new ArgumentException("No way to change the string to polindrom by removing a single character");
                        }
                    }
                    else
                    {
                        currentIndex++;
                        mirrorIndex--;

                        if (currentIndex >= mirrorIndex)
                        {
                            break;
                        }
                    }
                }
            }

            return stepBackIndex;
        }

        /// <summary>
        /// Finds the longest polindromic substring of the given input.
        /// </summary>
        /// <param name="input">The input string to find polindromes in.</param>
        /// <returns>The longest polindromic substring.</returns>
        /// <remarks>This method is based on dynamic programming solution and has a time complexity of O(n^2) and space complexity of O(n^2), where n is the length of the provided input string.</remarks>
        public static string GetLongestPolindrome(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException();
            }

            if (input.Length == 0)
            {
                return string.Empty;
            }

            if (input.Length == 1)
            {
                return input;
            }

            if (input.Length == 2)
            {
                if (input[0] == input[1])
                {
                    return input;
                }
                else
                {
                    return input[0].ToString();
                }
            }

            bool[,] map = new bool[input.Length, input.Length];

            int maxPolindromeStart = 0;
            int maxPolindromeLength = 1;

            for (int i = 0; i < input.Length; i++)
            {
                // All the single-characters are polindromes
                map[i, i] = true;
            }

            for (int i = 0; i < input.Length - 1; i++)
            {
                // All the double-character strings are polindrome, only if both characters are the same
                if (map[i, i + 1] = input[i] == input[i + 1])
                {
                    if (maxPolindromeLength < 2)
                    {
                        maxPolindromeStart = i;
                        maxPolindromeLength = 2;
                    }
                }
            }

            for (int lengthToConsider = 3; lengthToConsider <= input.Length; lengthToConsider++)
            {
                for (int i = 0; i <= input.Length - lengthToConsider; i++)
                {
                    // The substring starting at character i of length `lengthToConsider` is polindrome, if the first and last characters are the same and the substring without those characters is polindrome.
                    int j = i + lengthToConsider - 1;
                    if (input[i] == input[j] && map[i + 1, j - 1])
                    {
                        map[i, j] = true;
                        if (maxPolindromeLength < lengthToConsider)
                        {
                            maxPolindromeStart = i;
                            maxPolindromeLength = lengthToConsider;
                        }
                    }
                }
            }

            return input.Substring(maxPolindromeStart, maxPolindromeLength);
        }

        /// <summary>
        /// Finds the longest polindromic substring of the given input.
        /// </summary>
        /// <param name="input">The input string to find polindromes in.</param>
        /// <returns>The longest polindromic substring.</returns>
        /// <remarks>This method is based on the fact that polindromes are symmetic to their center. The time complexity for this algorithm is O(n^2) and space complexity of O(1), where n is the length of the provided input string.</remarks>
        public static string GetLongestPolindrome2(string input)
        {
            if (input == null || input.Length <= 1)
                return input;

            if (input.Length == 2)
            {
                return input[0] == input[1] ? input : input[0].ToString();
            }
            int savedMaxLength = 1;
            int maxStartIndex = 0;

            for (int i = 0; i < input.Length; i++)
            {
                // Let's consider two possible polindromes here.
                // The first one has input[i] as it's center (odd length)
                // The second one has center between input[i] and input[i+1] (even length)

                int oddLength = GetPolindromeLengthAtPosition(input, i, i);
                int evenLength = GetPolindromeLengthAtPosition(input, i, i + 1);

                int maxLength = Math.Max(oddLength, evenLength);
                int startIndex = i - (maxLength - 1) / 2;
                int endIndex = i + maxLength / 2;

                if (maxLength > savedMaxLength)
                {
                    maxStartIndex = startIndex;
                    savedMaxLength = maxLength;
                }
            }

            return input.Substring(maxStartIndex, savedMaxLength);
        }

        private static int GetPolindromeLengthAtPosition(string input, int leftIndex, int rightIndex)
        {
            while (leftIndex >= 0 && rightIndex < input.Length && input[leftIndex] == input[rightIndex])
            {
                leftIndex--;
                rightIndex++;
            }

            return rightIndex - leftIndex - 1;
        }
    }
}
