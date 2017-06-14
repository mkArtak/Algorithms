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

            //if (input.Length == 1)
            //{
            //    // As an empty string is polindrom, removal of the only character would make it polindrom.
            //    return 0;
            //}

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
    }
}
