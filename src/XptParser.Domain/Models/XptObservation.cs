namespace SasXptParser.Domain
{
    /// <summary>
    /// Represents an observation of the XPT Document
    /// </summary>
    public sealed class XptObservation
    {
        /// <summary>
        /// Represents an identifier of the XPT observation record
        /// </summary>
        public string Identifier { get; init; }

        /// <summary>
        /// Represents a label of the XPT observation record
        /// </summary>
        public string Label { get; init; }

        /// <summary>
        /// Represents a name of the XPT observation record
        /// </summary>
        public string Name { get; init; }

        /// <summary>
        /// Represents a value of the XPT observation record
        /// </summary>
        public string Value { get; init; }
    }
}