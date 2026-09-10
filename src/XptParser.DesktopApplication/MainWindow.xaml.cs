using System.Windows;

namespace XptParser.DesktopApplication
{
    /// <summary>
    /// Represents the main window of the XPT Parser desktop application
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        private readonly MainViewModel mainViewModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class with the specified view model
        /// </summary>
        /// <param name="mainViewModel">The view model that provides data and logic for the main window</param>
        public MainWindow(MainViewModel mainViewModel)
        {
            this.InitializeComponent();

            this.mainViewModel = mainViewModel;
            this.DataContext = this.mainViewModel;
        }
    }
}