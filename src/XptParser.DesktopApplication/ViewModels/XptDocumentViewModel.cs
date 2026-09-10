using System.Collections.ObjectModel;
using XptParser.Domain;

namespace XptParser.DesktopApplication
{
    /// <summary>
    /// Represents a view model for an XPT document.
    /// </summary>
    public sealed class XptDocumentViewModel : BaseViewModel
    {
        /// <summary>
        /// Gets the collection of library headers in the XPT document.
        /// </summary>
        public ObservableCollection<XptLibraryHeader> LibraryHeaders { get; init; }

        /// <summary>
        /// Gets the collection of member descriptor headers in the XPT document.
        /// </summary>
        public ObservableCollection<XptMemberDescriptorHeader> MemberDescriptorHeaders { get; init; }

        /// <summary>
        /// Gets the collection of variables in the XPT document.
        /// </summary>
        public ObservableCollection<XptVariable> Variables { get; init; }

        /// <summary>
        /// Gets the collection of observations in the XPT document.
        /// </summary>
        public ObservableCollection<XptObservation> Observations { get; init; }

        /// <summary>
        /// Initializes a new instance of the <see cref="XptDocumentViewModel"/> class.
        /// </summary>
        /// <param name="xptDocument">The XPT document.</param>
        public XptDocumentViewModel(XptDocument xptDocument)
        {
            this.LibraryHeaders = [xptDocument.LibraryHeader];
            this.MemberDescriptorHeaders = [xptDocument.MemberDescriptor];

            this.Variables = new(xptDocument.Variables);
            this.Observations = new(xptDocument.Observations);
        }
    }
}