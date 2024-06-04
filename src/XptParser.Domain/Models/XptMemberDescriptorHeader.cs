using System;

namespace XptParser.Domain
{
    public sealed class XptMemberDescriptorHeader
    {
        /// <summary>
        /// Represents a name of the dataset specified in the member descriptor header record
        /// </summary>
        public string DataSetName { get; init; }

        /// <summary>
        /// Represents a dataset specified in the member descriptor header record
        /// </summary>
        public string DataSet { get; init; }

        /// <summary>
        /// Represents a version specified in the library header record
        /// </summary>
        public string Version { get; init; }

        /// <summary>
        /// Represents an operating system specified in the library header record
        /// </summary>
        public string OperationSystem { get; init; }

        /// <summary>
        /// Represents a first time when the document was created 
        /// </summary>
        public DateTime CreatedDateTime { get; init; }

        /// <summary>
        /// Represents a last time when the document was modified 
        /// </summary>
        public DateTime ModifiedDateTime { get; init; }

        /// <summary>
        /// Represents a label specified in the member descriptor header record
        /// </summary>
        public string Label { get; init; }
    }
}