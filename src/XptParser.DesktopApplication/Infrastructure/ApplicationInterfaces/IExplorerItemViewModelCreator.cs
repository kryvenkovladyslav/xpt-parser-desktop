using System.Collections.Generic;

namespace XptParser.DesktopApplication
{
    /// <summary>
    /// Defines a creator for Explorer item view models.
    /// </summary>
    public interface IExplorerItemViewModelCreator<out TViewModel>
        where TViewModel : BaseExplorerItemViewModel
    {
        /// <summary>
        /// Determines whether an Explorer item can be created for the specified file.
        /// </summary>
        /// <param name="fileFullPath">The full path of the file.</param>
        /// <returns><see langword="true"/> if the item can be created; otherwise, <see langword="false"/>.</returns>
        public bool CanCreate(string fileFullPath);

        /// <summary>
        /// Creates an Explorer item view model for the specified file.
        /// </summary>
        /// <param name="fileFullPath">The full path of the file.</param>
        /// <param name="sharedCommands">The shared commands available to the Explorer item.</param>
        /// <returns>The created Explorer item view model.</returns>
        public TViewModel CreateExplorerItem(string fileFullPath, IEnumerable<ExplorerItemCommandModel> sharedCommands);
    }
}