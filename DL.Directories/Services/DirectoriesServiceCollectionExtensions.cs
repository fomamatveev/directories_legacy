﻿using DL.Audit.Models;
using DL.Audit.Models.Interceptors;
using DL.Core;
using DL.Core.Data;
using DL.Core.Interfaces;
using DL.Core.Models;
using DL.Core.Models.Product;
using DL.Core.Models.Storage;
using DL.Directories.Interfaces.ProductInterface;
using DL.Directories.Interfaces.StorageInterface;
using DL.Directories.Services.ProductService;
using DL.Directories.Services.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DL.Directories.Services;

public static class DirectoriesServiceCollectionExtensions
{
    /// <summary>
    /// Расширение для регистрации базового репозитория справочников
    /// </summary>
    /// <param name="serviceCollection"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IServiceCollection AddDirectoriesRepository(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddDbContext<DirectoriesDbContext>((provider, options) => options
                .AddInterceptors(provider.GetRequiredService<AuditInterceptor>())
                .UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        return serviceCollection;
    }
    
    /// <summary>
    /// Расширение для регистрации ProductService
    /// </summary>
    /// <param name="serviceCollection"></param>
    /// <returns></returns>
    public static IServiceCollection AddProduct(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IProductService, ProductService.ProductService>();

        return serviceCollection;
    }
        
    /// <summary>
    /// Расширение для регистрации StorageLocationService
    /// </summary>
    /// <param name="serviceCollection"></param>
    /// <returns></returns>
    public static IServiceCollection AddProductName(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IProductNameService, ProductNameService>();

        return serviceCollection;
    }
    
    /// <summary>
    /// Расширение для регистрации ProductTypeService
    /// </summary>
    /// <param name="serviceCollection"></param>
    /// <returns></returns>
    public static IServiceCollection AddProductType(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IProductTypeService, ProductTypeService>();

        return serviceCollection;
    }

    /// <summary>
    /// Расширение для регистрации StorageLocationService
    /// </summary>
    /// <param name="serviceCollection"></param>
    /// <returns></returns>
    public static IServiceCollection AddStorageLocation(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IStorageLocationService, StorageLocationService>();

        return serviceCollection;
    }
}