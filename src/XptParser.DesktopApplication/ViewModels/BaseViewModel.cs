using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace XptParser.DesktopApplication
{
    /// <summary>
    /// Represents the base view model for application data.
    /// </summary>
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises the <see cref="PropertyChanged"/> event.
        /// </summary>
        /// <param name="propertyName">The name of the property that changed.</param>
        protected virtual void RaisePropertyChangedEvent([CallerMemberName] string propertyName = null) =>
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        /// <summary>
        /// Loads the view model data asynchronously.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        protected virtual Task LoadAsync() => Task.CompletedTask;
    }
}