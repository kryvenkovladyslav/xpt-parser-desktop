using System;

namespace XptParser.Domain
{
    /// <summary>
    /// Represents a library header record of the XPT Document
    /// </summary>
    public sealed class XptLibraryHeader
    {
        /// <summary>
        /// Represents a version specified in the library header record
        /// </summary>
        public string Version { get; init; }

        /// <summary>
        /// Represents an operating system specified in the library header record
        /// </summary>
        public string OperationSystem { get; init; }

        /// <summary>
        /// Represents a first time when the document was created 
        /// </summary>
        public DateTime CreatedDateTime { get; init; }

        /// <summary>
        /// Represents a last time when the document was modified 
        /// </summary>
        public DateTime LastModifiedDateTime { get; init; }
    }
}