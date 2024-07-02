using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace XptParser.DesktopApplication
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChangedEvent([CallerMemberName] string propertyName = null) =>
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
  
        protected virtual Task LoadAsync() => Task.CompletedTask;
    }
}