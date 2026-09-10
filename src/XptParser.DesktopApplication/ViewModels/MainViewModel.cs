using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace XptParser.DesktopApplication
{
    /// <summary>
    /// Represents the main view model of the application window.
    /// </summary>
    public sealed class MainViewModel : WindowInteractiveViewModel
    {
        /// <summary>
        /// Gets the view model responsible for Explorer interactions.
        /// </summary>
        public ExplorerInteractiveViewModel ExplorerInteractiveViewModel { get; init; }

        /// <summary>
        /// Stores the currently selected view model.
        /// </summary>
        private WindowInteractiveViewModel selectedViewModel;

        /// <summary>
        /// Gets the currently selected view model.
        /// </summary>
        public WindowInteractiveViewModel SelectedViewModel
        {
            get => this.selectedViewModel;
            private set
            {
                this.selectedViewModel = value;
                this.RaisePropertyChangedEvent();
            }
        }

        /// <summary>
        /// Stores the currently selected tab view model.
        /// </summary>
        private TabViewModel selectedTabViewModel;

        /// <summary>
        /// Gets or sets the currently selected tab view model.
        /// </summary>
        public TabViewModel SelectedTabViewModel
        {
            get => this.selectedTabViewModel;
            set
            {
                this.selectedTabViewModel = value;
                this.SetSelectedViewModel(this.SelectedTabViewModel?.ViewModelToDisplay);
                this.RaisePropertyChangedEvent();
            }
        }

        /// <summary>
        /// Stores the currently selected Explorer item.
        /// </summary>
        private BaseExplorerItemViewModel selectedExplorerItem;

        /// <summary>
        /// Gets or sets the currently selected Explorer item.
        /// </summary>
        public BaseExplorerItemViewModel SelectedExplorerItem
        {
            get => this.selectedExplorerItem;
            set
            {
                this.selectedExplorerItem = value;
                this.RaisePropertyChangedEvent();
            }
        }

        /// <summary>
        /// Gets the collection of open tabs.
        /// </summary>
        public ObservableCollection<TabViewModel> Tabs { get; init; }

        /// <summary>
        /// Gets the command used to close a tab.
        /// </summary>
        public ICommand CloseTabCommand { get; init; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        /// <param name="explorerInteractiveViewModel">The view model responsible for Explorer interactions.</param>
        public MainViewModel(ExplorerInteractiveViewModel explorerInteractiveViewModel)
        {
            this.Tabs = new();
            this.ExplorerInteractiveViewModel = explorerInteractiveViewModel;
            this.CloseTabCommand = new DelegateCommand(this.HandleCloseTabCommand);

            this.SetupEventHandlers();
            this.SetSelectedViewModel();
        }

        /// <summary>
        /// Sets up event handlers for Explorer events.
        /// </summary>
        private void SetupEventHandlers()
        {
            this.ExplorerInteractiveViewModel.NewTabGeneratedEvent += this.HandleNewTabGenerated;
            this.ExplorerInteractiveViewModel.ExplorerItemRemoved += this.HandleExplorerItemRemoved;
        }

        /// <summary>
        /// Handles the command used to close a tab.
        /// </summary>
        /// <param name="parameter">The tab to close.</param>
        public void HandleCloseTabCommand(object parameter = null)
        {
            var cuurentTab = parameter as TabViewModel;

            if (cuurentTab == null)
            {
                return;
            }

            this.Tabs.Remove(cuurentTab);
            var last = this.Tabs.LastOrDefault();
            this.SelectedTabViewModel = last;
        }


        /// <summary>
        /// Handles the event raised when a new tab is generated.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="eventArgs">The event arguments containing the generated tab.</param>
        private void HandleNewTabGenerated(object sender, TabGeneratedEventArgs eventArgs)
        {
            var generatedTab = eventArgs.GeneratedTabViewModel;
            var existingTab = this.GetFirstOrDefaultTab(tab => generatedTab.ProducerID == tab.ProducerID);

            if (existingTab != null)
            {
                this.SelectedTabViewModel = existingTab;
                return;
            }

            this.Tabs.Add(generatedTab);
            this.SelectedTabViewModel = generatedTab;
        }

        /// <summary>
        /// Handles the event raised when an Explorer item is removed.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="eventArgs">The event arguments containing the removed Explorer item.</param>
        private void HandleExplorerItemRemoved(object sender, ExplorerItemRemovedEventArgs eventArgs)
        {
            var ruqiredTab = this.GetFirstOrDefaultTab(tab => eventArgs.RemovedExplorerItem.ID == tab.ProducerID);
            this.CloseTabCommand.Execute(ruqiredTab);
        }

        /// <summary>
        /// Gets the first tab that matches the specified predicate.
        /// </summary>
        /// <param name="predicate">The condition used to find the tab.</param>
        /// <returns>The first matching tab, or <see langword="null"/> if no tab matches.</returns>
        private TabViewModel GetFirstOrDefaultTab(Func<TabViewModel, bool> predicate) =>
            this.Tabs.FirstOrDefault(predicate);

        /// <summary>
        /// Sets the currently selected view model.
        /// </summary>
        /// <param name="viewModel">The view model to select.</param>
        private void SetSelectedViewModel(WindowInteractiveViewModel viewModel = null) =>
            this.SelectedViewModel = viewModel ?? this;
    }
}