using System;

namespace XptParser.DesktopApplication
{
    public class TabViewModel : BaseViewModel
    {
        private string name;

        public string Name
        {
            get => this.name;
            init
            {
                this.name = value;
                this.RaisePropertyChangedEvent();
            }
        }

        private WindowInteractiveViewModel viewModelToDispaly;

        public WindowInteractiveViewModel ViewModelToDisplay
        {
            get => this.viewModelToDispaly;
            set
            {
                this.viewModelToDispaly = value;
                this.RaisePropertyChangedEvent();
            }
        }

        public Guid ProducerID { get; init; }

        public TabViewModel(string name, Guid producerID, WindowInteractiveViewModel viewModelToDisplay)
        {
            this.Name = name;
            this.ProducerID = producerID;
            this.ViewModelToDisplay = viewModelToDisplay;
        }
    }
}