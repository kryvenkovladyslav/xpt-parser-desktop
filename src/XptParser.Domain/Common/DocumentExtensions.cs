using System.Collections.Generic;

namespace SasXptParser.Domain
{
    /// <summary>
    /// Provides all required document extensions
    /// </summary>
    public static class DocumentExtensions
    {
        /// <summary>
        /// Represents the extensions of the XPT Document
        /// </summary>
        public static string XPT { get; } = ".XPT";

        /// <summary>
        /// Returns all required extensions
        /// </summary>
        public static IEnumerable<string> NormalizedSupportedExtensions
        {
            get => [XPT];
        }
    }
}