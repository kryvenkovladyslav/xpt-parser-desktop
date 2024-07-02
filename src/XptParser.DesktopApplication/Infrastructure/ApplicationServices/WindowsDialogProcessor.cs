using Microsoft.Win32;

namespace XptParser.DesktopApplication
{
    public class WindowsDialogProcessor : IDialogProcessor
    {
        public virtual string TryGetFileFullPath(out bool result)
        {
            var dialog = new OpenFileDialog();

            result = dialog.ShowDialog().Value;

            return dialog.FileName;
        }
    }
}