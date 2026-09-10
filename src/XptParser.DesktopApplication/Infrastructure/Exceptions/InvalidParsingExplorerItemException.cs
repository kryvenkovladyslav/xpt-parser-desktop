using System;

namespace XptParser.DesktopApplication
{
    /// <summary>
    /// Represents an exception that occurs when an Explorer item cannot be parsed.
    /// </summary>
    [Serializable]
    public sealed class InvalidParsingExplorerItemException : Exception
    {
        /// <summary>
        /// Gets the Explorer item that could not be parsed.
        /// </summary>
        public BaseExplorerItemModel ExplorerItem { get; init; }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidParsingExplorerItemException"/> class.
        /// </summary>
        /// <param name="explorerItem">The Explorer item that could not be parsed.</param>
        public InvalidParsingExplorerItemException(BaseExplorerItemModel explorerItem) : base($"The item '{explorerItem.Name}' cannot be parsed") =>
            this.ExplorerItem = explorerItem;
    }
}