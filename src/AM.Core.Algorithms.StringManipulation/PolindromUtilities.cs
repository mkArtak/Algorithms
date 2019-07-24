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
            for (int i = 0; i < input.Length; i++)
            {
                // All the single-characters are polindromes
                map[i, i] = true;
            }

            for (int i = 0; i < input.Length - 1; i++)
            {
                // All the double-character strings are polindrome, only if both characters are the same
                map[i, i + 1] = input[i] == input[i + 1];
            }

            string maxPolindrome = string.Empty;

            for (int lengthToConsider = 3; lengthToConsider <= input.Length; lengthToConsider++)
            {
                for (int i = 0; i <= input.Length - lengthToConsider; i++)
                {
                    // The substring starting at character i of length `lengthToConsider` is polindrome, if the first and last characters are the same and the substring without those characters is polindrome.
                    if (input[i] == input[i + lengthToConsider - 1])
                    {
                        bool isSubstringPolindrome = map[i + 1, i + lengthToConsider - 2];
                        map[i, i + lengthToConsider - 1] = isSubstringPolindrome;
                        if (isSubstringPolindrome)
                        {
                            maxPolindrome = input.Substring(i, lengthToConsider);
                        }
                    }
                }
            }

            return maxPolindrome;
        }
    }
}
