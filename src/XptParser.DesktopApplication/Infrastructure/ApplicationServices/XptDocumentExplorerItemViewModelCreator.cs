using System.Collections.Generic;
using XptParser.Contracts;

namespace XptParser.DesktopApplication
{
    /// <summary>
    /// Creates Explorer item view models for XPT documents.
    /// </summary>
    public class XptDocumentExplorerItemViewModelCreator : BaseExplorerItemViewModelCreator<XptDocumentExplorerItemViewModel>
    {
        /// <summary>
        /// Gets the view model used to parse XPT documents.
        /// </summary>
        protected ParsingXptDocumentViewModel ParsingXptDocumentViewModel { get; private init; }

        /// <summary>
        /// Initializes a new instance of the <see cref="XptDocumentExplorerItemViewModelCreator"/> class.
        /// </summary>
        /// <param name="documentDetailsExtractor">The document details extractor.</param>
        /// <param name="parsingXptDocumentViewModel">The view model used to parse XPT documents.</param>
        public XptDocumentExplorerItemViewModelCreator(IDocumentDetailsExtractor documentDetailsExtractor, ParsingXptDocumentViewModel parsingXptDocumentViewModel)
            : base(documentDetailsExtractor) => this.ParsingXptDocumentViewModel = parsingXptDocumentViewModel;

        /// <summary>
        /// Creates an Explorer item view model for the specified XPT document.
        /// </summary>
        /// <param name="fileFullPath">The full path of the XPT document.</param>
        /// <param name="sharedCommands">The shared commands available to the Explorer item.</param>
        /// <returns>The created XPT document Explorer item view model.</returns>
        public override XptDocumentExplorerItemViewModel CreateExplorerItem(string fileFullPath, IEnumerable<ExplorerItemCommandModel> sharedCommands)
        {
            var requiredCommnads = new List<ExplorerItemCommandModel>(sharedCommands);
            requiredCommnads.Add(new(Resources.ParseCommnad, this.ParsingXptDocumentViewModel.ParseDocumentCommand));

            var xptDocumentExplorerItemModel = new XptDocumentExplorerItemModel(fileFullPath, requiredCommnads);
            return new XptDocumentExplorerItemViewModel(xptDocumentExplorerItemModel);
        }
    }
}