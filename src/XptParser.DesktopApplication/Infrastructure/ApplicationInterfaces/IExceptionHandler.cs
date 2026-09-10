using System;

namespace XptParser.DesktopApplication
{
    /// <summary>
    /// Defines a handler for processing exceptions.
    /// </summary>
    public interface IExceptionHandler
    {
        /// <summary>
        /// Handles the specified exception.
        /// </summary>
        /// <param name="exception">The exception to handle.</param>
        public void HandleException(Exception exception);
    }
}