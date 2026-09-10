using System;

namespace XptParser.DesktopApplication
{
    /// <summary>
    /// Represents an exception that occurs when an Explorer item already exists.
    /// </summary>
    [Serializable]
    public sealed class ExplorerItemAlreadyExistsException : Exception
    {
        /// <summary>
        /// Gets the name of the Explorer item that already exists.
        /// </summary>
        public string ExplorerItemName { get; init; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExplorerItemAlreadyExistsException"/> class.
        /// </summary>
        /// <param name="explorerItemName">The name of the Explorer item that already exists.</param>
        public ExplorerItemAlreadyExistsException(string explorerItemName) : base($"The item '{explorerItemName}' already exists") =>
            this.ExplorerItemName = explorerItemName;
    }
}