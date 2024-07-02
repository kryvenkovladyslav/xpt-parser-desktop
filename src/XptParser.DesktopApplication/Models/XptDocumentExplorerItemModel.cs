using System.Collections.Generic;

namespace XptParser.DesktopApplication
{
    public sealed class XptDocumentExplorerItemModel : BaseExplorerItemModel
    {
        public string FullPath { get; set; }

        public XptDocumentExplorerItemModel(string fullPath, IEnumerable<ExplorerItemCommandModel> commands) : base(fullPath, commands) => 
            this.FullPath = fullPath;
    }
}