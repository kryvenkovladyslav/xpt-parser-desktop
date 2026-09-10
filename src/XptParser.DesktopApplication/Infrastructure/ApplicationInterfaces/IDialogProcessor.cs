namespace XptParser.DesktopApplication
{
    /// <summary>
    /// Defines a processor for working with dialog files.
    /// </summary>
    public interface IDialogProcessor
    {
        /// <summary>
        /// Attempts to retrieve the full path of a file.
        /// </summary>
        /// <param name="result">Indicates whether the file path was retrieved successfully.</param>
        /// <returns>The full path of the selected file.</returns>
        public string TryGetFileFullPath(out bool result);
    }
}