using System;

namespace XptParser.DesktopApplication
{
    [Serializable]
    public sealed class ExplorerItemAlreadyExistsException : Exception
    {
        public string ExplorerItemName { get; init; }

        public ExplorerItemAlreadyExistsException(string explorerItemName) : base($"The item '{explorerItemName}' already exists") =>
            this.ExplorerItemName = explorerItemName;
    }
}