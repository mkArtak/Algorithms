using System;
using System.Text;

namespace AM.Core.Algorithms.StringManipulation
{
    public static class StringUtilities
    {
        public static void Swap<T>(T[] data, int index1, int index2)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            if (index1 >= data.Length || index1 < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index1));
            }

            if (index2 >= data.Length || index2 < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index2));
            }

            if (index1 != index2)
            {
                T temp = data[index1];
                data[index1] = data[index2];
                data[index2] = temp;
            }
        }

        public static string Swap(string data, int index1, int index2)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            if (index1 >= data.Length || index1 < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index1));
            }

            if (index2 >= data.Length || index2 < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index2));
            }

            StringBuilder sb = new StringBuilder();
            int minIndex = Math.Min(index1, index2);
            int maxIndex = Math.Max(index1, index2);
            sb.Append(data.Substring(0, minIndex));
            sb.Append(data[maxIndex]);
            sb.Append(data.Substring(minIndex + 1, maxIndex - minIndex - 1));
            sb.Append(data[minIndex]);
            sb.Append(data.Substring(maxIndex + 1));

            return sb.ToString();
        }

        public static string Reverse(string data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            char[] dataChars = data.ToCharArray();
            Reverse(dataChars);
            return new string(dataChars);
        }

        public static void Reverse<T>(T[] data)
        {
            Reverse(data, 0, data.Length - 1);
        }

        private static void Reverse<T>(T[] data, int startIndex, int endIndex)
        {
            int index = startIndex;
            int mirrorIndex = endIndex;

            while (index < mirrorIndex)
            {
                Swap(data, index++, mirrorIndex--);
            }
        }

        public static string ReverseByWords(string data, char separator = ' ')
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            char[] dataChars = data.ToCharArray();
            int lastWordStartIndex = 0;
            for (int i = 0; i < dataChars.Length; i++)
            {
                if (dataChars[i] == separator)
                {
                    if (lastWordStartIndex < i - 1)
                    {
                        Reverse(dataChars, lastWordStartIndex, i - 1);
                    }

                    lastWordStartIndex = i + 1;
                }
            }

            if (lastWordStartIndex < dataChars.Length - 1)
            {
                Reverse(dataChars, lastWordStartIndex, dataChars.Length - 1);
            }

            Reverse(dataChars);

            return new string(dataChars);
        }
    }
}
