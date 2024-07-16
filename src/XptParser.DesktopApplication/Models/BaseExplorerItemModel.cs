using System;
using System.Collections.Generic;
using System.IO;

namespace XptParser.DesktopApplication
{
    public abstract class BaseExplorerItemModel
    {
        public Guid ID { get; init; }

        public string Name { get; set; }

        public IEnumerable<ExplorerItemCommandModel> Commands { get; init; }

        public BaseExplorerItemModel(string fullPath, IEnumerable<ExplorerItemCommandModel> commands)
        {
            this.ID = Guid.NewGuid();

            this.Name = Path.GetFileName(fullPath);
            this.Commands = commands;
        }
    }
}