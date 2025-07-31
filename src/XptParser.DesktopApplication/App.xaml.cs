using Microsoft.Extensions.DependencyInjection;
using XptParser.BusinessLayer;
using System;
using System.Windows;
using XptParser.Contracts;

namespace XptParser.DesktopApplication
{
    /// <summary>
    /// Represents the entry point for the WPF application
    /// Handles service configuration, exception registration, and startup logic
    /// </summary>
    public sealed partial class App : Application
    {
        private readonly ServiceProvider serviceProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class and configures dependency injection services
        /// </summary>
        public App()
        {
            var services = new ServiceCollection();
            this.ConfigureServices(services);

            this.serviceProvider = services.BuildServiceProvider();
        }

        /// <summary>
        /// Handles application startup logic, including showing the main window and registering exception handlers
        /// </summary>
        /// <param name="eventArgs">The startup event arguments</param>
        protected override void OnStartup(StartupEventArgs eventArgs)
        {
            base.OnStartup(eventArgs);

            var mainWindow = this.serviceProvider.GetService<MainWindow>();
            mainWindow.Show();

            this.RegisterExceptionsHandler();
        }

        /// <summary>
        /// Registers global exception handlers for unhandled exceptions in the app domain and UI dispatcher
        /// </summary>
        private void RegisterExceptionsHandler()
        {
            AppDomain.CurrentDomain.UnhandledException += (sender, eventArgs) =>
            {
                this.HandleExceptions(eventArgs.ExceptionObject as Exception);
            };

            this.DispatcherUnhandledException += (sender, eventArgs) =>
            {
                this.HandleExceptions(eventArgs.Exception);
                eventArgs.Handled = true;
            };
        }

        /// <summary>
        /// Handles exceptions by resolving the <see cref="IExceptionHandler"/> from the service container and invoking it
        /// </summary>
        /// <param name="exception">The exception to handle</param>
        private void HandleExceptions(Exception exception)
        {
            var handler = this.serviceProvider.GetService<IExceptionHandler>();
            handler.HandleException(exception);
        }

        /// <summary>
        /// Configures all application services for dependency injection, including view models, utilities, and business services
        /// </summary>
        /// <param name="services">The service collection to configure</param>
        private void ConfigureServices(ServiceCollection services)
        {
            services.AddTransient<MainWindow>();
            services.AddTransient<MainViewModel>();
            services.AddTransient<ParsingXptDocumentViewModel>();
            services.AddTransient<ExplorerInteractiveViewModel>();

            services.AddTransient<INormalizer, UpperNormalizer>();
            services.AddTransient<IDialogProcessor, WindowsDialogProcessor>();
            services.AddTransient<IExceptionHandler, ApplicationExceptionHandler>();
            services.AddTransient<IDocumentDetailsExtractor, DocumentDetailsExtractor>();
            services.AddTransient<IExplorerItemViewModelManager, ExplorerItemViewModelManager>();
            services.AddTransient<IExplorerItemViewModelCreator<BaseExplorerItemViewModel>, UnsupportedExplorerItemViewModelCreator>();
            services.AddTransient<IExplorerItemViewModelCreator<BaseExplorerItemViewModel>, XptDocumentExplorerItemViewModelCreator>();

            services.AddBusinessServices();
        }
    }
}