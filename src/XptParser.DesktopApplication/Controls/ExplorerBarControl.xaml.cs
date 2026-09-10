using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace XptParser.DesktopApplication.Controls
{
    /// <summary>
    /// Represents a control that displays and manages the Explorer bar.
    /// </summary>
    public sealed partial class ExplorerBarControl : UserControl
    {
        /// <summary>
        /// Gets or sets the command executed when an Explorer item is double-clicked with the left mouse button.
        /// </summary>
        public static DependencyProperty LeftMouseDoubleClickHotCommandProperty =
            DependencyProperty.Register(nameof(LeftMouseDoubleClickHotCommand), typeof(ICommand), typeof(ExplorerBarControl));

        /// <summary>
        /// Gets or sets the command executed when an Explorer item is double-clicked with the left mouse button.
        /// </summary>
        public ICommand LeftMouseDoubleClickHotCommand
        {
            get => this.GetTypedValue<ICommand>(LeftMouseDoubleClickHotCommandProperty);
            set => this.SetValue(LeftMouseDoubleClickHotCommandProperty, value);
        }

        /// <summary>
        /// Gets or sets the command used to close the Explorer bar.
        /// </summary>
        public static DependencyProperty CloseExplorerBarCommandProperty =
            DependencyProperty.Register(nameof(CloseExplorerBarCommand), typeof(ICommand), typeof(ExplorerBarControl));

        /// <summary>
        /// Gets or sets the command used to close the Explorer bar.
        /// </summary>
        public ICommand CloseExplorerBarCommand
        {
            get => this.GetTypedValue<ICommand>(CloseExplorerBarCommandProperty);
            set => this.SetValue(CloseExplorerBarCommandProperty, value);
        }

        /// <summary>
        /// Gets or sets the command used to change the Explorer bar side.
        /// </summary>
        public static DependencyProperty ChangeExplorerBarSideCommandProperty =
            DependencyProperty.Register(nameof(ChangeExplorerBarSideCommand), typeof(ICommand), typeof(ExplorerBarControl));

        /// <summary>
        /// Gets or sets the command used to change the Explorer bar side.
        /// </summary>
        public ICommand ChangeExplorerBarSideCommand
        {
            get => this.GetTypedValue<ICommand>(ChangeExplorerBarSideCommandProperty);
            set => this.SetValue(ChangeExplorerBarSideCommandProperty, value);
        }

        /// <summary>
        /// Gets or sets the command used to add an Explorer item.
        /// </summary>
        public static readonly DependencyProperty AddExplorerItemCommandProperty =
            DependencyProperty.Register(nameof(AddExplorerItemCommand), typeof(ICommand), typeof(ExplorerBarControl));

        /// <summary>
        /// Gets or sets the command used to add an Explorer item.
        /// </summary>
        public ICommand AddExplorerItemCommand
        {
            get => this.GetTypedValue<ICommand>(AddExplorerItemCommandProperty);
            set => this.SetValue(AddExplorerItemCommandProperty, value);
        }

        /// <summary>
        /// Gets or sets the command used to remove an Explorer item.
        /// </summary>
        public static readonly DependencyProperty RemoveExplorerItemCommandProperty =
            DependencyProperty.Register(nameof(RemoveExplorerItemCommand), typeof(ICommand), typeof(ExplorerBarControl));

        /// <summary>
        /// Gets or sets the command used to remove an Explorer item.
        /// </summary>
        public ICommand RemoveExplorerItemCommand
        {
            get => this.GetTypedValue<ICommand>(RemoveExplorerItemCommandProperty);
            set => this.SetValue(RemoveExplorerItemCommandProperty, value);
        }

        /// <summary>
        /// Gets or sets the collection of items displayed in the Explorer bar.
        /// </summary>
        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register(nameof(ItemsSource), typeof(IEnumerable), typeof(ExplorerBarControl), new PropertyMetadata(null));

        /// <summary>
        /// Gets or sets the collection of items displayed in the Explorer bar.
        /// </summary>
        public IEnumerable ItemsSource
        {
            get => this.GetTypedValue<IEnumerable>(ItemsSourceProperty);
            set => this.SetValue(ItemsSourceProperty, value);
        }

        /// <summary>
        /// Gets or sets the currently selected Explorer item.
        /// </summary>
        public static readonly DependencyProperty CurrentSelectedExplorerItemProperty =
            DependencyProperty.Register(nameof(CurrentSelectedExplorerItem), typeof(object), typeof(ExplorerBarControl));

        /// <summary>
        /// Gets or sets the currently selected Explorer item.
        /// </summary>
        public object CurrentSelectedExplorerItem
        {
            get => this.GetValue(CurrentSelectedExplorerItemProperty);
            set => this.SetValue(CurrentSelectedExplorerItemProperty, value);
        }

        /// <summary>
        /// Gets or sets the visibility of the Explorer bar.
        /// </summary>
        public static readonly DependencyProperty ExplorerVisibilityProperty =
            DependencyProperty.Register(nameof(ExplorerVisibility), typeof(ExplorerVisibility), typeof(ExplorerBarControl));

        /// <summary>
        /// Gets or sets the visibility of the Explorer bar.
        /// </summary>
        public ExplorerVisibility ExplorerVisibility
        {
            get => this.GetTypedValue<ExplorerVisibility>(ExplorerVisibilityProperty);
            set => this.SetValue(ExplorerVisibilityProperty, value);
        }

        /// <summary>
        /// Gets or sets the side of the Explorer bar.
        /// </summary>
        public static readonly DependencyProperty ExplorerSideProperty =
            DependencyProperty.Register(nameof(ExplorerSide), typeof(ExplorerSides), typeof(ExplorerBarControl));

        /// <summary>
        /// Gets or sets the side of the Explorer bar.
        /// </summary>
        public ExplorerSides ExplorerSide
        {
            get => this.GetTypedValue<ExplorerSides>(ExplorerSideProperty);
            set => this.SetValue(ExplorerSideProperty, value);
        }

        public ExplorerBarControl() => this.InitializeComponent();
    }
}