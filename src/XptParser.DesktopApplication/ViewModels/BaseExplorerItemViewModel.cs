using System;
using System.Collections.Generic;

namespace XptParser.DesktopApplication
{
    public abstract class BaseExplorerItemViewModel : BaseViewModel
    {
        public BaseExplorerItemModel BaseExplorerItem { get; init; }
        
        public string Name
        {
            get => this.BaseExplorerItem.Name;
            set
            {
                this.BaseExplorerItem.Name = value;
                this.RaisePropertyChangedEvent();
            }
        }

        public Guid ID => this.BaseExplorerItem.ID;

        public IEnumerable<ExplorerItemCommandModel> Commands => this.BaseExplorerItem.Commands;

        public BaseExplorerItemViewModel(BaseExplorerItemModel baseExplorerItem) => 
            this.BaseExplorerItem = baseExplorerItem;
    }
}