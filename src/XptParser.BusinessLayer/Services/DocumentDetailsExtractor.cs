using System;
using System.IO;
using XptParser.Domain;

namespace XptParser.BusinessLayer
{
    /// <summary>
    /// Provides methods for extracting details of the document
    /// </summary>
    public class DocumentDetailsExtractor : IDocumentDetailsExtractor
    {
        /// <summary>
        /// Provides methods for normalizing strings
        /// </summary>
        protected INormalizer Normalizer { get; private init; }

        /// <summary>
        /// Initializes an instance of the <see cref="DocumentDetailsExtractor"/> class
        /// </summary>
        /// <param name="normalizer">The implementation of <see cref="INormalizer"/></param>
        /// <exception cref="ArgumentNullException"></exception>
        public DocumentDetailsExtractor(INormalizer normalizer)
        {
            this.Normalizer = normalizer ?? throw new ArgumentNullException(nameof(normalizer));
        }

        /// <summary>
        /// Extracts the extension of the document
        /// </summary>
        /// <param name="fullPath">The full path of the required document</param>
        /// <returns>Extracted document extension</returns>
        public virtual string ExtractDocumentExtension(string fullPath)
        {
            return Path.GetExtension(fullPath);
        }

        /// <summary>
        /// Extracts the name of the document
        /// </summary>
        /// <param name="fullPath">The full path of the required document</param>
        /// <returns>Extracted document name</returns>
        public virtual string ExtractDocumentName(string fullPath)
        {
            return Path.GetFileName(fullPath);
        }
        /// <summary>
        /// Gets the normalized extension of the document
        /// </summary>
        /// <param name="fullPath">The full path of the required document</param>
        /// <returns>Normalized document extension</returns>
        public virtual string GetNormalizedDocumentExtension(string fullPath)
        {
            return this.NormalizeString(this.ExtractDocumentExtension(fullPath));
        }

        /// <summary>
        /// Gets the normalized name of the document
        /// </summary>
        /// <param name="fullPath">The full path of the required document</param>
        /// <returns>Normalized document name</returns>
        public virtual string GetNormalizedDocumentName(string fullPath)
        {
            return this.NormalizeString(this.ExtractDocumentName(fullPath));
        }

        /// <summary>
        /// Normalizes a provided string
        /// </summary>
        /// <param name="str">A string requiring normalization</param>
        /// <returns>Normalized string</returns>
        private string NormalizeString(string str)
        {
            return this.Normalizer.Normalize(str);
        }
    }
}