namespace AM.Core.Algorithms.StringManipulation.Converters
{
    /// <summary>
    /// Represents a contract for zig-zag string convertion implementations
    /// </summary>
    public interface IZigZagStringConverter
    {
        /// <summary>
        /// Convert 
        /// </summary>
        /// <param name="input">The string to convert.</param>
        /// <param name="numRows">The number of rows to convert through.</param>
        /// <returns>The converted string.</returns>
        string Convert(string input, int numRows);
    }
}
