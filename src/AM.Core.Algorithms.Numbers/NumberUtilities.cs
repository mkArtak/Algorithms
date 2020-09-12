using System;
using System.Collections.Generic;
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

        public static int ConvertRomanToInt(string roman)
        {
            var map = new Dictionary<string, int> {
                {"I", 1 },
                {"IV", 4 },
                {"V", 5},
                {"IX", 9},
                {"X", 10},
                {"XL", 40},
                {"L", 50},
                {"XC", 90},
                {"C", 100},
                {"CD", 400},
                {"D", 500},
                {"CM", 900},
                {"M", 1000},
            };

            int result = 0;

            int currentIndex = 0;
            while (currentIndex < roman.Length - 1)
            {
                // Test for double digit option
                if (map.TryGetValue($"{roman[currentIndex]}{roman[currentIndex + 1]}", out var value))
                {
                    currentIndex += 2;
                }
                else if (map.TryGetValue(roman[currentIndex].ToString(), out value))
                {
                    currentIndex++;
                }
                else
                    throw new ArgumentException("Unknown roman character");

                result += value;
            }

            if (currentIndex < roman.Length)
            {
                result += map[roman[roman.Length - 1].ToString()];
            }

            return result;
        }

        /// <summary>
        /// Divides the given <paramref name="dividend"/> on the <paramref name="devisor"/> without using the `devision` operator.
        /// </summary>
        /// <param name="dividend">The number to divide.</param>
        /// <param name="devisor">The number to divide on.</param>
        /// <returns>The whole part of the devision result.</returns>
        public static int DivideNumbers(int dividend, int devisor)
        {
            if (devisor == 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (dividend == 0)
            {
                return 0;
            }

            if (devisor == 1)
                return dividend;

            if (devisor == -1)
            {
                try
                {
                    checked
                    {
                        return -dividend;
                    }
                }
                catch (OverflowException)
                {
                    return Int32.MaxValue;
                }
            }

            if (dividend == devisor)
            {
                return 1;
            }

            int result = DivideNumbers(dividend.ToString(), devisor);

            return result;
        }

        public static int DivideNumbers(string divident, int devisor)
        {
            int result = 0;

            bool isDividentNegative = IsNegative(divident, out divident);
            bool isDevisorNegative = devisor < 0;
            if (isDevisorNegative)
            {
                devisor = -devisor;
            }

            bool isResultNegative = isDividentNegative ^ isDevisorNegative;

            int currentIndex = 0;
            int currentNumber = 0;
            while (currentIndex < divident.Length)
            {
                int currentDigit = Int32.Parse(divident[currentIndex++].ToString());
                currentNumber = currentNumber * 10 + currentDigit;

                int tmp = 0;
                if (currentNumber == 0 || currentNumber >= devisor)
                {
                    tmp = currentNumber / devisor;
                    currentNumber -= tmp * devisor;
                }

                result = result * 10 + tmp;
            }

            return isResultNegative ? -result : result;
        }

        private static bool IsNegative(string input, out string number)
        {
            const int minusCharacter = '-';

            if (input[0] == minusCharacter)
            {
                number = input.Substring(1);
                return true;
            }

            number = input;

            return false;
        }
    }
}
