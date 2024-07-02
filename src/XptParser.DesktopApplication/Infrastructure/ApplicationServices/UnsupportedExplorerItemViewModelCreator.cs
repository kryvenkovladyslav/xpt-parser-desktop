using System.Collections.Generic;
using XptParser.Contracts;

namespace XptParser.DesktopApplication
{
    public class UnsupportedExplorerItemViewModelCreator : BaseExplorerItemViewModelCreator<UnsupportedExplorerItemViewModel>
    {
        public UnsupportedExplorerItemViewModelCreator(IDocumentDetailsExtractor documentDetailsExtractor) : 
            base(documentDetailsExtractor) { }

        public override bool CanCreate(string fileFullPath)
        {
            return !base.CanCreate(fileFullPath);
        }

        public override UnsupportedExplorerItemViewModel CreateExplorerItem(string fileFullPath, IEnumerable<ExplorerItemCommandModel> sharedCommands)
        {
            var unsupportedExplorerItemModel = new UnsupportedExplorerItemModel(fileFullPath, sharedCommands);
            return new UnsupportedExplorerItemViewModel(unsupportedExplorerItemModel);
        }
    }
}