using System.Collections.Generic;

namespace XptParser.DesktopApplication
{
    /// <summary>
    /// Represents a model for an XPT document Explorer item.
    /// </summary>
    public sealed class XptDocumentExplorerItemModel : BaseExplorerItemModel
    {
        /// <summary>
        /// Gets or sets the full path of the XPT document.
        /// </summary>
        public string FullPath { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="XptDocumentExplorerItemModel"/> class.
        /// </summary>
        /// <param name="fullPath">The full path of the XPT document.</param>
        /// <param name="commands">The commands associated with the Explorer item.</param>
        public XptDocumentExplorerItemModel(string fullPath, IEnumerable<ExplorerItemCommandModel> commands) : base(fullPath, commands) =>
            this.FullPath = fullPath;
    }
}