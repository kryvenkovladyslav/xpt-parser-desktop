using System;

namespace XptParser.DesktopApplication
{
    [Serializable]
    public sealed class InvalidParsingExplorerItemException : Exception
    {
        public BaseExplorerItemModel ExplorerItem { get; init; }

        public InvalidParsingExplorerItemException(BaseExplorerItemModel explorerItem) : base($"The item '{explorerItem.Name}' cannot be parsed") =>
            this.ExplorerItem = explorerItem;
    }
}