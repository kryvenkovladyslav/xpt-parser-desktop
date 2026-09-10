using System;
using System.Collections.Generic;
using XptParser.Contracts;

namespace XptParser.DesktopApplication
{
    /// <summary>
    /// Defines a manager for creating and handling Explorer item view models.
    /// </summary>
    public interface IExplorerItemViewModelManager
    {
        /// <summary>
        /// Gets or initializes the document details extractor.
        /// </summary>
        public IDocumentDetailsExtractor DocumentDetailsExtractor { get; init; }

        /// <summary>
        /// Determines whether event handlers can be created for the specified file.
        /// </summary>
        /// <param name="fileFullPath">The full path of the file.</param>
        /// <returns><see langword="true"/> if event handlers are supported; otherwise, <see langword="false"/>.</returns>
        public bool SupportEventCreation(string fileFullPath);

        /// <summary>
        /// Creates an Explorer item view model for the specified file.
        /// </summary>
        /// <param name="fileFullPath">The full path of the file.</param>
        /// <param name="sharedCommands">The shared commands available to the Explorer item.</param>
        /// <param name="eventHandlers">The event handlers associated with the Explorer item.</param>
        /// <returns>The created Explorer item view model.</returns>
        public BaseExplorerItemViewModel Create(string fileFullPath, IEnumerable<ExplorerItemCommandModel> sharedCommands, Dictionary<Type, Delegate> eventHandlers = null);
    }
}