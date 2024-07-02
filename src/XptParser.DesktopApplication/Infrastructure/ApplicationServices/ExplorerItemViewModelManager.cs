using XptParser.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using XptParser.Contracts;

namespace XptParser.DesktopApplication
{
    public sealed class ExplorerItemViewModelManager : IExplorerItemViewModelManager
    {
        private readonly Dictionary<string, bool> supportedFileExtensions;

        public IDocumentDetailsExtractor DocumentDetailsExtractor { get; init; }

        private readonly IEnumerable<IExplorerItemViewModelCreator<BaseExplorerItemViewModel>> viewModelCreators;

        public ExplorerItemViewModelManager(IDocumentDetailsExtractor documentDetailsExtractor,
            IEnumerable<IExplorerItemViewModelCreator<BaseExplorerItemViewModel>> viewModelCreators)
        {
            this.DocumentDetailsExtractor = documentDetailsExtractor;
            this.viewModelCreators = viewModelCreators;

            this.supportedFileExtensions = this.InitializeSupportedFileExtensions();
        }

        public bool SupportEventCreation(string fileFullPath)
        {
            var normalizedExtension = this.DocumentDetailsExtractor.GetNormalizedDocumentExtension(fileFullPath);
            return this.supportedFileExtensions.ContainsKey(normalizedExtension);
        }

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

        private BaseExplorerItemViewModel Create(string itemsPath, IEnumerable<ExplorerItemCommandModel> sharedCommands)
        {
            var viewModel = this.viewModelCreators
                .Single(creator => creator.CanCreate(itemsPath))
                .CreateExplorerItem(itemsPath, sharedCommands);

            return viewModel;
        }

        private Dictionary<string, bool> InitializeSupportedFileExtensions()
        {
            return new()
            {
                { DocumentExtensions.XPT, true }
            };
        }
    }
}