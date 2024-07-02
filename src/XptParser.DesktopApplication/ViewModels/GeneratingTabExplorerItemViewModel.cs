using System;

namespace XptParser.DesktopApplication
{
    public abstract class GeneratingTabExplorerItemViewModel : BaseExplorerItemViewModel
    {
        public event EventHandler<TabGeneratedEventArgs> TabGeneratedEvent;

        public GeneratingTabExplorerItemViewModel(BaseExplorerItemModel baseExplorerItem) : base(baseExplorerItem) { }

        protected abstract TabGeneratedEventArgs CreateTabGeneratedEventArgs(WindowInteractiveViewModel viewToDisplay);

        public virtual void RaiseTabGeneratedEvent(WindowInteractiveViewModel viewToDisplay) =>
            this.TabGeneratedEvent?.Invoke(this, this.CreateTabGeneratedEventArgs(viewToDisplay));
    }
}