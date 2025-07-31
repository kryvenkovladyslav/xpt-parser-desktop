using Microsoft.Extensions.DependencyInjection;
using SasXptParser.DependencyInjection;
using XptParser.Contracts;

namespace XptParser.BusinessLayer
{
    /// <summary>
    /// Provides extension methods for registering business layer services in the dependency injection container
    /// </summary>
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Registers services related to the business layer, including SAS XPT parsing components and document processing services
        /// </summary>
        /// <param name="services">The service collection to which the services will be added</param>
        /// <returns>The updated <see cref="IServiceCollection"/> instance</returns>
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddSasXptParsing();

            services
                .AddTransient<IDocumentReader, LocalMachineDocumentReader>()
                .AddTransient<IXptDocumentParser, XptDocumentParser>();

            return services;
        }
    }
}