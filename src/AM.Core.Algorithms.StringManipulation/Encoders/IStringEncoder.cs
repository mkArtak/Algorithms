namespace AM.Core.Algorithms.StringManipulation.Encoders
{
    /// <summary>
    /// Represents a contract for encoding and decoding strings
    /// </summary>
    public interface IStringEncoder
    {
        /// <summary>
        /// Encodes the given input string.
        /// </summary>
        /// <param name="input">The string to encode.</param>
        /// <returns>The encoded string.</returns>
        string Encode(string input);

        /// <summary>
        /// Decodes the given input string.
        /// </summary>
        /// <param name="input">The string to decode.</param>
        /// <returns>The decoded string.</returns>
        string Decode(string input);
    }
}
