using System;
using System.Windows;

namespace XptParser.DesktopApplication
{
    public sealed class ApplicationExceptionHandler : IExceptionHandler
    {
        public void HandleException(Exception exception)
        {
            var message = $"An error occurred: {exception.Message}";
            MessageBox.Show(message);
        }
    }
}