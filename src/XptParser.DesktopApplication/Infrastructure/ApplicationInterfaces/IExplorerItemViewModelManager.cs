using System;
using System.Collections.Generic;
using XptParser.Contracts;

namespace XptParser.DesktopApplication
{
    public interface IExplorerItemViewModelManager
    {
        public IDocumentDetailsExtractor DocumentDetailsExtractor { get; init; }

        public bool SupportEventCreation(string fileFullPath);

        public BaseExplorerItemViewModel Create(string fileFullPath, IEnumerable<ExplorerItemCommandModel> sharedCommands, Dictionary<Type, Delegate> eventHandlers = null);
    }
}