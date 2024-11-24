using DL.Migrator.Data;

namespace DL.Migrator.Services;

public static class MigrationServiceCollectionExtensions
{
    /// <summary>
    /// Расширение для регистрации Migration сервиса
    /// </summary>
    /// <param name="serviceCollection">Коллекция</param>
    /// <returns>IServiceCollection</returns>
    public static IServiceCollection AddMigrator(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<Migrator>();
        serviceCollection.AddSingleton<DatabaseConnectionFactory>();

        return serviceCollection;
    }
}