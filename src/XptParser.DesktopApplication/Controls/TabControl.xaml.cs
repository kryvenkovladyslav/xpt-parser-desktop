using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace XptParser.DesktopApplication.Controls
{
    /// <summary>
    /// Represents a tab control.
    /// </summary>
    public sealed partial class TabControl : UserControl
    {
        /// <summary>
        /// Gets or sets the display name of the tab.
        /// </summary>
        public static DependencyProperty TabDisplayNameProperty =
            DependencyProperty.Register(nameof(TabDisplayName), typeof(string), typeof(TabControl));

        /// <summary>
        /// Gets or sets the display name of the tab.
        /// </summary>
        public string TabDisplayName
        {
            get => this.GetTypedValue<string>(TabDisplayNameProperty);
            set => this.SetValue(TabDisplayNameProperty, value);
        }

        /// <summary>
        /// Gets or sets the command used to close the tab.
        /// </summary>
        public static DependencyProperty CloseTabCommandProperty =
            DependencyProperty.Register(nameof(CloseTabCommand), typeof(ICommand), typeof(TabControl));

        /// <summary>
        /// Gets or sets the command used to close the tab.
        /// </summary>
        public ICommand CloseTabCommand
        {
            get => this.GetTypedValue<ICommand>(CloseTabCommandProperty);
            set => this.SetValue(CloseTabCommandProperty, value);
        }

        /// <summary>
        /// Gets or sets the parameter passed to the close tab command.
        /// </summary>
        public static DependencyProperty CloseTabCommandCommandParameterProperty =
            DependencyProperty.Register(nameof(CloseTabCommandCommandParameter), typeof(object), typeof(TabControl));

        /// <summary>
        /// Gets or sets the parameter passed to the close tab command.
        /// </summary>
        public object CloseTabCommandCommandParameter
        {
            get => this.GetValue(CloseTabCommandCommandParameterProperty);
            set => this.SetValue(CloseTabCommandCommandParameterProperty, value);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TabControl"/> class.
        /// </summary>
        public TabControl() => this.InitializeComponent();
    }
}