using System.Collections.Generic;

namespace XptParser.DesktopApplication
{
    public sealed class UnsupportedExplorerItemModel : BaseExplorerItemModel
    {
        public UnsupportedExplorerItemModel(string fullPath, IEnumerable<ExplorerItemCommandModel> commands) : base(fullPath, commands) { }
    }
}