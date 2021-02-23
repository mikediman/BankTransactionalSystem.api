using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

using BankTransactionalSystem.Implementation.Config;
using BankTransactionalSystem.Implementation.Config.Extensions;
using BankTransactionalSystem.Implementation.Database;
using BankTransactionalSystem.Interfaces;


namespace BankTransactionalSystem.Implementation.ServiceExtensios
{
    public static class ServiceCollectionExtensions
    {
        public static void AddAppServices(this IServiceCollection @this, IConfiguration configuration)
        {
            @this.AddSingleton<AppConfig>(configuration.ReadAppConfiguration());

            @this.AddDbContext<TransactionalSystemDbContext>(
                (serviceProvider, optionsBuilder) => {
                    var appConfig = serviceProvider.GetRequiredService<AppConfig>();
                    optionsBuilder.UseSqlServer(appConfig.TransactionalSystemString);
                });

            @this.AddScoped<ICardsService, CardsService>();
        }
    }
}
