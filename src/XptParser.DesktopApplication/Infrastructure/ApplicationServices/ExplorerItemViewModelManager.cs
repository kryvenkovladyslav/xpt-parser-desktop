using XptParser.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using XptParser.Contracts;

namespace XptParser.DesktopApplication
{
    /// <summary>
    /// Manages the creation of Explorer item view models.
    /// </summary>
    public sealed class ExplorerItemViewModelManager : IExplorerItemViewModelManager
    {
        /// <summary>
        /// Stores supported file extensions.
        /// </summary>
        private readonly Dictionary<string, bool> supportedFileExtensions;

        /// <summary>
        /// Gets or initializes the document details extractor.
        /// </summary>
        public IDocumentDetailsExtractor DocumentDetailsExtractor { get; init; }

        /// <summary>
        /// Stores the available Explorer item view model creators.
        /// </summary>
        private readonly IEnumerable<IExplorerItemViewModelCreator<BaseExplorerItemViewModel>> viewModelCreators;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExplorerItemViewModelManager"/> class.
        /// </summary>
        /// <param name="documentDetailsExtractor">The document details extractor.</param>
        /// <param name="viewModelCreators">The Explorer item view model creators.</param>
        public ExplorerItemViewModelManager(IDocumentDetailsExtractor documentDetailsExtractor,
            IEnumerable<IExplorerItemViewModelCreator<BaseExplorerItemViewModel>> viewModelCreators)
        {
            this.DocumentDetailsExtractor = documentDetailsExtractor;
            this.viewModelCreators = viewModelCreators;

            this.supportedFileExtensions = this.InitializeSupportedFileExtensions();
        }

        /// <summary>
        /// Determines whether event handlers are supported for the specified file.
        /// </summary>
        /// <param name="fileFullPath">The full path of the file.</param>
        /// <returns><see langword="true"/> if event handlers are supported; otherwise, <see langword="false"/>.</returns>
        public bool SupportEventCreation(string fileFullPath)
        {
            var normalizedExtension = this.DocumentDetailsExtractor.GetNormalizedDocumentExtension(fileFullPath);
            return this.supportedFileExtensions.ContainsKey(normalizedExtension);
        }

        /// <summary>
        /// Creates an Explorer item view model and optionally attaches event handlers.
        /// </summary>
        /// <param name="fileFullPath">The full path of the file.</param>
        /// <param name="sharedCommands">The shared commands available to the Explorer item.</param>
        /// <param name="eventHandlers">The event handlers to attach to the created view model.</param>
        /// <returns>The created Explorer item view model.</returns>
        public BaseExplorerItemViewModel Create(string fileFullPath, IEnumerable<ExplorerItemCommandModel> sharedCommands, Dictionary<Type, Delegate> eventHandlers = null)
        {
            var viewModel = Create(fileFullPath, sharedCommands);

            if (eventHandlers == null)
            {
                return viewModel;
            }

            var viewModelType = viewModel.GetType();
            var events = viewModelType.GetEvents().ToDictionary(currentEvent => currentEvent.EventHandlerType, eventInfo => eventInfo);

            foreach (var eventKey in eventHandlers.Keys)
            {
                if (events.TryGetValue(eventHandlers[eventKey].GetType(), out var currentEvent))
                {
                    currentEvent.AddEventHandler(viewModel, eventHandlers[eventKey]);
                }
            }

            return viewModel;
        }

        /// <summary>
        /// Creates an Explorer item view model for the specified path.
        /// </summary>
        /// <param name="itemsPath">The path of the item.</param>
        /// <param name="sharedCommands">The shared commands available to the Explorer item.</param>
        /// <returns>The created Explorer item view model.</returns>
        private BaseExplorerItemViewModel Create(string itemsPath, IEnumerable<ExplorerItemCommandModel> sharedCommands)
        {
            var viewModel = this.viewModelCreators
                .Single(creator => creator.CanCreate(itemsPath))
                .CreateExplorerItem(itemsPath, sharedCommands);

            return viewModel;
        }

        /// <summary>
        /// Initializes the collection of supported file extensions.
        /// </summary>
        /// <returns>A dictionary containing supported file extensions.</returns>
        private Dictionary<string, bool> InitializeSupportedFileExtensions()
        {
            return new()
            {
                { DocumentExtensions.XPT, true }
            };
        }
    }
}