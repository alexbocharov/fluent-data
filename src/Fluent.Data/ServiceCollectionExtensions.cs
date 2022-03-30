// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Fluent.Data;

namespace Microsoft.Extensions.DependencyInjection;

#nullable disable

/// <summary>
/// Provides extension methods for the <see cref="IServiceCollection"/> interface.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds the specified Data Access components.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection">services</see> available in the application.</param>
    /// <param name="optionsAction">An <see cref="Action{T}">action</see> used ti configure the provided options.</param>
    /// <returns>The original <paramref name="services"/> object.</returns>
    public static IServiceCollection AddDataAccess(this IServiceCollection services, Action<IConnection> optionsAction = null)
    {
        if (services == null)
        {
            throw new ArgumentNullException(nameof(services));
        }

        return AddDataAccess(
            services,
            optionsAction == null
                ? (Action<IServiceProvider, IConnection>)null
                : (p, c) => optionsAction?.Invoke(c));
    }

    /// <summary>
    /// Adds the specified Data Access components.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection">services</see> available in the application.</param>
    /// <param name="optionsAction">An <see cref="Action{T}">action</see> used ti configure the provided options.</param>
    /// <returns>The original <paramref name="services"/> object.</returns>
    public static IServiceCollection AddDataAccess(this IServiceCollection services, Action<IServiceProvider, IConnection> optionsAction)
    {
        if (services == null)
        {
            throw new ArgumentNullException(nameof(services));
        }

        var connection = new Connection();
        services.TryAdd(new ServiceDescriptor(typeof(IConnection), c => ConnectionFactory(c, optionsAction), ServiceLifetime.Singleton));

        return services;
    }

    private static IConnection ConnectionFactory(IServiceProvider serviceProvider, Action<IServiceProvider, IConnection> optionsAction)
    {
        var connection = new Connection();
        optionsAction?.Invoke(serviceProvider, connection);

        return connection;
    }
}
