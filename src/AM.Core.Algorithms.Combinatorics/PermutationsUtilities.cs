using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AM.Core.Algorithms.Combinatorics
{
    public static class PermutationsUtilities
    {
        public static int GetSortedPermutationAt(int[] digits, int index)
        {
            if (digits == null)
            {
                throw new ArgumentNullException(nameof(digits));
            }

            if (digits.Length == 0)
            {
                throw new ArgumentException("Invalid digits set");
            }

            if (digits.Any(item => item < 0 || item > 9))
            {
                throw new ArgumentException("Digits can be from 0 to 9 only");
            }

            if (index < 0 || index >= GetFactorial(digits.Length))
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            IList<int> digitsLeft = digits.OrderBy(item => item).ToList();
            StringBuilder numberBuilder = new StringBuilder();
            FindSortedPermutationAt(digitsLeft, index, numberBuilder);
            return Int32.Parse(numberBuilder.ToString());
        }

        private static void FindSortedPermutationAt(IList<int> digitsLeft, int index, StringBuilder numberBuilder)
        {
            if (digitsLeft.Count == 1)
            {
                numberBuilder.Append(digitsLeft.Single());
                return;
            }

            // The current digit at the index is the digit at index, defined by the following formula
            int digitIndex = (index / GetFactorial(digitsLeft.Count - 1)) % digitsLeft.Count;
            numberBuilder.Append(digitsLeft[digitIndex]);
            digitsLeft.RemoveAt(digitIndex);

            FindSortedPermutationAt(digitsLeft, index, numberBuilder);
        }

        private static int GetFactorial(int number)
        {
            if (number < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (number == 0)
            {
                return 0;
            }

            int result = 1;
            for (int i = 2; i <= number; i++)
            {
                result *= i;
            }

            return result;
        }
    }
}
