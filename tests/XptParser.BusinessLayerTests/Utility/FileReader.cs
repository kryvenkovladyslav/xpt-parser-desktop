using System.IO;

namespace XptParser.BusinessLayerTests
{
    /// <summary>
    /// The helper class for reading documents
    /// </summary>
    public static class FileReader
    {
        /// <summary>
        /// Reads file using provided path
        /// </summary>
        /// <param name="fullPath">The path to an existing file</param>
        /// <returns>The stream representing a file</returns>
        public static Stream ReadFile(string fullPath)
        {
            return File.OpenRead(fullPath); 
        }
    }
}