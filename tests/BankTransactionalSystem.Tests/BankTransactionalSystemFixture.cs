using BankTransactionalSystem.Implementation.ServiceExtensios;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BankTransactionalSystem.Tests.Tests
{
    public class BankTransactionalSystemFixture : IDisposable
    {
        public IServiceScope Scope { get; private set; }

        public BankTransactionalSystemFixture()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath($"{AppDomain.CurrentDomain.BaseDirectory}")
                .AddJsonFile("appsettings.json", false)
                .Build();
            
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddAppServices(config);

            Scope = serviceCollection
                .AddLogging()
                .BuildServiceProvider()
                .CreateScope();
        }

        public void Dispose()
        {
            Scope.Dispose();
        }
    }
}
