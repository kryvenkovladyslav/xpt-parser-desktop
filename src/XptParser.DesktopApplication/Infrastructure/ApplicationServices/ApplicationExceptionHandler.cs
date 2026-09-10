using System;
using System.Windows;

namespace XptParser.DesktopApplication
{
    /// <summary>
    /// Handles application-level exceptions.
    /// </summary>
    public sealed class ApplicationExceptionHandler : IExceptionHandler
    {
        /// <summary>
        /// Handles the specified exception by displaying an error message.
        /// </summary>
        /// <param name="exception">The exception to handle.</param>
        public void HandleException(Exception exception)
        {
            var message = $"An error occurred: {exception.Message}";
            MessageBox.Show(message);
        }
    }
}