using System;

namespace XptParser.DesktopApplication
{
    public sealed class ExplorerItemRemovedEventArgs : EventArgs
    {
        public BaseExplorerItemViewModel RemovedExplorerItem { get; init; }

        public ExplorerItemRemovedEventArgs(BaseExplorerItemViewModel removedExplorerItem) => 
            this.RemovedExplorerItem = removedExplorerItem;
    }
}