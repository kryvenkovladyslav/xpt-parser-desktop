using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace XptParser.DesktopApplication
{
    public sealed class ExplorerInteractiveViewModel : BaseViewModel
    {
        private readonly IDialogProcessor dialogProcessor;

        private readonly IExplorerItemViewModelManager manager;

        public event EventHandler<TabGeneratedEventArgs> NewTabGeneratedEvent;

        public event EventHandler<ExplorerItemRemovedEventArgs> ExplorerItemRemoved;

        public ICommand OpenExplorerBarCommand { get; private set; }

        public ICommand LeftMouseDoubleClickHotCommand { get; private set; }

        public ICommand CloseExplorerBarCommand { get; private set; }

        public ICommand AddExplorerItemCommand { get; private set; }

        public ICommand RemoveExplorerItemCommand { get; private set; }

        public ICommand ChangeExplorerBarSideCommand { get; private set; }

        public ObservableCollection<BaseExplorerItemViewModel> Items { get; init; }

        private ExplorerSides currentExplorerSidePosition;

        public ExplorerSides CurrentExplorerSidePosition
        {
            get => this.currentExplorerSidePosition;
            set
            {
                this.currentExplorerSidePosition = value;
                this.RaisePropertyChangedEvent();
            }
        }

        private ExplorerVisibility explorerVisibility; 

        public ExplorerVisibility ExplorerVisibility
        {
            get => this.explorerVisibility;
            set
            {
                this.explorerVisibility = value;
                this.RaisePropertyChangedEvent();
            }
        }

        private BaseExplorerItemViewModel selectedExplorerItem;

        public BaseExplorerItemViewModel CurrentSelectedExplorerItem
        {
            get => this.selectedExplorerItem;
            set
            {
                this.selectedExplorerItem = value;
                this.RaisePropertyChangedEvent();
            }
        }

        public ExplorerInteractiveViewModel(IExplorerItemViewModelManager manager, 
            IDialogProcessor dialogProcessor, 
            ParsingXptDocumentViewModel parsingViewModel)
        {
            this.Items = new();
            this.manager = manager;
            this.dialogProcessor = dialogProcessor;

            this.InitializeExplorerCommands();
            this.LeftMouseDoubleClickHotCommand = parsingViewModel.ParseDocumentCommand;
        }

        private void InitializeExplorerCommands()
        {
            this.OpenExplorerBarCommand = new DelegateCommand(this.SetUpExplorerVisability); 
            this.CloseExplorerBarCommand = new DelegateCommand(this.SetUpExplorerVisability);
            this.AddExplorerItemCommand = new DelegateCommand(this.HandleOnAddExplorerItemCommnad);
            this.ChangeExplorerBarSideCommand = new DelegateCommand(this.HandleOnChangeExplorerSide);
            this.RemoveExplorerItemCommand = new DelegateCommand(this.HandleOnRemoveExplorerItemCommand);
        }

        private void SetUpExplorerVisability(object parameter)
        {
            this.ExplorerVisibility = this.ExplorerVisibility == ExplorerVisibility.Visible ?
                ExplorerVisibility.Hidden : ExplorerVisibility.Visible;
        }

        private void HandleOnChangeExplorerSide(object parrameter = null)
        {
            this.CurrentExplorerSidePosition = this.CurrentExplorerSidePosition == ExplorerSides.Left ?
                ExplorerSides.Right : ExplorerSides.Left;
        }

        private void HandleOnRemoveExplorerItemCommand(object parameter = null)
        {
            var requiredItemToRemove = parameter as BaseExplorerItemViewModel;
            this.Items.Remove(requiredItemToRemove);

            this.RaiseExplorerItemRemovedEvent(new(requiredItemToRemove));
            this.CurrentSelectedExplorerItem = null;
        }

        private void RaiseExplorerItemRemovedEvent(ExplorerItemRemovedEventArgs eventArgs)
        {
            this.ExplorerItemRemoved?.Invoke(this, eventArgs);
        }

        private void HandleOnAddExplorerItemCommnad(object obj)
        {
            var fullFilePath = this.dialogProcessor.TryGetFileFullPath(out bool result);

            if(result == false)
            {
                return;
            }

            var fileName = this.manager.DocumentDetailsExtractor.ExtractDocumentName(fullFilePath);
            if (this.Items.Any(item => item.Name == fileName))
            {
                throw new ExplorerItemAlreadyExistsException(fileName);
            }

            var eventHandlers = this.GetEventHandlers();
            var sharedCommand = this.GetSharedExplorerItemCommands();

            var requiredEventHandlers = this.manager.SupportEventCreation(fullFilePath) ? eventHandlers : null;
            var newExplorerItemViewModel = this.manager.Create(fullFilePath, sharedCommand, requiredEventHandlers);

            this.Items.Add(newExplorerItemViewModel);
            this.CurrentSelectedExplorerItem = newExplorerItemViewModel;
        }
        
        private IEnumerable<ExplorerItemCommandModel> GetSharedExplorerItemCommands()
        {
            return [new ExplorerItemCommandModel(Resources.RemoveCommand, this.RemoveExplorerItemCommand)];
        }

        private Dictionary<Type, Delegate> GetEventHandlers()
        {
            return new()
            {
                { typeof(TabGeneratedEventArgs), this.NewTabGeneratedEvent },
                { typeof(ExplorerItemRemovedEventArgs), this.ExplorerItemRemoved }
            };
        }
    }
}