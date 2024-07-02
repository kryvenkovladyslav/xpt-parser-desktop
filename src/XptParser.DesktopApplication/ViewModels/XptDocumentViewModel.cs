using System.Collections.ObjectModel;
using XptParser.Domain;

namespace XptParser.DesktopApplication
{
    public sealed class XptDocumentViewModel : BaseViewModel
    {
        public ObservableCollection<XptLibraryHeader> LibraryHeaders { get; init; }

        public ObservableCollection<XptMemberDescriptorHeader> MemberDescriptorHeaders { get; init; }

        public ObservableCollection<XptVariable> Variables { get; init; }

        public ObservableCollection<XptObservation> Observations { get; init; }

        public XptDocumentViewModel(XptDocument xptDocument)
        {
            this.LibraryHeaders = [xptDocument.LibraryHeader];
            this.MemberDescriptorHeaders = [xptDocument.MemberDescriptor];

            this.Variables = new(xptDocument.Variables);  
            this.Observations = new(xptDocument.Observations);
        }
    }
}