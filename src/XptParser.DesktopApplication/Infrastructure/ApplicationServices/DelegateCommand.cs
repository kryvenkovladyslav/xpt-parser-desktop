using System;
using System.Windows.Input;

namespace XptParser.DesktopApplication
{
    /// <summary>
    /// Represents a command that delegates execution and can optionally determine whether it can execute.
    /// </summary>
    public class DelegateCommand : ICommand
    {
        /// <summary>
        /// Occurs when the command's ability to execute has changed.
        /// </summary>
        public virtual event EventHandler CanExecuteChanged;

        /// <summary>
        /// Gets the action executed by the command.
        /// </summary>
        protected Action<object> Action { get; private init; }

        /// <summary>
        /// Gets the method used to determine whether the command can execute.
        /// </summary>
        protected Predicate<object> CanExecuteMethod { get; private init; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DelegateCommand"/> class.
        /// </summary>
        /// <param name="action">The action to execute.</param>
        /// <param name="canExecuteMethod">The method used to determine whether the command can execute.</param>
        public DelegateCommand(Action<object> action, Predicate<object> canExecuteMethod = null)
        {
            this.CanExecuteMethod = canExecuteMethod;
            this.Action = action ?? throw new ArgumentNullException(nameof(action));
        }

        /// <summary>
        /// Raises the <see cref="CanExecuteChanged"/> event.
        /// </summary>
        public virtual void RaiseCanExecuteChangedEvent()
        {
            this.CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Determines whether the command can execute with the specified parameter.
        /// </summary>
        /// <param name="parameter">The command parameter.</param>
        /// <returns><see langword="true"/> if the command can execute; otherwise, <see langword="false"/>.</returns>
        public virtual bool CanExecute(object parameter)
        {
            return this.CanExecuteMethod == null || this.CanExecuteMethod.Invoke(parameter);
        }

        /// <summary>
        /// Executes the command with the specified parameter.
        /// </summary>
        /// <param name="parameter">The command parameter.</param>
        public virtual void Execute(object parameter)
        {
            this.Action.Invoke(parameter);
        }
    }
}