using System;
using System.IO;
using System.Threading.Tasks;
using XptParser.Contracts;

namespace XptParser.BusinessLayer
{
    /// <summary>
    /// Provides functionality to read documents from the local machine file system
    /// </summary>
    public class LocalMachineDocumentReader : IDocumentReader
    {
        /// <summary>
        /// Asynchronously reads the contents of a file at the specified path as a <see cref="Stream"/>
        /// </summary>
        /// <param name="fullPath">The full path to the file</param>
        /// <returns>A <see cref="Task{Stream}"/> representing the asynchronous read operation</returns>
        /// <exception cref="ArgumentException">Thrown if <paramref name="fullPath"/> is null, empty, or whitespace</exception>
        public virtual async Task<Stream> ReadAsStreamAsync(string fullPath)
        {
            ArgumentException.ThrowIfNullOrEmpty(fullPath, nameof(fullPath));
            ArgumentException.ThrowIfNullOrWhiteSpace(fullPath, nameof(fullPath));

            return await ReadAsync(fullPath);
        }

        /// <summary>
        /// Opens the file at the specified path for reading and returns a <see cref="Stream"/>
        /// </summary>
        /// <param name="fullPath">The full path to the file</param>
        /// <returns>A task that returns the file stream</returns>
        private Task<Stream> ReadAsync(string fullPath)
        {
            return Task.Run(() => File.OpenRead(fullPath) as Stream);
        }
    }
}