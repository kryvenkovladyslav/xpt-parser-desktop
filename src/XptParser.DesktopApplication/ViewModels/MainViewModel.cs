using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace XptParser.DesktopApplication
{
    public sealed class MainViewModel : WindowInteractiveViewModel
    {
        public ExplorerInteractiveViewModel ExplorerInteractiveViewModel { get; init; }

        private WindowInteractiveViewModel selectedViewModel;

        public WindowInteractiveViewModel SelectedViewModel 
        {
            get => this.selectedViewModel;
            private set
            {
                this.selectedViewModel = value;
                this.RaisePropertyChangedEvent();
            }
        }

        private TabViewModel selectedTabViewModel;

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

        private BaseExplorerItemViewModel selectedExplorerItem;

        public BaseExplorerItemViewModel SelectedExplorerItem 
        {
            get => this.selectedExplorerItem;
            set
            {
                this.selectedExplorerItem = value;
                this.RaisePropertyChangedEvent();
            }
        }

        public ObservableCollection<TabViewModel> Tabs { get; init; }

        public ICommand CloseTabCommand { get; init; }

        public MainViewModel(ExplorerInteractiveViewModel explorerInteractiveViewModel)
        {
            this.Tabs = new();
            this.ExplorerInteractiveViewModel = explorerInteractiveViewModel;
            this.CloseTabCommand = new DelegateCommand(this.HandleCloseTabCommand);
            
            this.SetupEventHandlers();
            this.SetSelectedViewModel();
        }
        
        private void SetupEventHandlers()
        {
            this.ExplorerInteractiveViewModel.NewTabGeneratedEvent += this.HandleNewTabGenerated;
            this.ExplorerInteractiveViewModel.ExplorerItemRemoved += this.HandleExplorerItemRemoved;
        }

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

        private void HandleExplorerItemRemoved(object sender, ExplorerItemRemovedEventArgs eventArgs)
        {
            var ruqiredTab = this.GetFirstOrDefaultTab(tab => eventArgs.RemovedExplorerItem.ID == tab.ProducerID);
            this.CloseTabCommand.Execute(ruqiredTab);
        }

        private TabViewModel GetFirstOrDefaultTab(Func<TabViewModel, bool> predicate) =>
            this.Tabs.FirstOrDefault(predicate);

        private void SetSelectedViewModel(WindowInteractiveViewModel viewModel = null) => 
            this.SelectedViewModel = viewModel ?? this;
    }
}