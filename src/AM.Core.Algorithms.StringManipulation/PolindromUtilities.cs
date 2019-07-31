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
        /// <param name="s">The input string to find polindromes in.</param>
        /// <returns>The longest polindromic substring.</returns>
        public static string GetLongestPolindrome(string s)
        {
            if (s == null)
            {
                throw new ArgumentNullException();
            }

            if (s.Length == 0)
            {
                return string.Empty;
            }

            if (s.Length == 1)
            {
                return s;
            }

            if (s.Length == 2)
            {
                if (s[0] == s[1])
                {
                    return s;
                }
                else
                {
                    return s[0].ToString();
                }
            }

            bool[,] map = new bool[s.Length, s.Length];

            int maxPolindromeStart = 0;
            int maxPolindromeLength = 1;

            for (int i = 0; i < s.Length; i++)
            {
                // All the single-characters are polindromes
                map[i, i] = true;
            }

            for (int i = 0; i < s.Length - 1; i++)
            {
                // All the double-character strings are polindrome, only if both characters are the same
                if (map[i, i + 1] = s[i] == s[i + 1])
                {
                    if (maxPolindromeLength < 2)
                    {
                        maxPolindromeStart = i;
                        maxPolindromeLength = 2;
                    }
                }
            }

            for (int lengthToConsider = 3; lengthToConsider <= s.Length; lengthToConsider++)
            {
                for (int i = 0; i <= s.Length - lengthToConsider; i++)
                {
                    // The substring starting at character i of length `lengthToConsider` is polindrome, if the first and last characters are the same and the substring without those characters is polindrome.
                    int j = i + lengthToConsider - 1;
                    if (s[i] == s[j] && map[i + 1, j - 1])
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

            return s.Substring(maxPolindromeStart, maxPolindromeLength);
        }
    }
}
