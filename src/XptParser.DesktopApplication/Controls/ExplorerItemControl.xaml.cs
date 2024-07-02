using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace XptParser.DesktopApplication.Controls
{
    public partial class ExplorerItem : UserControl
    {
        public static DependencyProperty ItemNameProperty =
            DependencyProperty.Register(nameof(ItemName), typeof(object), typeof(ExplorerItem));

        public object ItemName
        {
            get => this.GetValue(ItemNameProperty);
            set => this.SetValue(ItemNameProperty, value);
        }

        public static DependencyProperty SelectedItemProperty =
            DependencyProperty.Register(nameof(SelectedItem), typeof(object), typeof(ExplorerItem));

        public object SelectedItem
        {
            get => this.GetValue(SelectedItemProperty);
            set => this.SetValue(SelectedItemProperty, value);
        }

        public static DependencyProperty ItemCommandsSourceProperty =
            DependencyProperty.Register(nameof(ItemCommandsSource), typeof(IEnumerable<ExplorerItemCommandModel>), typeof(ExplorerItem));

        public IEnumerable<ExplorerItemCommandModel> ItemCommandsSource
        {
            get => this.GetTypedValue<IEnumerable<ExplorerItemCommandModel>>(ItemCommandsSourceProperty);
            set => this.SetValue(ItemCommandsSourceProperty, value);
        }

        public ExplorerItem() => this.InitializeComponent();

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

        private void HandleItemSelection(object sender, MouseButtonEventArgs eventArgs)
        {
            var listViewItem = this.FindAncestor<ListViewItem>(sender as MenuItem);
            listViewItem.IsSelected = true;
        }
        private void HandleMenuItemSubmenuOpened(object sender, RoutedEventArgs e)
        {
            var item = sender as MenuItem;
            item.IsSubmenuOpen = Mouse.LeftButton == MouseButtonState.Pressed ? false : true;
        }

        private void HandleMenuItemMouseDoubleClick(object sender, MouseButtonEventArgs eventArgs) =>
            this.HandleItemSelection(sender, eventArgs);
    }
}