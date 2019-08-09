using System;

namespace AM.Core.Algorithms.StringManipulation.Converters
{
    public class LinearZigZagStringConverter : IZigZagStringConverter
    {
        public string Convert(string input, int numRows)
        {
            if (input == null || input.Length <= 1 || numRows == 1)
            {
                return input;
            }

            if (numRows <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            Console.WriteLine($"Converting `{input}`");

            char[] result = new char[input.Length];
            int period = 2 * numRows - 2;
            int resultIndex = 0;

            // We know that each element from the first `virtual column` will be repeated in the final string periodically with `2*numRows - 2` period.
            for (int firstRowElementIndex = 0; firstRowElementIndex < input.Length; firstRowElementIndex += period)
            {
                result[resultIndex++] = input[firstRowElementIndex];
            }

            if (numRows >= 3)
            {
                for (int currentRowIndex = 1; currentRowIndex <= numRows - 2; currentRowIndex++)
                {
                    for (int i = 0; ; i++)
                    {
                        int element1Index = currentRowIndex + i * period;
                        if (element1Index >= input.Length)
                        {
                            break;
                        }

                        result[resultIndex++] = input[element1Index];

                        int element2Index = (i + 1) * period - currentRowIndex;
                        if (element2Index >= input.Length)
                        {
                            break;
                        }

                        result[resultIndex++] = input[element2Index];
                    }
                }
            }

            for (int lastRowIndex = numRows - 1; lastRowIndex < input.Length; lastRowIndex += period)
            {
                result[resultIndex++] = input[lastRowIndex];
            }

            return new string(result);
        }
    }
}
