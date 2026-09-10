using System;

namespace XptParser.DesktopApplication
{
    /// <summary>
    /// Represents event arguments for when a tab is generated.
    /// </summary>
    public sealed class TabGeneratedEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the generated tab view model.
        /// </summary>
        public TabViewModel GeneratedTabViewModel { get; init; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TabGeneratedEventArgs"/> class.
        /// </summary>
        /// <param name="generatedTabViewModel">The generated tab view model.</param>
        public TabGeneratedEventArgs(TabViewModel generatedTabViewModel) =>
            this.GeneratedTabViewModel = generatedTabViewModel;
    }
}