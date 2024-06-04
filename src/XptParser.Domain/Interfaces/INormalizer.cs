namespace XptParser.Domain
{
    /// <summary>
    /// Provides methods for normalizing strings
    /// </summary>
    public interface INormalizer
    {
        /// <summary>
        /// Normalizes a provided string
        /// </summary>
        /// <param name="str">A string requiring normalization</param>
        /// <returns>Normalized string</returns>
        public string Normalize(string str);
    }
}