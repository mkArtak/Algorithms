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

            StringBuilder result = new StringBuilder();
            int currentIndex = 0;

            while (currentIndex < input.Length)
            {
                while (currentIndex < input.Length && IsLetter(input[currentIndex]))
                {
                    result.Append(input[currentIndex++]);
                }

                if (currentIndex < input.Length)
                {
                    int sectionStart = currentIndex;
                    while (currentIndex < input.Length && IsDigit(input[currentIndex]))
                    {
                        currentIndex++;
                    }

                    if (currentIndex < input.Length)
                    {
                        int repetitions = Int32.Parse(input.Substring(sectionStart, currentIndex - sectionStart));
                        if (input[currentIndex] != '[')
                        {
                            throw new FormatException("The input string is invalid");
                        }

                        sectionStart = currentIndex + 1;
                        Stack<char> section = new Stack<char>();
                        section.Push('[');
                        while (section.Count != 0)
                        {
                            currentIndex++;
                            if (currentIndex == input.Length)
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

                        /// This can be optimized further, if we don't initialize extra storage here for the substring.
                        /// For that, this function should be updated to operate over char[] instead.
                        string stringToRepeat = Decode(input.Substring(sectionStart, currentIndex - sectionStart));
                        for (int i = 0; i < repetitions; i++)
                        {
                            result.Append(stringToRepeat);
                        }

                        currentIndex++;
                    }
                }
            }

            return result.ToString();
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
