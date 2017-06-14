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
    }
}
