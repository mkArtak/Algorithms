using System;
using System.Text;

namespace AM.Core.Algorithms.Numbers
{
    public static class NumberUtilities
    {
        /// <summary>
        /// Reverses the digits of the given integer.
        /// </summary>
        /// <param name="input">The number to reverse</param>
        /// <returns>A new nuber with reversed digits. If the reversing process results in an overflow, the result will be 0.</returns>
        public static int Reverse(int input)
        {
            int reversed = 0;
            while (input != 0)
            {
                int digit = input % 10;
                try
                {
                    checked
                    {
                        reversed = reversed * 10 + digit;
                    }
                }
                catch
                {
                    return 0;
                }

                input /= 10;
            }

            return reversed;
        }

        public static int ToInt(string input)
        {
            if (input == null || input.Length == 0)
            {
                return 0;
            }

            int startIndex = 0;
            while (input[startIndex++] == ' ' && startIndex < input.Length) ;
            startIndex--;

            int sign = 1;
            if (input[startIndex] == '+')
            {
                startIndex++;
            }
            else if (input[startIndex] == '-')
            {
                sign = -1;
                startIndex++;
            }

            if (startIndex == input.Length)
            {
                // The input is an string with all whitespace characters.
                return 0;
            }

            int result = 0;
            char currentChar;

            int maxDigitCode = (int)'9';
            int minDigitCode = (int)'0';
            do
            {
                currentChar = input[startIndex++];
                if (currentChar < minDigitCode || currentChar > maxDigitCode)
                    break;

                int digitValue = currentChar - minDigitCode;
                checked
                {
                    result = result * 10 + digitValue;
                }

            } while (startIndex < input.Length);

            return result * sign;
        }

        /// <summary>
        /// This is the implementation for LeetCode Integer-to-Roman problem: https://leetcode.com/problems/integer-to-roman/
        /// </summary>
        /// <param name="number">The number to convert</param>
        /// <returns>The Roman representation of the input number</returns>
        public static string ConvertIntToRoman(int number)
        {
            if (number < 1 || number > 3999)
            {
                throw new ArgumentOutOfRangeException();
            }

            StringBuilder sb = new StringBuilder();

            int[] indicies = new[] { 1, 4, 5, 9, 10, 40, 50, 90, 100, 400, 500, 900, 1000 };
            string[] map = new[] { "I", "IV", "V", "IX", "X", "XL", "L", "XC", "C", "CD", "D", "CM", "M" };
            int mapIndex = indicies.Length - 1;
            while (number > 0)
            {
                int repetitions = number / indicies[mapIndex];
                if (repetitions > 0)
                {
                    number = number % indicies[mapIndex];
                    for (int i = 0; i < repetitions; i++)
                    {
                        sb.Append(map[mapIndex]);
                    }
                }

                mapIndex--;
            }

            return sb.ToString();
        }
    }
}
