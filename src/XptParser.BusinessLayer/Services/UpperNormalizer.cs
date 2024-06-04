using XptParser.Domain;

namespace XptParser.BusinessLayer
{
    /// <summary>
    /// Provides methods for normalizing strings to uppercase
    /// </summary>
    public class UpperNormalizer : INormalizer
    {
        /// <summary>
        /// Normalizes a provided string to uppercase
        /// </summary>
        /// <param name="str">A string requiring normalization</param>
        /// <returns>Normalized string</returns>
        public virtual string Normalize(string str)
        {
            return str.ToUpperInvariant();
        }
    }
}