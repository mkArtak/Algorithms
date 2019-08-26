using System;
using System.Collections.Generic;
using System.Text;

namespace AM.Core.Algorithms.StringManipulation.Encoders
{
    /// <summary>
    /// Represents a string encoder which would encode "abcabcdabgbgh" as "2[abc]da2[bg]h".
    /// </summary>
    /// <remarks>This converter works on strings, which contain only characters a-z.</remarks>
    public class RepetitiveStringEncoder : IStringEncoder
    {
        /// <summary>
        /// Decodes an input string.
        /// </summary>
        /// <param name="input">The encoded string to decode.</param>
        /// <returns>The decoded string.</returns>
        public string Decode(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException();
            }

            if (input.Length == 0)
            {
                return input;
            }

            return Decode(input.ToCharArray(), 0, input.Length - 1);
        }

        private static string Decode(char[] input, int startIndex, int endIndex)
        {
            StringBuilder result = new StringBuilder();
            int currentIndex = startIndex;

            while (currentIndex <= endIndex)
            {
                while (currentIndex <= endIndex && IsLetter(input[currentIndex]))
                {
                    result.Append(input[currentIndex++]);
                }

                if (currentIndex <= endIndex)
                {
                    int sectionStart = currentIndex;
                    while (currentIndex <= endIndex && IsDigit(input[currentIndex]))
                    {
                        currentIndex++;
                    }

                    int repetitions = ParseInt(input, sectionStart, currentIndex - sectionStart);
                    if (currentIndex == sectionStart || currentIndex == endIndex + 1 || input[currentIndex] != '[')
                    {
                        throw new FormatException("The input string is invalid");
                    }

                    sectionStart = currentIndex + 1;
                    Stack<char> section = new Stack<char>();
                    section.Push('[');
                    while (section.Count != 0)
                    {
                        currentIndex++;
                        if (currentIndex == endIndex + 1)
                        {
                            throw new FormatException("The input is improperly formatted");
                        }

                        char currentChar = input[currentIndex];
                        if (currentChar == '[')
                        {
                            section.Push(currentChar);
                        }
                        else if (currentChar == ']')
                        {
                            section.Pop();
                        }
                    }

                    string stringToRepeat = Decode(input, sectionStart, currentIndex - 1);
                    for (int i = 0; i < repetitions; i++)
                    {
                        result.Append(stringToRepeat);
                    }

                    currentIndex++;
                }
            }

            return result.ToString();
        }

        private static int ParseInt(char[] input, int start, int numberOfCharacters)
        {
            int result = 0;
            for (int i = 0; i < numberOfCharacters; i++)
            {
                int charValue = input[start + i] - '0';
                result += charValue * (int)Math.Pow(10, numberOfCharacters - i - 1);
            }

            return result;
        }

        public string Encode(string input)
        {
            throw new NotImplementedException();
        }

        private static bool IsLetter(char c)
        {
            return c >= 'a' && c <= 'z';
        }

        private static bool IsDigit(char c)
        {
            return c >= '0' && c <= '9';
        }
    }
}
