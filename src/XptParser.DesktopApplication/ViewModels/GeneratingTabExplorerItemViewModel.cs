using System;

namespace XptParser.DesktopApplication
{
    /// <summary>
    /// Represents an Explorer item view model that can generate a tab.
    /// </summary>
    public abstract class GeneratingTabExplorerItemViewModel : BaseExplorerItemViewModel
    {
        /// <summary>
        /// Occurs when a tab is generated.
        /// </summary>
        public event EventHandler<TabGeneratedEventArgs> TabGeneratedEvent;

        /// <summary>
        /// Initializes a new instance of the <see cref="GeneratingTabExplorerItemViewModel"/> class.
        /// </summary>
        /// <param name="baseExplorerItem">The underlying Explorer item model.</param>
        public GeneratingTabExplorerItemViewModel(BaseExplorerItemModel baseExplorerItem) : base(baseExplorerItem) { }

        /// <summary>
        /// Creates the event arguments for a generated tab.
        /// </summary>
        /// <param name="viewToDisplay">The view model to display in the generated tab.</param>
        /// <returns>The event arguments for the generated tab.</returns>
        protected abstract TabGeneratedEventArgs CreateTabGeneratedEventArgs(WindowInteractiveViewModel viewToDisplay);

        /// <summary>
        /// Raises the <see cref="TabGeneratedEvent"/> event.
        /// </summary>
        /// <param name="viewToDisplay">The view model to display in the generated tab.</param>
        public virtual void RaiseTabGeneratedEvent(WindowInteractiveViewModel viewToDisplay) =>
            this.TabGeneratedEvent?.Invoke(this, this.CreateTabGeneratedEventArgs(viewToDisplay));
    }
}