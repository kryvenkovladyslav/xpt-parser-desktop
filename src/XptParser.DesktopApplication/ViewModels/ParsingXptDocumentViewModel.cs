using System.Windows.Input;
using XptParser.Contracts;

namespace XptParser.DesktopApplication
{
    public sealed class ParsingXptDocumentViewModel
    {
        private readonly IDocumentReader documentReader;

        private readonly IXptDocumentParser xptDocumentParser;

        public ICommand ParseDocumentCommand { get; init; }

        public ParsingXptDocumentViewModel(IDocumentReader documentReader, IXptDocumentParser xptDocumentParser) 
        {
            this.documentReader = documentReader;
            this.xptDocumentParser = xptDocumentParser;
            this.ParseDocumentCommand = new DelegateCommand(this.HandleDocumentParseCommand);
        }

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