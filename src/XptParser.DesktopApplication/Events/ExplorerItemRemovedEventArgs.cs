using System;

namespace XptParser.DesktopApplication
{
    /// <summary>
    /// Represents event arguments for when an Explorer item is removed.
    /// </summary>
    public sealed class ExplorerItemRemovedEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the Explorer item that was removed.
        /// </summary>
        public BaseExplorerItemViewModel RemovedExplorerItem { get; init; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExplorerItemRemovedEventArgs"/> class.
        /// </summary>
        /// <param name="removedExplorerItem">The Explorer item that was removed.</param>
        public ExplorerItemRemovedEventArgs(BaseExplorerItemViewModel removedExplorerItem) =>
            this.RemovedExplorerItem = removedExplorerItem;
    }
}