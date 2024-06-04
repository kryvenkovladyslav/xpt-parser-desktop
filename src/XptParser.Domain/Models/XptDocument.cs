using System.Collections.Generic;

namespace SasXptParser.Domain
{
    /// <summary>
    /// Represents the XPT Document
    /// </summary>
    public sealed class XptDocument
    {
        /// <summary>
        /// Represents a library header record of the XPT Document
        /// </summary>
        public XptLibraryHeader LibraryHeader { get; init; }

        /// <summary>
        /// Represents a member descriptor header record of the XPT Document
        /// </summary>
        public XptMemberDescriptorHeader MemberDescriptor { get; init; }

        /// <summary>
        /// Represents all provided variable of the XPT Document
        /// </summary>
        public List<XptVariable> Variables { get; init; }

        /// <summary>
        /// Represents all provided observations of the XPT Document
        /// </summary>
        public List<XptObservation> Observations { get; init; }
    }
}