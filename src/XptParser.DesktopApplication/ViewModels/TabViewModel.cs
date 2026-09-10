using System;

namespace XptParser.DesktopApplication
{
    /// <summary>
    /// Represents a view model for an application tab.
    /// </summary>
    public class TabViewModel : BaseViewModel
    {
        /// <summary>
        /// Stores the tab name.
        /// </summary>
        private string name;

        /// <summary>
        /// Gets or initializes the name of the tab.
        /// </summary>
        public string Name
        {
            get => this.name;
            init
            {
                this.name = value;
                this.RaisePropertyChangedEvent();
            }
        }

        /// <summary>
        /// Stores the view model displayed by the tab.
        /// </summary>
        private WindowInteractiveViewModel viewModelToDispaly;

        /// <summary>
        /// Gets or sets the view model displayed by the tab.
        /// </summary>
        public WindowInteractiveViewModel ViewModelToDisplay
        {
            get => this.viewModelToDispaly;
            set
            {
                this.viewModelToDispaly = value;
                this.RaisePropertyChangedEvent();
            }
        }

        /// <summary>
        /// Gets the identifier of the Explorer item that produced the tab.
        /// </summary>
        public Guid ProducerID { get; init; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TabViewModel"/> class.
        /// </summary>
        /// <param name="name">The name of the tab.</param>
        /// <param name="producerID">The identifier of the item that produced the tab.</param>
        /// <param name="viewModelToDisplay">The view model to display in the tab.</param>
        public TabViewModel(string name, Guid producerID, WindowInteractiveViewModel viewModelToDisplay)
        {
            this.Name = name;
            this.ProducerID = producerID;
            this.ViewModelToDisplay = viewModelToDisplay;
        }
    }
}