using Microsoft.Win32;

namespace XptParser.DesktopApplication
{
    /// <summary>
    /// Provides file selection functionality using Windows dialogs.
    /// </summary>
    public class WindowsDialogProcessor : IDialogProcessor
    {
        /// <summary>
        /// Attempts to retrieve the full path of a file selected through an open file dialog.
        /// </summary>
        /// <param name="result">Indicates whether the file dialog was confirmed.</param>
        /// <returns>The full path of the selected file.</returns>
        public virtual string TryGetFileFullPath(out bool result)
        {
            var dialog = new OpenFileDialog();

            result = dialog.ShowDialog().Value;

            return dialog.FileName;
        }
    }
}