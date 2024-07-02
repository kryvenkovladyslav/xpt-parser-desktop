using System;
using XptParser.Contracts;
using XptParser.BusinessLayer;
using Microsoft.Extensions.DependencyInjection;

namespace XptParser.BusinessLayerTests
{
    public sealed class IServiceCollectionExtensionsTests
    {
        [Theory]
        [InlineData(typeof(IXptDocumentParser), typeof(XptDocumentParser))]
        [InlineData(typeof(IDocumentReader), typeof(LocalMachineDocumentReader))]
        public void IServiceCollectionExtensions_ServicesRegistered_ReturnsRequiredServices(Type interfaceType, Type actualType)
        {
            var services = new ServiceCollection();
            services.AddBusinessServices();
            var provider = services.BuildServiceProvider();

            var expectedService = provider.GetRequiredService(interfaceType);

            Assert.NotNull(expectedService);
            Assert.IsType(actualType, expectedService);
        }

        [Theory]
        [InlineData(typeof(IXptDocumentParser))]
        [InlineData(typeof(IDocumentReader))]
        public void IServiceCollectionExtensions_WithoutServicesRegistered_ThrowsInvalidOperationException(Type interfaceType)
        {
            var services = new ServiceCollection();
            var provider = services.BuildServiceProvider();

            var action = () => provider.GetRequiredService(interfaceType);

            Assert.Throws<InvalidOperationException>(action);
        }
    }
}