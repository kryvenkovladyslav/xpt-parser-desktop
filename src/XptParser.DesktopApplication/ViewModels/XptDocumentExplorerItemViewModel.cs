namespace XptParser.DesktopApplication
{
    public sealed class XptDocumentExplorerItemViewModel : GeneratingTabExplorerItemViewModel
    {
        public string FullPath { get; init; }

        public XptDocumentExplorerItemViewModel(XptDocumentExplorerItemModel xptDocumentExplorerItem) : base(xptDocumentExplorerItem) 
            => this.FullPath = xptDocumentExplorerItem.FullPath;
        
        protected override TabGeneratedEventArgs CreateTabGeneratedEventArgs(WindowInteractiveViewModel viewToDisplay) 
            => new TabGeneratedEventArgs(new TabViewModel(this.Name, this.ID, viewToDisplay));   
    }
}