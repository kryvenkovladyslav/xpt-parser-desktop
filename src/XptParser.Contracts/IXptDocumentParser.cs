﻿using System.IO;
using XptParser.Domain;
using System.Threading.Tasks;

namespace XptParser.Contracts
{
    /// <summary>
    /// Provides methods for parsing XPT Document into .NET object
    /// </summary>
    public interface IXptDocumentParser
    {
        /// <summary>
        /// Asynchronously parses the XPT Document
        /// </summary>
        /// <param name="documentStream">The stream representing required XPT Document</param>
        /// <returns>Parsed XPT Document</returns>
        public Task<XptDocument> ParseAsync(Stream documentStream);
    }
}