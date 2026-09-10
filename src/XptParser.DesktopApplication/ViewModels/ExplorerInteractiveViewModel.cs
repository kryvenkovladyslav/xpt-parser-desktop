using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace XptParser.DesktopApplication
{
    /// <summary>
    /// Provides interactive functionality for managing Explorer items and the Explorer bar.
    /// </summary>
    public sealed class ExplorerInteractiveViewModel : BaseViewModel
    {
        /// <summary>
        /// Stores the processor used to interact with file dialogs.
        /// </summary>
        private readonly IDialogProcessor dialogProcessor;

        /// <summary>
        /// Stores the manager used to create and manage Explorer item view models.
        /// </summary>
        private readonly IExplorerItemViewModelManager manager;

        /// <summary>
        /// Occurs when a new tab is generated.
        /// </summary>
        public event EventHandler<TabGeneratedEventArgs> NewTabGeneratedEvent;

        /// <summary>
        /// Occurs when an Explorer item is removed.
        /// </summary>
        public event EventHandler<ExplorerItemRemovedEventArgs> ExplorerItemRemoved;

        /// <summary>
        /// Gets or sets the command used to open the Explorer bar.
        /// </summary>
        public ICommand OpenExplorerBarCommand { get; private set; }

        /// <summary>
        /// Gets or sets the command executed when an Explorer item is double-clicked with the left mouse button.
        /// </summary>
        public ICommand LeftMouseDoubleClickHotCommand { get; private set; }

        /// <summary>
        /// Gets or sets the command used to close the Explorer bar.
        /// </summary>
        public ICommand CloseExplorerBarCommand { get; private set; }

        /// <summary>
        /// Gets or sets the command used to add an Explorer item.
        /// </summary>
        public ICommand AddExplorerItemCommand { get; private set; }

        /// <summary>
        /// Gets or sets the command used to remove an Explorer item.
        /// </summary>
        public ICommand RemoveExplorerItemCommand { get; private set; }

        /// <summary>
        /// Gets or sets the command used to change the Explorer bar side.
        /// </summary>
        public ICommand ChangeExplorerBarSideCommand { get; private set; }

        /// <summary>
        /// Gets the collection of Explorer items.
        /// </summary>
        public ObservableCollection<BaseExplorerItemViewModel> Items { get; init; }

        /// <summary>
        /// Stores the current side position of the Explorer bar.
        /// </summary>
        private ExplorerSides currentExplorerSidePosition;

        /// <summary>
        /// Gets or sets the current side position of the Explorer bar.
        /// </summary>
        public ExplorerSides CurrentExplorerSidePosition
        {
            get => this.currentExplorerSidePosition;
            set
            {
                this.currentExplorerSidePosition = value;
                this.RaisePropertyChangedEvent();
            }
        }

        /// <summary>
        /// Stores the current visibility state of the Explorer bar.
        /// </summary>
        private ExplorerVisibility explorerVisibility;

        /// <summary>
        /// Gets or sets the visibility state of the Explorer bar.
        /// </summary>
        public ExplorerVisibility ExplorerVisibility
        {
            get => this.explorerVisibility;
            set
            {
                this.explorerVisibility = value;
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
        public BaseExplorerItemViewModel CurrentSelectedExplorerItem
        {
            get => this.selectedExplorerItem;
            set
            {
                this.selectedExplorerItem = value;
                this.RaisePropertyChangedEvent();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExplorerInteractiveViewModel"/> class.
        /// </summary>
        /// <param name="manager">The manager used to create and manage Explorer item view models.</param>
        /// <param name="dialogProcessor">The processor used to interact with file dialogs.</param>
        /// <param name="parsingViewModel">The view model used to parse XPT documents.</param>
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

        /// <summary>
        /// Initializes the commands used by the Explorer.
        /// </summary>
        private void InitializeExplorerCommands()
        {
            this.OpenExplorerBarCommand = new DelegateCommand(this.SetUpExplorerVisability);
            this.CloseExplorerBarCommand = new DelegateCommand(this.SetUpExplorerVisability);
            this.AddExplorerItemCommand = new DelegateCommand(this.HandleOnAddExplorerItemCommnad);
            this.ChangeExplorerBarSideCommand = new DelegateCommand(this.HandleOnChangeExplorerSide);
            this.RemoveExplorerItemCommand = new DelegateCommand(this.HandleOnRemoveExplorerItemCommand);
        }

        /// <summary>
        /// Toggles the visibility of the Explorer bar.
        /// </summary>
        /// <param name="parameter">The command parameter.</param>
        private void SetUpExplorerVisability(object parameter)
        {
            this.ExplorerVisibility = this.ExplorerVisibility == ExplorerVisibility.Visible ?
                ExplorerVisibility.Hidden : ExplorerVisibility.Visible;
        }

        /// <summary>
        /// Changes the side position of the Explorer bar.
        /// </summary>
        /// <param name="parrameter">The command parameter.</param>
        private void HandleOnChangeExplorerSide(object parrameter = null)
        {
            this.CurrentExplorerSidePosition = this.CurrentExplorerSidePosition == ExplorerSides.Left ?
                ExplorerSides.Right : ExplorerSides.Left;
        }

        /// <summary>
        /// Removes the specified Explorer item.
        /// </summary>
        /// <param name="parameter">The Explorer item to remove.</param>
        private void HandleOnRemoveExplorerItemCommand(object parameter = null)
        {
            var requiredItemToRemove = parameter as BaseExplorerItemViewModel;
            this.Items.Remove(requiredItemToRemove);

            this.RaiseExplorerItemRemovedEvent(new(requiredItemToRemove));
            this.CurrentSelectedExplorerItem = null;
        }

        /// <summary>
        /// Raises the <see cref="ExplorerItemRemoved"/> event.
        /// </summary>
        /// <param name="eventArgs">The event arguments.</param>
        private void RaiseExplorerItemRemovedEvent(ExplorerItemRemovedEventArgs eventArgs)
        {
            this.ExplorerItemRemoved?.Invoke(this, eventArgs);
        }

        /// <summary>
        /// Handles the command used to add an Explorer item.
        /// </summary>
        /// <param name="obj">The command parameter.</param>
        private void HandleOnAddExplorerItemCommnad(object obj)
        {
            var fullFilePath = this.dialogProcessor.TryGetFileFullPath(out bool result);

            if (result == false)
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

        /// <summary>
        /// Gets the commands shared by Explorer items.
        /// </summary>
        /// <returns>A collection of shared Explorer item commands.</returns>
        private IEnumerable<ExplorerItemCommandModel> GetSharedExplorerItemCommands()
        {
            return [new ExplorerItemCommandModel(Resources.RemoveCommand, this.RemoveExplorerItemCommand)];
        }

        /// <summary>
        /// Gets the event handlers associated with Explorer items.
        /// </summary>
        /// <returns>A dictionary containing event handler types and their delegates.</returns>
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