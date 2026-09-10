using System.Windows.Input;

namespace XptParser.DesktopApplication
{
    /// <summary>
    /// Represents a command associated with an Explorer item.
    /// </summary>
    public sealed class ExplorerItemCommandModel
    {
        /// <summary>
        /// Gets the name of the command.
        /// </summary>
        public string Name { get; init; }

        /// <summary>
        /// Gets the command to execute.
        /// </summary>
        public ICommand Command { get; init; }

        /// <summary>
        /// Gets the parameter passed to the command.
        /// </summary>
        public object CommandParameter { get; init; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExplorerItemCommandModel"/> class.
        /// </summary>
        /// <param name="name">The name of the command.</param>
        /// <param name="command">The command to execute.</param>
        /// <param name="commandParameter">The parameter passed to the command.</param>
        public ExplorerItemCommandModel(string name, ICommand command, object commandParameter = null)
        {
            this.Name = name;
            this.Command = command;
            this.CommandParameter = commandParameter;
        }
    }
}