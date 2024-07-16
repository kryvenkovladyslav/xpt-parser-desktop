using System;

namespace XptParser.DesktopApplication
{
    public sealed class TabGeneratedEventArgs : EventArgs
    {
        public TabViewModel GeneratedTabViewModel { get; init; }

        public TabGeneratedEventArgs(TabViewModel generatedTabViewModel) => 
            this.GeneratedTabViewModel = generatedTabViewModel;
    }
}