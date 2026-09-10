using System.Collections.Generic;

namespace XptParser.DesktopApplication
{
    /// <summary>
    /// Represents a model for an unsupported Explorer item.
    /// </summary>
    public sealed class UnsupportedExplorerItemModel : BaseExplorerItemModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnsupportedExplorerItemModel"/> class.
        /// </summary>
        /// <param name="fullPath">The full path of the Explorer item.</param>
        /// <param name="commands">The commands associated with the Explorer item.</param>
        public UnsupportedExplorerItemModel(string fullPath, IEnumerable<ExplorerItemCommandModel> commands) : base(fullPath, commands) { }
    }
}