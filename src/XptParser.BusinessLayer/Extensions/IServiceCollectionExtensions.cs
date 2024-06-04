using Microsoft.Extensions.DependencyInjection;
using SasXptParser.DependencyInjection;
using XptParser.Domain;

namespace XptParser.BusinessLayer
{
    public static class IServiceCollectionExtensions
    {
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