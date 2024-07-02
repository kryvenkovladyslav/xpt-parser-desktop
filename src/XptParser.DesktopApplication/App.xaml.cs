using Microsoft.Extensions.DependencyInjection;
using XptParser.BusinessLayer;
using System;
using System.Windows;
using XptParser.Contracts;

namespace XptParser.DesktopApplication
{
    public sealed partial class App : Application
    {
        private readonly ServiceProvider serviceProvider;

        public App()
        {
            var services = new ServiceCollection();
            this.ConfigureServices(services);

            this.serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs eventArgs)
        {
            base.OnStartup(eventArgs);

            var mainWindow = this.serviceProvider.GetService<MainWindow>();
            mainWindow.Show();

            this.RegisterExceptionsHandler();
        }

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

        private void HandleExceptions(Exception exception)
        {
            var handler = this.serviceProvider.GetService<IExceptionHandler>();
            handler.HandleException(exception);
        }

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