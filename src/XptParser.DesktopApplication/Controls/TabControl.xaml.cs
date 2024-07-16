using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace XptParser.DesktopApplication.Controls
{
    public sealed partial class TabControl : UserControl
    {
        public static DependencyProperty TabDisplayNameProperty =
            DependencyProperty.Register(nameof(TabDisplayName), typeof(string), typeof(TabControl));

        public string TabDisplayName
        {
            get => this.GetTypedValue<string>(TabDisplayNameProperty);
            set => this.SetValue(TabDisplayNameProperty, value);
        }

        public static DependencyProperty CloseTabCommandProperty =
            DependencyProperty.Register(nameof(CloseTabCommand), typeof(ICommand), typeof(TabControl));

        public ICommand CloseTabCommand
        {
            get => this.GetTypedValue<ICommand>(CloseTabCommandProperty);
            set => this.SetValue(CloseTabCommandProperty, value);
        }

        public static DependencyProperty CloseTabCommandCommandParameterProperty =
            DependencyProperty.Register(nameof(CloseTabCommandCommandParameter), typeof(object), typeof(TabControl));

        public object CloseTabCommandCommandParameter
        {
            get => this.GetValue(CloseTabCommandCommandParameterProperty);
            set => this.SetValue(CloseTabCommandCommandParameterProperty, value);
        }

        public TabControl() =>  this.InitializeComponent();        
    }
}