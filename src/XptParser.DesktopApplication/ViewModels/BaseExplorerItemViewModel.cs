using System;
using System.Collections.Generic;

namespace XptParser.DesktopApplication
{
    /// <summary>
    /// Represents the base view model for an Explorer item.
    /// </summary>
    public abstract class BaseExplorerItemViewModel : BaseViewModel
    {
        /// <summary>
        /// Gets the underlying Explorer item model.
        /// </summary>
        public BaseExplorerItemModel BaseExplorerItem { get; init; }

        /// <summary>
        /// Gets or sets the name of the Explorer item.
        /// </summary>
        public string Name
        {
            get => this.BaseExplorerItem.Name;
            set
            {
                this.BaseExplorerItem.Name = value;
                this.RaisePropertyChangedEvent();
            }
        }

        /// <summary>
        /// Gets the unique identifier of the Explorer item.
        /// </summary>
        public Guid ID => this.BaseExplorerItem.ID;

        /// <summary>
        /// Gets the commands associated with the Explorer item.
        /// </summary>
        public IEnumerable<ExplorerItemCommandModel> Commands => this.BaseExplorerItem.Commands;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseExplorerItemViewModel"/> class.
        /// </summary>
        /// <param name="baseExplorerItem">The underlying Explorer item model.</param>
        public BaseExplorerItemViewModel(BaseExplorerItemModel baseExplorerItem) =>
            this.BaseExplorerItem = baseExplorerItem;
    }
}