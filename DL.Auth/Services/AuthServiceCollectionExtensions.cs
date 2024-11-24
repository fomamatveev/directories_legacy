﻿using DL.Auth.Data;
using DL.Auth.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

namespace DL.Auth.Services;

public static class AuthServiceCollectionExtensions
{
    /// <summary>
    /// Расширение для регистрации Auth сервиса
    /// </summary>
    /// <param name="serviceCollection">Коллекциця</param>
    /// <param name="configuration">Конфигурация</param>
    /// <returns>IServiceCollection</returns>
    public static IServiceCollection AddAuth(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddDbContext<AuthDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        serviceCollection.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = "/auth/login";
                options.LogoutPath = "/auth/logout";
                options.Cookie.HttpOnly = true;
                options.Cookie.SameSite = SameSiteMode.Strict;
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
            });
        serviceCollection.AddAuthorization();
        
        serviceCollection.AddScoped<UserRepository>();
        serviceCollection.AddScoped<AuthService>();

        return serviceCollection;
    }
}