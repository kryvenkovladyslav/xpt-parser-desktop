using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace XptParser.DesktopApplication.Controls
{
    /// <summary>
    /// Represents an Explorer item control.
    /// </summary>
    public partial class ExplorerItem : UserControl
    {
        /// <summary>
        /// Gets or sets the name of the Explorer item.
        /// </summary>
        public static DependencyProperty ItemNameProperty =
            DependencyProperty.Register(nameof(ItemName), typeof(object), typeof(ExplorerItem));

        /// <summary>
        /// Gets or sets the name of the Explorer item.
        /// </summary>
        public object ItemName
        {
            get => this.GetValue(ItemNameProperty);
            set => this.SetValue(ItemNameProperty, value);
        }

        /// <summary>
        /// Gets or sets the currently selected item.
        /// </summary>
        public static DependencyProperty SelectedItemProperty =
            DependencyProperty.Register(nameof(SelectedItem), typeof(object), typeof(ExplorerItem));

        /// <summary>
        /// Gets or sets the currently selected item.
        /// </summary>
        public object SelectedItem
        {
            get => this.GetValue(SelectedItemProperty);
            set => this.SetValue(SelectedItemProperty, value);
        }

        /// <summary>
        /// Gets or sets the collection of commands available for the Explorer item.
        /// </summary>
        public static DependencyProperty ItemCommandsSourceProperty =
            DependencyProperty.Register(nameof(ItemCommandsSource), typeof(IEnumerable<ExplorerItemCommandModel>), typeof(ExplorerItem));

        /// <summary>
        /// Gets or sets the collection of commands available for the Explorer item.
        /// </summary>
        public IEnumerable<ExplorerItemCommandModel> ItemCommandsSource
        {
            get => this.GetTypedValue<IEnumerable<ExplorerItemCommandModel>>(ItemCommandsSourceProperty);
            set => this.SetValue(ItemCommandsSourceProperty, value);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExplorerItem"/> class.
        /// </summary>
        public ExplorerItem() => this.InitializeComponent();

        /// <summary>
        /// Handles the preview right mouse button event for a menu item.
        /// </summary>
        private void HandleMenuItemPreviewMouseRightButtonDown(object sender, MouseButtonEventArgs eventArgs)
        {
            this.HandleItemSelection(sender, eventArgs);

            var menuItem = sender as MenuItem;

            if (menuItem == null)
            {
                return;
            }

            menuItem.IsSubmenuOpen = true;
            eventArgs.Handled = true;
        }

        /// <summary>
        /// Handles the selection of an Explorer item.
        /// </summary>
        private void HandleItemSelection(object sender, MouseButtonEventArgs eventArgs)
        {
            var listViewItem = this.FindAncestor<ListViewItem>(sender as MenuItem);
            listViewItem.IsSelected = true;
        }

        /// <summary>
        /// Handles the submenu opened event for a menu item.
        /// </summary>
        private void HandleMenuItemSubmenuOpened(object sender, RoutedEventArgs e)
        {
            var item = sender as MenuItem;
            item.IsSubmenuOpen = Mouse.LeftButton == MouseButtonState.Pressed ? false : true;
        }

        /// <summary>
        /// Handles the double-click event for a menu item.
        /// </summary>
        private void HandleMenuItemMouseDoubleClick(object sender, MouseButtonEventArgs eventArgs) =>
            this.HandleItemSelection(sender, eventArgs);
    }
}