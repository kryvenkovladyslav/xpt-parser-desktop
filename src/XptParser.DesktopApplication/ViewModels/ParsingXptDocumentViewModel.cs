using System.Windows.Input;
using XptParser.Contracts;

namespace XptParser.DesktopApplication
{
    /// <summary>
    /// Provides functionality for parsing XPT documents.
    /// </summary>
    public sealed class ParsingXptDocumentViewModel
    {
        /// <summary>
        /// Stores the document reader.
        /// </summary>
        private readonly IDocumentReader documentReader;

        /// <summary>
        /// Stores the XPT document parser.
        /// </summary>
        private readonly IXptDocumentParser xptDocumentParser;

        /// <summary>
        /// Gets the command used to parse an XPT document.
        /// </summary>
        public ICommand ParseDocumentCommand { get; init; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ParsingXptDocumentViewModel"/> class.
        /// </summary>
        /// <param name="documentReader">The document reader.</param>
        /// <param name="xptDocumentParser">The XPT document parser.</param>
        public ParsingXptDocumentViewModel(IDocumentReader documentReader, IXptDocumentParser xptDocumentParser)
        {
            this.documentReader = documentReader;
            this.xptDocumentParser = xptDocumentParser;
            this.ParseDocumentCommand = new DelegateCommand(this.HandleDocumentParseCommand);
        }

        /// <summary>
        /// Handles the command used to parse an XPT document.
        /// </summary>
        /// <param name="parameter">The Explorer item view model containing the XPT document.</param>
        private async void HandleDocumentParseCommand(object parameter = null)
        {
            var xptDocumentExplorerItem = parameter as XptDocumentExplorerItemViewModel;

            if(xptDocumentExplorerItem == null)
            {
                var explorerItemViewModel = parameter as BaseExplorerItemViewModel;
                throw new InvalidParsingExplorerItemException(explorerItemViewModel.BaseExplorerItem);
            }

            using var documentStram = await this.documentReader.ReadAsStreamAsync(xptDocumentExplorerItem.FullPath);
            var parsedDocument = await this.xptDocumentParser.ParseAsync(documentStram);

            xptDocumentExplorerItem.RaiseTabGeneratedEvent(new ParsingResultViewModel(new XptDocumentViewModel(parsedDocument)));
        }
    }
}