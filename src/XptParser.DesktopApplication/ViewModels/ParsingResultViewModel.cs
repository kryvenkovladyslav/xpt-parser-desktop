namespace XptParser.DesktopApplication
{
    /// <summary>
    /// Represents a view model for displaying XPT document parsing results.
    /// </summary>
    public sealed class ParsingResultViewModel : WindowInteractiveViewModel
    {
        /// <summary>
        /// Stores the XPT document view model.
        /// </summary>
        private XptDocumentViewModel xptDocumentViewModel;

        /// <summary>
        /// Gets or sets the XPT document view model.
        /// </summary>
        public XptDocumentViewModel XptDocumentViewModel
        {
            get => this.xptDocumentViewModel;
            set
            {
                this.xptDocumentViewModel = value;
                this.RaisePropertyChangedEvent();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ParsingResultViewModel"/> class.
        /// </summary>
        /// <param name="xptDocumentViewModel">The XPT document view model.</param>
        public ParsingResultViewModel(XptDocumentViewModel xptDocumentViewModel)
            => this.XptDocumentViewModel = xptDocumentViewModel;
    }
}