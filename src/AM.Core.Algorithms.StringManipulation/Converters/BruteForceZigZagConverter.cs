using System;
using System.Text;

namespace AM.Core.Algorithms.StringManipulation.Converters
{
    public class BruteForceZigZagConverter : IZigZagStringConverter
    {
        // This is a brute-force implementation for zig-zag convertion problem. Not optimal at all.
        public string Convert(string s, int numRows)
        {
            if (numRows <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (s == null)
                throw new ArgumentNullException();

            if (s.Length <= 1 || numRows == 1)
            {
                return s;
            }

            if (s.Length <= numRows)
            {
                return s;
            }

            if (numRows == 2)
            {
                char[] sb = new char[s.Length];
                int currentIndex = 0;
                for (int i = 0; i < s.Length; i += 2)
                {
                    sb[currentIndex++] = s[i];
                }
                for (int i = 1; i < s.Length; i += 2)
                {
                    sb[currentIndex++] = s[i];
                }

                return string.Join(string.Empty, sb);
            }
            else
            {
                int rowDirection = 1;
                int colDirection = 0;

                int currentRow = 0;
                int currentCol = 0;

                char?[,] map = new char?[numRows, (1 + (s.Length / (2 * numRows - 2))) * (numRows - 1)];
                for (int i = 0; i < s.Length; i++)
                {
                    map[currentRow, currentCol] = s[i];
                    currentRow += rowDirection;
                    currentCol += colDirection;

                    if (currentRow == 0)
                    {
                        // At the top of the row. Start moving down veritically
                        rowDirection = 1;
                        colDirection = 0;
                    }
                    else if (currentRow == numRows - 1)
                    {
                        // At the bottom of the row. Start moving up diagonally
                        rowDirection = -1;
                        colDirection = 1;
                    }
                }

                StringBuilder result = new StringBuilder(s.Length);
                for (int i = 0; i < numRows; i++)
                {
                    for (int j = 0; j < map.GetLength(1); j++)
                    {
                        if (map[i, j] != null)
                        {
                            result.Append(map[i, j]);
                        }
                    }
                }

                return result.ToString();
            }
        }
    }
}
