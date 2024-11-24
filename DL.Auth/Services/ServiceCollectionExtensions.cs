using DL.Auth.Data;
using DL.Auth.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

namespace DL.Auth.Services;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAuth(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddDbContext<AuthDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        serviceCollection.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options => options.LoginPath = "/login");
        serviceCollection.AddAuthorization();
        
        serviceCollection.AddScoped<UserRepository>();
        serviceCollection.AddScoped<AuthService>();

        return serviceCollection;
    }
}