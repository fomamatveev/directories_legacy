using DL.Audit.Data;
using DL.Audit.Interfaces;
using DL.Audit.Models.Interceptors;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DL.Audit.Services;

public static class AuditServiceCollectionExtensions
{
    /// <summary>
    /// Расширение для регистрации AuditService
    /// </summary>
    /// <param name="serviceCollection"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IServiceCollection AddAudit(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddSingleton<AuditInterceptor>();
        
        serviceCollection.AddDbContext<AuditDbContext>(options =>
            options
                .UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        serviceCollection.AddScoped<IAuditService, AuditService>();

        return serviceCollection;
    }
}