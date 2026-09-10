namespace XptParser.DesktopApplication
{
    /// <summary>
    /// Represents a view model for an unsupported Explorer item.
    /// </summary>
    public sealed class UnsupportedExplorerItemViewModel : BaseExplorerItemViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnsupportedExplorerItemViewModel"/> class.
        /// </summary>
        /// <param name="unsupportedExplorerItem">The unsupported Explorer item model.</param>
        public UnsupportedExplorerItemViewModel(UnsupportedExplorerItemModel unsupportedExplorerItem) : base(unsupportedExplorerItem) { }
    }
}