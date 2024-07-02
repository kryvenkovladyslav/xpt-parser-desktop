using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace XptParser.DesktopApplication.Controls
{
    public sealed partial class ExplorerBarControl : UserControl
    {
        public static DependencyProperty LeftMouseDoubleClickHotCommandProperty =
            DependencyProperty.Register(nameof(LeftMouseDoubleClickHotCommand), typeof(ICommand), typeof(ExplorerBarControl));

        public ICommand LeftMouseDoubleClickHotCommand
        {
            get => this.GetTypedValue<ICommand>(LeftMouseDoubleClickHotCommandProperty);
            set => this.SetValue(LeftMouseDoubleClickHotCommandProperty, value);
        }

        public static DependencyProperty CloseExplorerBarCommandProperty =
            DependencyProperty.Register(nameof(CloseExplorerBarCommand), typeof(ICommand), typeof(ExplorerBarControl));

        public ICommand CloseExplorerBarCommand
        {
            get => this.GetTypedValue<ICommand>(CloseExplorerBarCommandProperty);
            set => this.SetValue(CloseExplorerBarCommandProperty, value);
        }

        public static DependencyProperty ChangeExplorerBarSideCommandProperty =
            DependencyProperty.Register(nameof(ChangeExplorerBarSideCommand), typeof(ICommand), typeof(ExplorerBarControl));

        public ICommand ChangeExplorerBarSideCommand
        {
            get => this.GetTypedValue<ICommand>(ChangeExplorerBarSideCommandProperty);
            set => this.SetValue(ChangeExplorerBarSideCommandProperty, value);
        }

        public static readonly DependencyProperty AddExplorerItemCommandProperty =
            DependencyProperty.Register(nameof(AddExplorerItemCommand), typeof(ICommand), typeof(ExplorerBarControl));

        public ICommand AddExplorerItemCommand
        {
            get => this.GetTypedValue<ICommand>(AddExplorerItemCommandProperty);
            set => this.SetValue(AddExplorerItemCommandProperty, value);
        }

        public static readonly DependencyProperty RemoveExplorerItemCommandProperty =
            DependencyProperty.Register(nameof(RemoveExplorerItemCommand), typeof(ICommand), typeof(ExplorerBarControl));

        public ICommand RemoveExplorerItemCommand
        {
            get => this.GetTypedValue<ICommand>(RemoveExplorerItemCommandProperty);
            set => this.SetValue(RemoveExplorerItemCommandProperty, value);
        }

        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register(nameof(ItemsSource), typeof(IEnumerable), typeof(ExplorerBarControl), new PropertyMetadata(null));

        public IEnumerable ItemsSource
        {
            get => this.GetTypedValue<IEnumerable>(ItemsSourceProperty);
            set => this.SetValue(ItemsSourceProperty, value);
        }

        public static readonly DependencyProperty CurrentSelectedExplorerItemProperty =
            DependencyProperty.Register(nameof(CurrentSelectedExplorerItem), typeof(object), typeof(ExplorerBarControl));

        public object CurrentSelectedExplorerItem
        {
            get => this.GetValue(CurrentSelectedExplorerItemProperty);
            set => this.SetValue(CurrentSelectedExplorerItemProperty, value);
        }

        public static readonly DependencyProperty ExplorerVisibilityProperty =
            DependencyProperty.Register(nameof(ExplorerVisibility), typeof(ExplorerVisibility), typeof(ExplorerBarControl));

        public ExplorerVisibility ExplorerVisibility
        {
            get => this.GetTypedValue<ExplorerVisibility>(ExplorerVisibilityProperty);
            set => this.SetValue(ExplorerVisibilityProperty, value);
        }

        public static readonly DependencyProperty ExplorerSideProperty =
            DependencyProperty.Register(nameof(ExplorerSide), typeof(ExplorerSides), typeof(ExplorerBarControl));

        public ExplorerSides ExplorerSide
        {
            get => this.GetTypedValue<ExplorerSides>(ExplorerSideProperty);
            set => this.SetValue(ExplorerSideProperty, value);
        }

        public ExplorerBarControl() => this.InitializeComponent();
    }
}