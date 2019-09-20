using System;
using System.Collections.Generic;

namespace AM.Core.Algorithms.Puzzles
{
    /// <summary>
    ///  Given a string containing digits from 2-9 inclusive, return all possible letter combinations that the number could represent.
    /// </summary>
    /// <remarks>This is LeetCode problem https://leetcode.com/problems/letter-combinations-of-a-phone-number/</remarks>
    public class PhoneNumberTextGenerator
    {
        private static Dictionary<int, string> map = new Dictionary<int, string>
        {
            { '2', "abc" },
            {'3', "def" },
            {'4', "ghi" },
            {'5', "jkl"},
            {'6', "mno" },
            {'7', "pqrs" },
            {'8', "tuv" },
            {'9', "wxyz" },
            {'0', " " },
        };

        public IList<string> GetAllCombinations(string digits)
        {
            if (digits == null)
            {
                throw new ArgumentNullException();
            }

            if (digits == string.Empty)
            {
                return new string[] { };
            }

            return GetCombinations(string.Empty, ref digits, 0);
        }

        private static IList<string> GetCombinations(string prefix, ref string digits, int index)
        {
            if (index == digits.Length)
                return new[] { prefix };

            if (map.TryGetValue(digits[index], out string prefixOptions))
            {
                IList<string> result = new List<string>();
                int nextIndex = index + 1;

                foreach (char currentPrefix in prefixOptions)
                {
                    var combinations = GetCombinations(prefix + currentPrefix, ref digits, nextIndex);
                    foreach (var childItem in combinations)
                    {
                        result.Add(childItem);
                    }
                }

                return result;
            }

            throw new ArgumentException("Unexpected character detected");
        }
    }
}
