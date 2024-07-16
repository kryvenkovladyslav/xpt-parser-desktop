using System.Windows.Input;

namespace XptParser.DesktopApplication
{
    public sealed class ExplorerItemCommandModel
    {
        public string Name { get; init; }

        public ICommand Command { get; init; }

        public object CommandParameter { get; init; }

        public ExplorerItemCommandModel(string name, ICommand command, object commandParameter = null)
        {
            this.Name = name;
            this.Command = command;
            this.CommandParameter = commandParameter;   
        }
    }
}