using System.Collections.Generic;
using XptParser.Contracts;

namespace XptParser.DesktopApplication
{
    /// <summary>
    /// Creates Explorer item view models for unsupported file types.
    /// </summary>
    public class UnsupportedExplorerItemViewModelCreator : BaseExplorerItemViewModelCreator<UnsupportedExplorerItemViewModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnsupportedExplorerItemViewModelCreator"/> class.
        /// </summary>
        /// <param name="documentDetailsExtractor">The document details extractor.</param>
        public UnsupportedExplorerItemViewModelCreator(IDocumentDetailsExtractor documentDetailsExtractor) :
            base(documentDetailsExtractor)
        { }

        /// <summary>
        /// Determines whether an Explorer item cannot be created by the base creator.
        /// </summary>
        /// <param name="fileFullPath">The full path of the file.</param>
        /// <returns><see langword="true"/> if the file is unsupported; otherwise, <see langword="false"/>.</returns>
        public override bool CanCreate(string fileFullPath)
        {
            return !base.CanCreate(fileFullPath);
        }

        /// <summary>
        /// Creates an Explorer item view model for an unsupported file.
        /// </summary>
        /// <param name="fileFullPath">The full path of the file.</param>
        /// <param name="sharedCommands">The shared commands available to the Explorer item.</param>
        /// <returns>The created unsupported Explorer item view model.</returns>
        public override UnsupportedExplorerItemViewModel CreateExplorerItem(string fileFullPath, IEnumerable<ExplorerItemCommandModel> sharedCommands)
        {
            var unsupportedExplorerItemModel = new UnsupportedExplorerItemModel(fileFullPath, sharedCommands);
            return new UnsupportedExplorerItemViewModel(unsupportedExplorerItemModel);
        }
    }
}