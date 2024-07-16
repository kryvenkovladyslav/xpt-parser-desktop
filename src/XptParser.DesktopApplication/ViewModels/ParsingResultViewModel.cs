namespace XptParser.DesktopApplication
{
    public sealed class ParsingResultViewModel : WindowInteractiveViewModel
    {
        private XptDocumentViewModel xptDocumentViewModel;

        public XptDocumentViewModel XptDocumentViewModel 
        {
            get => this.xptDocumentViewModel;
            set
            {
                this.xptDocumentViewModel = value;
                this.RaisePropertyChangedEvent();
            }
        }   

        public ParsingResultViewModel(XptDocumentViewModel xptDocumentViewModel) 
            => this.XptDocumentViewModel = xptDocumentViewModel;
    }
}