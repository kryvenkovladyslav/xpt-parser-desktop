using XptParser.Domain;
using System.Collections.Generic;
using System.Linq;
using XptParser.Contracts;

namespace XptParser.DesktopApplication
{
    /// <summary>
    /// Provides a base implementation for creating Explorer item view models.
    /// </summary>
    public abstract class BaseExplorerItemViewModelCreator<TViewModel> : IExplorerItemViewModelCreator<TViewModel>
        where TViewModel : BaseExplorerItemViewModel
    {
        /// <summary>
        /// Gets the document details extractor.
        /// </summary>
        protected IDocumentDetailsExtractor DocumentDetailsExtractor { get; private init; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseExplorerItemViewModelCreator{TViewModel}"/> class.
        /// </summary>
        /// <param name="documentDetailsExtractor">The document details extractor.</param>
        public BaseExplorerItemViewModelCreator(IDocumentDetailsExtractor documentDetailsExtractor) =>
            this.DocumentDetailsExtractor = documentDetailsExtractor;

        /// <summary>
        /// Creates an Explorer item view model for the specified file.
        /// </summary>
        /// <param name="fileFullPath">The full path of the file.</param>
        /// <param name="sharedCommands">The shared commands available to the Explorer item.</param>
        /// <returns>The created Explorer item view model.</returns>
        public abstract TViewModel CreateExplorerItem(string fileFullPath, IEnumerable<ExplorerItemCommandModel> sharedCommands);

        /// <summary>
        /// Determines whether an Explorer item can be created for the specified file.
        /// </summary>
        /// <param name="fileFullPath">The full path of the file.</param>
        /// <returns><see langword="true"/> if the item can be created; otherwise, <see langword="false"/>.</returns>
        public virtual bool CanCreate(string fileFullPath)
        {
            var normalizedExtension = GetNormalizedItemExtension(fileFullPath);
            return DocumentExtensions.NormalizedSupportedExtensions.Contains(normalizedExtension);
        }

        /// <summary>
        /// Gets the normalized extension of the specified file.
        /// </summary>
        /// <param name="fileFullPath">The full path of the file.</param>
        /// <returns>The normalized file extension.</returns>
        protected virtual string GetNormalizedItemExtension(string fileFullPath)
        {
            return this.DocumentDetailsExtractor.GetNormalizedDocumentExtension(fileFullPath);
        }
    }
}