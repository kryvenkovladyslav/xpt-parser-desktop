namespace XptParser.Domain
{
    /// <summary>
    /// Represents a variable (key and value pair) of the XPT Document
    /// </summary>
    public sealed class XptVariable
    {
        /// <summary>
        /// Represents a name of the XPT variable (key)
        /// </summary>
        public string Name { get; init; }

        /// <summary>
        /// Represents a value of the XPT variable (value)
        /// </summary>
        public string Label { get; init; }
    }
}