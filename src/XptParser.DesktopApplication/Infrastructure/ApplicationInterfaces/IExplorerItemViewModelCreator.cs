using System.Collections.Generic;

namespace XptParser.DesktopApplication
{
    public interface IExplorerItemViewModelCreator<out TViewModel> 
        where TViewModel : BaseExplorerItemViewModel
    {
        public bool CanCreate(string fileFullPath);

        public TViewModel CreateExplorerItem(string fileFullPath, IEnumerable<ExplorerItemCommandModel> sharedCommands);
    }
}