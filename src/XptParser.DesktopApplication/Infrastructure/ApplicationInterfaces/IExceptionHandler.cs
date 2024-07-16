using System;

namespace XptParser.DesktopApplication
{
    public interface IExceptionHandler
    {
        public void HandleException(Exception exception);
    }
}