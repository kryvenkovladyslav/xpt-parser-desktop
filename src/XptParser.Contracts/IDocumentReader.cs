using System.IO;
using System.Threading.Tasks;

namespace XptParser.Contracts
{
    /// <summary>
    /// Provides methods for reading documents
    /// </summary>
    public interface IDocumentReader
    {
        /// <summary>
        /// Asynchronously reads the document using the full path
        /// </summary>
        /// <param name="fullPath">The full path to the required document</param>
        /// <returns>The stream representing the document</returns>
        public Task<Stream> ReadAsStreamAsync(string fullPath);
    }
}