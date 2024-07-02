using System.Windows.Controls;
using System.Windows.Input;

namespace XptParser.DesktopApplication.Views
{
    public sealed partial class ParsingResultView : UserControl
    {
        public ParsingResultView() => this.InitializeComponent();

        private void HandleScrollViewerPreviewMouseWheel(object sender, MouseWheelEventArgs eventArgs)
        {
            var scrollViewer = sender as ScrollViewer;
            scrollViewer?.ScrollToVerticalOffset(scrollViewer.VerticalOffset - eventArgs.Delta);
            eventArgs.Handled = true;
        }
    }
}