using System.Windows.Controls;
using System.Windows.Input;

namespace XptParser.DesktopApplication.Views
{
    /// <summary>
    /// Represents the view used to display parsing results.
    /// </summary>
    public sealed partial class ParsingResultView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ParsingResultView"/> class.
        /// </summary>
        public ParsingResultView() => this.InitializeComponent();

        /// <summary>
        /// Handles the mouse wheel event for the scroll viewer.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="eventArgs">The event data.</param>
        private void HandleScrollViewerPreviewMouseWheel(object sender, MouseWheelEventArgs eventArgs)
        {
            var scrollViewer = sender as ScrollViewer;
            scrollViewer?.ScrollToVerticalOffset(scrollViewer.VerticalOffset - eventArgs.Delta);
            eventArgs.Handled = true;
        }
    }
}