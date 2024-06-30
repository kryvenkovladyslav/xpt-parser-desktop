using System;
using System.IO;
using System.Threading.Tasks;
using XptParser.Contracts;

namespace XptParser.BusinessLayer
{
    public class LocalMachineDocumentReader : IDocumentReader
    {
        public virtual async Task<Stream> ReadAsStreamAsync(string fullPath)
        {
            ArgumentException.ThrowIfNullOrEmpty(fullPath, nameof(fullPath));
            ArgumentException.ThrowIfNullOrWhiteSpace(fullPath, nameof(fullPath));

            return await ReadAsync(fullPath);
        }

        private Task<Stream> ReadAsync(string fullPath)
        {
            return Task.Run(() => File.OpenRead(fullPath) as Stream);
        }
    }
}