namespace XptParser.Contracts
{
    /// <summary>
    /// Provides methods for extracting details of the document
    /// </summary>
    public interface IDocumentDetailsExtractor
    {
        /// <summary>
        /// Extracts the name of the document
        /// </summary>
        /// <param name="fullPath">The full path of the required document</param>
        /// <returns>Extracted document name</returns>
        public string ExtractDocumentName(string fullPath);

        /// <summary>
        /// Gets the normalized name of the document
        /// </summary>
        /// <param name="fullPath">The full path of the required document</param>
        /// <returns>Normalized document name</returns>
        public string GetNormalizedDocumentName(string fullPath);

        /// <summary>
        /// Extracts the extension of the document
        /// </summary>
        /// <param name="fullPath">The full path of the required document</param>
        /// <returns>Extracted document extension</returns>
        public string ExtractDocumentExtension(string fullPath);

        /// <summary>
        /// Gets the normalized extension of the document
        /// </summary>
        /// <param name="fullPath">The full path of the required document</param>
        /// <returns>Normalized document extension</returns>
        public string GetNormalizedDocumentExtension(string fullPath);
    }
}