using System.Windows;

namespace XptParser.DesktopApplication
{
    public sealed partial class MainWindow : Window
    {
        private readonly MainViewModel mainViewModel;

        public MainWindow(MainViewModel mainViewModel)
        {
            this.InitializeComponent();

            this.mainViewModel = mainViewModel;
            this.DataContext = this.mainViewModel;
        }
    }
}