// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Fluent.Data;

namespace Microsoft.Extensions.DependencyInjection;

#nullable disable

public static class ServiceCollectionExtensions
{
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
