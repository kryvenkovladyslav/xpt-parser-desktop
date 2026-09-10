using System;
using System.Collections.Generic;
using System.IO;

namespace XptParser.DesktopApplication
{
    /// <summary>
    /// Represents the base model for an Explorer item.
    /// </summary>
    public abstract class BaseExplorerItemModel
    {
        /// <summary>
        /// Gets the unique identifier of the Explorer item.
        /// </summary>
        public Guid ID { get; init; }

        /// <summary>
        /// Gets or sets the name of the Explorer item.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets the commands associated with the Explorer item.
        /// </summary>
        public IEnumerable<ExplorerItemCommandModel> Commands { get; init; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseExplorerItemModel"/> class.
        /// </summary>
        /// <param name="fullPath">The full path of the Explorer item.</param>
        /// <param name="commands">The commands associated with the Explorer item.</param>
        public BaseExplorerItemModel(string fullPath, IEnumerable<ExplorerItemCommandModel> commands)
        {
            this.ID = Guid.NewGuid();

            this.Name = Path.GetFileName(fullPath);
            this.Commands = commands;
        }
    }
}