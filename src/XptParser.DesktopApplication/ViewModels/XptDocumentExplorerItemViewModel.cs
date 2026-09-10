namespace XptParser.DesktopApplication
{
    /// <summary>
    /// Represents an Explorer item view model for an XPT document that can generate a tab.
    /// </summary>
    public sealed class XptDocumentExplorerItemViewModel : GeneratingTabExplorerItemViewModel
    {
        /// <summary>
        /// Gets the full path of the XPT document.
        /// </summary>
        public string FullPath { get; init; }

        /// <summary>
        /// Initializes a new instance of the <see cref="XptDocumentExplorerItemViewModel"/> class.
        /// </summary>
        /// <param name="xptDocumentExplorerItem">The XPT document Explorer item model.</param>
        public XptDocumentExplorerItemViewModel(XptDocumentExplorerItemModel xptDocumentExplorerItem) : base(xptDocumentExplorerItem)
            => this.FullPath = xptDocumentExplorerItem.FullPath;

        /// <summary>
        /// Creates event arguments for a generated tab.
        /// </summary>
        /// <param name="viewToDisplay">The view model to display in the generated tab.</param>
        /// <returns>The event arguments containing the generated tab.</returns>
        protected override TabGeneratedEventArgs CreateTabGeneratedEventArgs(WindowInteractiveViewModel viewToDisplay)
            => new TabGeneratedEventArgs(new TabViewModel(this.Name, this.ID, viewToDisplay));
    }
}