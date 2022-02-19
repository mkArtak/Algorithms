using System;
using System.Text;

namespace AM.Core.Algorithms.Numbers
{
    public static class DigitsStripper
    {
        /// <summary>
        /// Removed the <paramref name="k"/> digits from the given <paramref name="num"/> string,
        /// so that the resulting string has the largest possible value.
        /// </summary>
        /// <param name="num">String which consists of numerical digits</param>
        /// <param name="k">The number of digits to remove</param>
        /// <returns>The resulting string.</returns>
        public static string RemoveKdigits(string num, int k)
        {
            if (k == 0)
                return num;

            if (num.Length == 0)
                return num;

            if (k >= num.Length)
                return "0";

            StringBuilder sb = new StringBuilder(num);
            RemoveKdigitsRecursive(sb, k);
            if (sb.Length == 0)
                return "0";

            return sb.ToString();
        }

        public static void RemoveKdigitsRecursive(StringBuilder num, int k)
        {
            if (k == 0)
                return;

            if (num.Length == 0)
                return;

            if (k >= num.Length)
            {
                num = new StringBuilder("0");
                return;
            }

            var indexToRemove = FindIndexToRemove(num);
            RemoveDigit(num, indexToRemove);
            RemoveKdigitsRecursive(num, k - 1);

            while (num.Length > 0 && num[0] == '0')
                num.Remove(0, 1);
        }

        private static int FindIndexToRemove(StringBuilder number)
        {
            if (number.Length == 1)
                return 0;

            for (int i = 0; i < number.Length - 1; i++)
            {
                if (Convert.ToInt32(number[i]) > Convert.ToInt32((char)number[i + 1]))
                    return i;
            }

            return number.Length - 1;
        }

        private static void RemoveDigit(StringBuilder num, int indexToRemove)
        {
            if (indexToRemove > num.Length - 1)
                throw new ArgumentException();

            num.Remove(indexToRemove, 1);
        }

        /*
        1432219
        1 32219
        1  2219
        1   219
        */
    }
}
