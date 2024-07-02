using XptParser.Domain;
using System.Collections.Generic;
using System.Linq;
using XptParser.Contracts;

namespace XptParser.DesktopApplication
{
    public abstract class BaseExplorerItemViewModelCreator<TViewModel> : IExplorerItemViewModelCreator<TViewModel>
        where TViewModel : BaseExplorerItemViewModel
    {
        protected IDocumentDetailsExtractor DocumentDetailsExtractor { get; private init; }

        public BaseExplorerItemViewModelCreator(IDocumentDetailsExtractor documentDetailsExtractor) =>
            this.DocumentDetailsExtractor = documentDetailsExtractor;

        public abstract TViewModel CreateExplorerItem(string fileFullPath, IEnumerable<ExplorerItemCommandModel> sharedCommands);

        public virtual bool CanCreate(string fileFullPath)
        {
            var normalizedExtension = GetNormalizedItemExtension(fileFullPath);
            return DocumentExtensions.NormalizedSupportedExtensions.Contains(normalizedExtension);
        }

        protected virtual string GetNormalizedItemExtension(string fileFullPath)
        {
            return this.DocumentDetailsExtractor.GetNormalizedDocumentExtension(fileFullPath);
        }
    }
}