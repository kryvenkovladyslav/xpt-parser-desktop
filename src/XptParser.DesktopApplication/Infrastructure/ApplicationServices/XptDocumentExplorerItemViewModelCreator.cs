using System.Collections.Generic;
using XptParser.Contracts;

namespace XptParser.DesktopApplication
{
    public class XptDocumentExplorerItemViewModelCreator : BaseExplorerItemViewModelCreator<XptDocumentExplorerItemViewModel>
    {
        protected ParsingXptDocumentViewModel ParsingXptDocumentViewModel { get; private init; }

        public XptDocumentExplorerItemViewModelCreator(IDocumentDetailsExtractor documentDetailsExtractor, ParsingXptDocumentViewModel parsingXptDocumentViewModel)
            : base(documentDetailsExtractor) => this.ParsingXptDocumentViewModel = parsingXptDocumentViewModel;

        public override XptDocumentExplorerItemViewModel CreateExplorerItem(string fileFullPath, IEnumerable<ExplorerItemCommandModel> sharedCommands)
        {
            var requiredCommnads = new List<ExplorerItemCommandModel>(sharedCommands);
            requiredCommnads.Add(new(Resources.ParseCommnad, this.ParsingXptDocumentViewModel.ParseDocumentCommand));

            var xptDocumentExplorerItemModel = new XptDocumentExplorerItemModel(fileFullPath, requiredCommnads);
            return new XptDocumentExplorerItemViewModel(xptDocumentExplorerItemModel);
        }
    }
}