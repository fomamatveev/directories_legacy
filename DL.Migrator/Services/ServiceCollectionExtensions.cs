using DL.Migrator.Data;

namespace DL.Migrator.Services;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMigrator(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<Migrator>();
        serviceCollection.AddSingleton<DatabaseConnectionFactory>();

        return serviceCollection;
    }
}