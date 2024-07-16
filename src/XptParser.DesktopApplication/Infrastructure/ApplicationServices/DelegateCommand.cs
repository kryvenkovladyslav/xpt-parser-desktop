using System;
using System.Windows.Input;

namespace XptParser.DesktopApplication
{
    public class DelegateCommand : ICommand
    {
        public virtual event EventHandler CanExecuteChanged;

        protected Action<object> Action { get; private init; }

        protected Predicate<object> CanExecuteMethod { get; private init; }

        public DelegateCommand(Action<object> action, Predicate<object> canExecuteMethod = null)
        {
            this.CanExecuteMethod = canExecuteMethod;
            this.Action = action ?? throw new ArgumentNullException(nameof(action));
        }

        public virtual void RaiseCanExecuteChangedEvent()
        {
            this.CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public virtual bool CanExecute(object parameter)
        {
            return this.CanExecuteMethod == null || this.CanExecuteMethod.Invoke(parameter);
        }

        public virtual void Execute(object parameter)
        {
            this.Action.Invoke(parameter);
        }
    }
}